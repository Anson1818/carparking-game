using UnityEngine;
using UnityEngine.AI;

public class L7script : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public NavMeshAgent Aj;
    public Transform ajdestination;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

   public void OnTriggerEnter(Collider data)
    {
        if (data.CompareTag("car"))
        {
            Walkaj();
           
          }
     }

    void Walkaj()
    {
        Aj.SetDestination(ajdestination.position);
     }
}
