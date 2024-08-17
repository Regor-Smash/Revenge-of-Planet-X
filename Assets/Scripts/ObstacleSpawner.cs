using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField]
    private WeightedList obstacles;

    private bool spawning = true;
    private Bounds spawnBounds;
    
    private void Start()
    {
        spawnBounds = GetComponent<Collider2D>().bounds;
        StartCoroutine(SpawningTimer());
    }

    private IEnumerator SpawningTimer()
    {
        while (spawning)
        {
            SpawnObstacle();
            yield return new WaitForSeconds(1f);
        }
    }

    private void SpawnObstacle()
    {
        GameObject obstacle = obstacles.Choose();
        //Spawns an obstacle somewhere on the bound's vertical center line
        float spawnX = spawnBounds.center.x;//Random.Range(spawnBounds.min.x, spawnBounds.max.x);
        float spawnY = Random.Range(spawnBounds.min.y, spawnBounds.max.y);
        Vector3 spawnPos = new Vector3(spawnX, spawnY);
        Instantiate<GameObject>(obstacle, spawnPos, Quaternion.identity, transform);
    }
}
