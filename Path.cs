using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    [Header("路径节点")]
    [SerializeField] private List<Transform> waypoints = new List<Transform>();

    [Header("视觉设定")]
    public Color gizmoColor = Color.red;
    public float gizmoRadius = 0.2f;
    private void Awake()
    {
        //CollectWayPointsFromChildren(waypoints);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public Transform GetTransform(int index)
    {
        if (index < 0 || index >= waypoints.Count) return null;
        return waypoints[index];
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        for (int i = 0; i < waypoints.Count; i++)
        {
            if (waypoints[i] == null) continue;
               Gizmos.DrawSphere(waypoints[i].position, gizmoRadius);
            if (i < waypoints.Count - 1 && waypoints[i + 1] != null)
            {
                Gizmos.DrawLine(waypoints[i].position, waypoints[i+1].position);

            }

        }
    }
}
