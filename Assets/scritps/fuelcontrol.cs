using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class fuelcontrol : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject fuelpanel;
    public Slider fuelindicator;

    public ParticleSystem spot;

    bool compeleted=false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider data)
    {
        if (data.CompareTag("car")&& !compeleted)
        {

            compeleted = true;
            StartCoroutine(wait(2f));

            fuelpanel.SetActive(true);
            Time.timeScale = 0f;
            fuelindicator.value = 0;
            StartCoroutine(Fuelling());
        }
    }

    IEnumerator Fuelling()
    {
        while (fuelindicator.value != 2)
        {
            fuelindicator.value += 0.1f;
            yield return new WaitForSecondsRealtime(0.2f);
        }
        fuelpanel.SetActive(false);
        Time.timeScale = 1f;
        spot.Stop();
    }

    IEnumerator wait(float seconds)
    {
        yield return new WaitForSecondsRealtime(seconds);
    }
}
