using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
public class Waypoints : MonoBehaviour
{
    public float speed = 5;

    [SerializeField] Transform player;

    public Transform wp;
    NavMeshAgent nMA;
    // Start is called before the first frame update
    void Start()
    {
       // nMA = GetComponent<NavMeshAgent>();

     
       
    }
    private void Update()
    {
        //nMA.SetDestination(wp.position);

        //nMA.speed = speed;

        transform.LookAt(player);

        transform.Translate(Vector3.forward * speed * Time.deltaTime);

    }

}
