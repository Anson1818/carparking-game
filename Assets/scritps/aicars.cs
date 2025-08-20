using UnityEngine;
using UnityEngine.AI;



public class aicars : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
       public Transform[] waypoints;
    public NavMeshAgent agent;
    private int currentIndex = 0;

    public Transform[] wheels; 
    public float rotationSpeed = 500f;

    void Start()
    {
       
        if (waypoints.Length > 0)
            agent.SetDestination(waypoints[currentIndex].position);
    }

    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.1f)
        {
            currentIndex = (currentIndex + 1) % waypoints.Length;
            agent.SetDestination(waypoints[currentIndex].position);
        }

        float speed = agent.velocity.magnitude;
        foreach (Transform wheel in wheels)
        {
            wheel.Rotate(Vector3.right, speed * rotationSpeed * Time.deltaTime);
        }

    }


}
