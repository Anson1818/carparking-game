using System.Collections;
using TMPro;
using UnityEngine;

public class handletime : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public TextMeshProUGUI timerText;
    public GameObject missionpanel;
    public GameObject timeoutpanel;
    public obstacledetection uiscript;

    public spotdetection spotscript;
    public float missiontime;

    

    void Start()
    {
        Time.timeScale = 1f;
        StartCoroutine(missionreadtime());
       

    }



    void Update()
    {

    }

    IEnumerator CountDown(float timeLeft)
    {
        float elapsed = 0f;

        while (timeLeft - elapsed > 0)
        {
            float current = timeLeft - elapsed;
            int minutes = Mathf.FloorToInt(current / 60f);
            int seconds = Mathf.FloorToInt(current % 60f);
            timerText.text = $"{minutes:00}:{seconds:00}";

            yield return null;
            elapsed += Time.deltaTime;
            if (minutes == 00f && seconds == 00f)
            {
                activatetimeoutpanel();
            }


        }

        timerText.text = "00:00";


    }

    IEnumerator missionreadtime()
    {
       
        yield return new WaitForSecondsRealtime(3);
        missionpanel.SetActive(true);
        yield return new WaitForSecondsRealtime(3);
        missionpanel.SetActive(false);
        StartCoroutine(CountDown(missiontime));
    }

    void activatetimeoutpanel()
    {
        if (!uiscript.gameoverpanel.activeInHierarchy && !spotscript.winpanel.activeInHierarchy)
        {
            timeoutpanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }

   

}
