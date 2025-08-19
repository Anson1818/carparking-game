
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIcontrol : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject pausepanel;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            pausepanel.SetActive(true);
            pausegame();
        }
    }

    public void pausegame()
    {
        Time.timeScale = 0f;
    }
    public void resume()
    {
        Time.timeScale = 1f;
        pausepanel.SetActive(false);
    }


    public void loadcurrentscene()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;


    }

    public void loadMainmenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Loadnextlevel()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index + 1);
    }
     void disablemouse()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void enablemouse()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
