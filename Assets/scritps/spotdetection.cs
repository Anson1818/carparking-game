using UnityEngine;

public class spotdetection : MonoBehaviour
{

    public Transform Car;
    bool isparked = false;
    public GameObject winpanel;
    public ParticleSystem spoteffect;

    
    void OnTriggerStay(Collider spot)
    {


        float distance = Vector3.Distance(Car.position, transform.position);
        float angle = Quaternion.Angle(Car.rotation, transform.rotation);

         bool isAligned = angle < 10f || Mathf.Abs(angle - 180f) < 10f;


        if (distance < 1.5f && isAligned)
        {


            isparked = true;

            showpanel();

        }


    }

    void showpanel()
    {
        if (isparked)
        {
            winpanel.SetActive(true);
            spoteffect.Stop();
        }
    }

    

}
