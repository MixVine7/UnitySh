using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyZombieScript : MonoBehaviour
{

    NavMeshAgent agent;
    int i;
    public List<Transform> targets;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void TargetUpdate()
    {
        i = Random.Range(0, targets.Count);
    }

    // Update is called once per frame
    void Update()
    {
        if(agent.transform.position == agent.pathEndPosition)
        {
            TargetUpdate();
        }
        agent.SetDestination(targets[i].position);
    }
}
