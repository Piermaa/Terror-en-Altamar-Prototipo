using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
public class StealthEnemy : MonoBehaviour
{
    [SerializeField] Transform player;


    [SerializeField]Animator animator;
    [SerializeField] AudioSource detectionSound;
    [SerializeField] Transform[] waypoints;
    POV pov;

    NavMeshAgent navMeshAgent;
    public int waypointsIndex;

    public bool emitSound;
    public bool alarmed;
    public bool mustInvestigate;

    public bool playerSpotted;
    // Start is called before the first frame update
    void Start()
    {
       // animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.SetDestination(waypoints[waypointsIndex].position);
        pov = FindObjectOfType<POV>();
    }

    // Update is called once per frame
    void Update()
    {
        if(alarmed)
        {
            if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
            {
                alarmed = false;
            }
        }
        else
        {
            if (!mustInvestigate)
            {
                if (!pov.playerSeen)
                {
                    if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
                    {
                        if (waypointsIndex + 1 < waypoints.Length)
                        {
                            waypointsIndex++;
                        }
                        else
                        {
                            waypointsIndex = 0;
                        }

                        navMeshAgent.SetDestination(waypoints[waypointsIndex].position);
                    }
                }
                else
                {
                    CatchPlayer();
                }
            }
            else
            {
                if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
                {
                    mustInvestigate = false;
                    navMeshAgent.SetDestination(waypoints[waypointsIndex].position);
                }
            }

        }

        print(navMeshAgent.destination);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sound"))
        {
            navMeshAgent.SetDestination(player.position);
            mustInvestigate = true;
            alarmed = false;
        }
    }

    public void CatchPlayer()
    {
        if(!emitSound)
        {
            detectionSound.Play();
            emitSound = true;
        }
        animator.SetTrigger("Walk_Cycle_2");
        navMeshAgent.SetDestination(player.position);
        navMeshAgent.speed = 8;
        
    }

    public void InvestigateAlarm()
    {
        alarmed = true;
        navMeshAgent.SetDestination(waypoints[6].position);
        navMeshAgent.speed = 6;
        animator.SetTrigger("Walk_Cycle_2");
        if (!emitSound)
        {
            detectionSound.Play();
            emitSound = true;
        }
    }
}
