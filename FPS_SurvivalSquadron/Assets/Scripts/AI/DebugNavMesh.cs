using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DebugNavMesh : MonoBehaviour
{
    public bool velocity;
    public bool desiredVlocity;
    public bool path;
    NavMeshAgent agent;
    
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        if(velocity)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, transform.position + agent.velocity);
        }

        if(desiredVlocity)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, transform.position + agent.desiredVelocity);
        }

        if(path)
        {
            Gizmos.color = Color.black;
            var agentPath = agent.path;
            Vector3 preCorner = transform.position;
            foreach(var conner in agentPath.corners)
            {
                Gizmos.DrawLine(preCorner, conner);
                Gizmos.DrawSphere(conner, 0.1f);
                preCorner = conner;
            }
        }
    }
}
