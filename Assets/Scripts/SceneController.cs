using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public BoidController boidPrefab;

    public int spawnBoids = 100;
    public float boidSpeed = 10f;
    public float boidSteeringSpeed = 100f;
    public float boidNoClumpingArea = 10f;
    public float boidLocalArea = 10f;
    public float boidSimulationArea = 50f;

    public float interval = 2f;

    private List<BoidController> _boids;

    public AudioSource soundPlayer;
    public AudioClip[] meows;

    private void Start()
    {
        _boids = new List<BoidController>();

        StartCoroutine(SpawnTimer());        
    }

    private void Update()
    {
        foreach (BoidController boid in _boids)
        {
            boid.SimulateMovement(_boids, Time.deltaTime);

            var boidPos = boid.transform.position;

            if (boidPos.x > boidSimulationArea)
                boidPos.x -= boidSimulationArea * 2;
            else if (boidPos.x < -boidSimulationArea)
                boidPos.x += boidSimulationArea * 2;

            if (boidPos.y > boidSimulationArea)
                boidPos.y -= boidSimulationArea * 2;
            else if (boidPos.y < -boidSimulationArea)
                boidPos.y += boidSimulationArea * 2;

            if (boidPos.z > boidSimulationArea)
                boidPos.z -= boidSimulationArea * 2;
            else if (boidPos.z < -boidSimulationArea)
                boidPos.z += boidSimulationArea * 2;


            boid.transform.position = boidPos;
        }
    }

    IEnumerator SpawnTimer() {
        for (int i = 0; i < spawnBoids; i++)
        {
            yield return new WaitForSeconds(interval);
            SpawnBoid(boidPrefab.gameObject, 0);
        }
    }

    private void SpawnBoid(GameObject prefab, int swarmIndex)
    {
        Meow();

        var boidInstance = Instantiate(prefab);
        boidInstance.transform.localPosition += new Vector3(0, 0, 0);
        //boidInstance.transform.localRotation = Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), 0);

        var boidController = boidInstance.GetComponent<BoidController>();
        boidController.SwarmIndex = swarmIndex;
        boidController.Speed = boidSpeed;
        boidController.SteeringSpeed = boidSteeringSpeed;
        boidController.LocalAreaRadius = boidLocalArea;
        boidController.NoClumpingRadius = boidNoClumpingArea;

        _boids.Add(boidController);
    }
    private void Meow()
    {
        int rand = Random.Range(0, meows.Length);
        soundPlayer.clip = meows[rand];

        soundPlayer.Play();
    }
}
