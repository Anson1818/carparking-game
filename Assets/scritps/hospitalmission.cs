using TMPro;
using UnityEngine;


public class hospitalmission : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   int kitcollected = 0;
    public TextMeshProUGUI medikitcount;


    public Transform door;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (kitcollected == 5)
        {
            openbarrier();
        }
        medikitcount.text = "Medikit:" + kitcollected;
    }

    void OnTriggerEnter(Collider data)
    {
        if (data.CompareTag("kit"))
        {
            data.gameObject.SetActive(false);
            kitcollected++;
            Debug.Log(kitcollected);
        }
    }
     
      void openbarrier()
    {
        if (kitcollected == 5)
        {
            
            door.transform.rotation = Quaternion.Euler(180, 0,0);

            
        }
    }
}
