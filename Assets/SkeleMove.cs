using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SkeleMove : MonoBehaviour
{
    public Animator anim;
    public NavMeshAgent navAgent;
    public Transform[] points;
    private int pointCount;
    void Start()
    {
        int rand = Random.Range(0,points.Length);
        navAgent.SetDestination(points[rand].position);
        anim.SetTrigger("Walk");
        
    }

    void Update()
    {
        if (navAgent.remainingDistance <= navAgent.stoppingDistance)
        {
            int rand = Random.Range(0,points.Length);
            navAgent.SetDestination(points[rand].position);
            ++pointCount;
            Debug.Log("Arrived! Point Count = " + pointCount);

        }
        if (pointCount == 5 && !navAgent.isStopped)
        {
            navAgent.isStopped = true; 
            anim.SetTrigger("Idle");
        }
            
    }
}
