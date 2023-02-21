using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CollisionAvoidance : MonoBehaviour
{
    public List<GameObject> obstacles;

    private void Awake()
    {
        GetComponent<SphereCollider>().radius = 15;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.CompareTag("Obstacle"))
        {
            obstacles.Add(other.transform.gameObject);
        }
    } 
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.gameObject.CompareTag("Obstacle"))
        {
            obstacles.Remove(other.transform.gameObject);
        }
    }
    
    public Vector3 avgPosCol
    {
        get
        {
            var avg = Vector3.zero;
            if (obstacles.Count == 0) return avg;

            avg = obstacles.Aggregate(avg, (current, t) => current + t.transform.position);
            avg /= obstacles.Count;

            return avg;

        }
    }
}
