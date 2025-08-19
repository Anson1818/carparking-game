using UnityEngine;

public class obstacledetection : MonoBehaviour
{
   
    public GameObject gameoverpanel;
    

     void OnCollisionEnter(Collision data)
    {
        if (data.collider.CompareTag("obstacle"))
        {
           
            gameover();
        }

    }

    void gameover()
    {
        gameoverpanel.SetActive(true);
        Time.timeScale = 0f;
    }
}
