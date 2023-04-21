using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float constantSpawnTime = 5f;
    [SerializeField] private Item[] items;
    [SerializeField] private GameSettings gameSettings;
    
    void Start()
    {
        StartCoroutine(SpawnItem());

    }

    

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnItem()
    {
        //select an item, then spawn
        Instantiate(items[Random.Range(0, items.Length)], transform.position, transform.rotation);
        //minSpawnTime = lower bound for random range, maxSpawnTime = upper bound for random range
        float spawnTime = constantSpawnTime + Random.Range(gameSettings.gameplaySettings.minSpawnTimeModifier, gameSettings.gameplaySettings.maxSpawnTimeModifier);
        if (spawnTime <= 0) spawnTime = 0;
        yield return new WaitForSeconds(spawnTime);
        StartCoroutine(SpawnItem());
    }
}
