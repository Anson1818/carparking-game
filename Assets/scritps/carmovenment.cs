using UnityEngine;

public class carmovenment : MonoBehaviour
{
    public WheelCollider frontleft;
    public WheelCollider frontright;
    public WheelCollider rearleft;
    public WheelCollider rearright;
    public float motortorque = 400f;
    public float breakingforece = 100f;
    public float steerforce = 30f;

    public Transform frontleftmesh;
    public Transform frontrightmesh;
    public Transform rearleftmesh;
    public Transform rearrightmesh;


    private float motor;
    private float steer;

    public Rigidbody rbcar;
    void Start()
    {
       GetComponent<Rigidbody>().centerOfMass = new Vector3(0f, -0.5f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        getinput();

        Handlesteering();
        updatewheelpos();
        Handletorque();

        if (Input.GetKey(KeyCode.Space))
        {
            handlebreaking();
        }
        else
        {
            rearright.brakeTorque = 0;
            rearleft.brakeTorque = 0;
        }


   }

    void getinput()
    {
        motor = Input.GetAxis("Vertical");
        steer = Input.GetAxis("Horizontal");
    }

    void Handletorque()
    {
        rearright.motorTorque = motor * motortorque;
        rearleft.motorTorque = motor * motortorque;

    }

    void handlebreaking()
    {
      
        rearright.brakeTorque = breakingforece;
        rearleft.brakeTorque = breakingforece;
    }

    void Handlesteering()
    {
        frontleft.steerAngle = steer * steerforce;
        frontright.steerAngle = steer * steerforce;
    }
    void updatewheelpos()
    {
        updatesinglewheel(frontleftmesh, frontleft);
        updatesinglewheel(frontrightmesh, frontright);
        updatesinglewheel(rearleftmesh, rearleft);
        updatesinglewheel(rearrightmesh, rearright);
    }
    void updatesinglewheel(Transform mesh, WheelCollider collider)
    {
        Quaternion rot;
        Vector3 pos;
        collider.GetWorldPose(out pos, out rot);
        mesh.rotation = rot;
        mesh.position = pos;

     }

     
}
