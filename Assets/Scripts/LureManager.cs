using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LureManager : MonoBehaviour
{

    public GameObject BoidSpawner;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SendInfo(Vector3 Position, string tag) {
        
        //concatinating the 2 arrays
        GameObject[] temp1 = GameObject.FindGameObjectsWithTag(tag);
        GameObject[] temp2 = GameObject.FindGameObjectsWithTag("all");
        GameObject[] Boids = new GameObject[temp1.Length + temp2.Length];

        temp1.CopyTo(Boids, 0);
        temp2.CopyTo(Boids, temp1.Length);


        foreach (GameObject boid in Boids) {
            var BoidController = boid.GetComponent<BoidController>();
            BoidController.SetTargetPoint(Position);
            //Debug.Log("Lure info sent out!");
        }
    }

    public void RemoveInfo(Vector3 Position, string tag) {
        
        //concatinating the 2 arrays
        GameObject[] temp1 = GameObject.FindGameObjectsWithTag(tag);
        GameObject[] temp2 = GameObject.FindGameObjectsWithTag("all");
        GameObject[] Boids = new GameObject[temp1.Length + temp2.Length];

        temp1.CopyTo(Boids, 0);
        temp2.CopyTo(Boids, temp1.Length);

        foreach (GameObject boid in Boids) {
            var BoidController = boid.GetComponent<BoidController>();
            BoidController.RemoveTargetPoint(Position);
            Debug.Log("Lure info no longer sent out!");
        }
    }
}
