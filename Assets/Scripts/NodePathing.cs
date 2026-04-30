using Unity.VisualScripting;
using UnityEngine;

public class NodePathing : MonoBehaviour
{
    public Transform[] nodes; // List of all nodes
    public int nodeIndex = 0;
    private int nodePreviousIndex;
    private Transform target;

    public float moveSpeed = 5f; // How fast the pather moves towards the next node
    public float reachThreshold = 0.2f; // The threshold that must be reached before continuing to the next node

    public bool pathingStopped;
    public bool pathingInverted;
    public bool pathingRandom;

    private void Start()
    {
        target = nodes[nodeIndex];
    }
    void Update()
    {
        Path();
    }

    void Path()
    {
        if (nodes.Length == 0) return; // If there's no nodes, don't do anything
        Vector3 direction = (target.position - transform.position).normalized;

        if (!pathingStopped)
        {
            // Move towards the current node
            transform.position += direction * moveSpeed * Time.deltaTime;
        }

        // Rotate towards movement direction
        if (direction != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, Time.deltaTime * 5f);
        }

        // Check if close enough to go to next node
        if (Vector3.Distance(transform.position, target.position) < reachThreshold)
        {
            nodePreviousIndex = nodeIndex;
            if (pathingRandom)
            {
                int random = Random.Range(0, nodes.Length);
                if (random != nodePreviousIndex)
                {
                    nodeIndex = random;
                }
                else
                {
                    nodeIndex++;
                }
            }
            else
            {
                if (!pathingInverted)
                {
                    nodeIndex++;
                    if (nodeIndex >= nodes.Length)
                    {
                        nodeIndex = 0; // Loop back to start
                    }
                }
                else
                {
                    nodeIndex--;
                    if (nodeIndex < 0)
                    {
                        nodeIndex = nodes.Length - 1; // Loop back to the end
                    }
                }
            }
            
            target = nodes[nodeIndex];
        }
    }
}
