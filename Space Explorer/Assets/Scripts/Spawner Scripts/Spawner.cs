using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemies;

    private BoxCollider2D box;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        box = GetComponent<BoxCollider2D>();
    }
    void Start()
    {
        StartCoroutine(SpawnerEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnerEnemy()
    {
        yield return new WaitForSeconds(Random.Range(1f, 4f));
        float minX = transform.position.x - (box.bounds.size.x / 2f);
        float maxX = transform.position.x + (box.bounds.size.x / 2f);
        Vector3 spawnPosition = transform.position;
        spawnPosition.x = Random.Range(minX, maxX); // Randomize within bounds

        // Pick a random enemy from the array
        GameObject randomEnemy = enemies[Random.Range(0, enemies.Length)];

        // Spawn the selected enemy
        Instantiate(randomEnemy, spawnPosition, Quaternion.identity);

        StartCoroutine(SpawnerEnemy()); // Restart coroutine
    }
}
