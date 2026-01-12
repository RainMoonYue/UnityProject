using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWayController : MonoBehaviour
{
    [Header("¬∑æ∂…Ë÷√")]
    public Path path;

    [Header("“∆∂Ø Ù–‘")]
    public float moveSpeed = 2f;
    public float arrivalDistance = 0.01f;//≈–∂®æ‡¿Î

    [Header("◊¥Ã¨")]
    [SerializeField] private int currentNodeIndex = 0;
    [SerializeField] private Transform currentNodeTransform;

    private Rigidbody2D rb;

    //public event Action ArrivalEnd;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.position = path.GetTransform(0).position;
        currentNodeTransform = path.GetTransform(++currentNodeIndex);
        //Debug.Log(currentNodeIndex);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentNodeTransform != null)
        {
            CheckNodeArrival();
        }
    }

    private void FixedUpdate()
    {
        MoveTowardsNode();
    }

    private void MoveTowardsNode()
    {
        if (currentNodeTransform == null) return;
        Vector3 targetPosition = currentNodeTransform.position;
        Vector3 direction = (targetPosition - transform.position).normalized;
        //Debug.Log(direction);
        Vector2 velocity = new Vector2(direction.x, direction.y) * moveSpeed;
        //Debug.Log(velocity);
        rb.velocity = velocity;
    }

    void CheckNodeArrival()
    {
        float distanceToNode = Vector3.Distance(transform.position, currentNodeTransform.position);
        //Debug.Log(distanceToNode);
        if (distanceToNode <= arrivalDistance)
        {
            Debug.Log("Arrival!");
            if(ArriveAtNode())
            {
                currentNodeTransform = path.GetTransform(++currentNodeIndex);
            }
            else
            {
                //ArrivalEnd?.Invoke();
                
            }
        }
    }

    bool ArriveAtNode()
    {
        // Õ£÷π“∆∂Ø
        if (rb != null) rb.velocity = Vector2.zero;

        Transform nextNodeTransform = path.GetTransform(currentNodeIndex+1);
        if (nextNodeTransform == null)
        {
            return false;
        }
        return true;
    }
}
