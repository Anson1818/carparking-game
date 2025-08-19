using System.Collections;
using UnityEngine;

public class fuelingalert : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject fuelalertpanel;
    bool compeleted=false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void  OnTriggerEnter(Collider colliderdata)
    {
        if (colliderdata.CompareTag("car")&&!compeleted)
        {
            compeleted = true;
            fuelalertpanel.SetActive(true);
            StartCoroutine(offpanel());
            Time.timeScale = 0f;
        }

    }

    IEnumerator offpanel()
    {
        yield return new WaitForSecondsRealtime(3);
        fuelalertpanel.SetActive(false);
        Time.timeScale = 1f;
  }




}
