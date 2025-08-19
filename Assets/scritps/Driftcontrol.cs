using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Driftcontrol : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public carmovenment carscript;
    public float driftmeter;
    public TextMeshProUGUI meterdisplay;
    public Transform barrier;
   
    public Rigidbody rb;
    public GameObject driftinfopanel;
    public TrailRenderer rightwheeltrail;
    public TrailRenderer leftwheeltrail;
    void Start()
    {
        StartCoroutine(dirftpanelactive());
    }

    // Update is called once per frame
    void Update()
    {

        meterdisplay.text = Math.Round(driftmeter) + " meters";

        if ((Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S)))
        {
            DriftOn();
        }
        else
        {
            DriftOff();
        }

        Vector3 localvelocity = transform.InverseTransformDirection(rb.linearVelocity);

        if (Mathf.Abs(localvelocity.x) > 1f)
        {

            driftmeter += Mathf.Abs(localvelocity.x) * Time.deltaTime;
        }

    }
    void OnTriggerEnter(Collider data)
    {
        if (data.CompareTag("point"))
        {
            openbarrier();
        }

    }


    void DriftOn()
    {

        WheelFrictionCurve driftFriction = carscript.rearleft.sidewaysFriction;
        driftFriction.stiffness = 0.6f;
        carscript.rearleft.sidewaysFriction = driftFriction;
        carscript.rearright.sidewaysFriction = driftFriction;

        rightwheeltrail.emitting = true;
        leftwheeltrail.emitting = true;
    }

    void DriftOff()
    {
        WheelFrictionCurve normalFriction = carscript.rearleft.sidewaysFriction;
        normalFriction.stiffness = 1.2f;
        carscript.rearleft.sidewaysFriction = normalFriction;
        carscript.rearright.sidewaysFriction = normalFriction;

        rightwheeltrail.emitting = false;
        leftwheeltrail.emitting = false;
    }

    void openbarrier()
    {
        if (driftmeter > 49f)
        {
            barrier.transform.Rotate(-90, 0, 0);
        }
    }

    IEnumerator dirftpanelactive()
    {
       
        driftinfopanel.SetActive(true);
        yield return new WaitForSecondsRealtime(6);
        driftinfopanel.SetActive(false);
    }
}
