using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //This is a Singleton of the BoidSpawner. there is only one instance 
    // of BoidSpawner, so we can store it in a static variable named s.
    public static Spawner       S;
    public static List<Boid>    boids;

    // These fields allow you to adjust the spawning behavior of the boids
    [Header("Set in Inspector: Spawning")]
    public GameObject[]           boidPrefab;
    public Transform            boidAnchor;
    public int                  numBoids = 100;
    public float                spawnRadius = 100f;
    public float                spawnDelay = 0.1f;

    // These fields allow you to adjust the flocking behavior of the boids
    [Header("Set in Inspector: Boids")]
    public float                velocity = 30f;
    public float                neighborDist = 30f;
    public float                collDist = 4f;
    public float                velMatching = 0.25f;
    public float                flockCentering = 0.2f;
    public float                collAvoid = 2f;
    public float                attractPull = 2f;
    public float                attractPush = 2f;
    public float                attractPushDist = 5f;

    private int _boidIndex; // Keeps track of the index of spawned boids
    private void Awake()
    {
        //Set the Singleton S to be this instance of BoidSpawner
        S = this;
        //Start instantiation of the Boids
        _boidIndex = 0;
        boids = new List<Boid>();
        InstantiateBoid();
    }

    public void InstantiateBoid()
    {
        
        GameObject go = Instantiate(boidPrefab[BoidIndex()]);
        Boid b = go.GetComponent<Boid>();
        b.transform.SetParent(boidAnchor);
        boids.Add(b);
        if (boids.Count < numBoids)
        {
            Invoke("InstantiateBoid", spawnDelay);
        }

        _boidIndex++; // increases spawn index by one after spawning 
    }

    private int BoidIndex() //Makes Sure the index to spawn doesnt go over the length of spawnables 
    {
        return _boidIndex = Mathf.Clamp(_boidIndex, 0, boidPrefab.Length - 1);
    }
}