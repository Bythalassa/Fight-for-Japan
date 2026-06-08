using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject EnemyPrefab;
    public float spawnTimer = 3f;
    public float range;

    void Start()
    {
        
    }

    void Update()
    {
        TimerMechanic();
        
    }

    public void TimerMechanic)
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer < 0)
        {
            EnemySpawner();
            spawnTimer = 3;

        }

    }

    public void SpawnEnemy()
    {
        Vector3 randomDir = new Vector3(Random.Range(-1.1f), Random.Range(-1, 1), 0).normalized;

        Vector3 fullLengthDir = randomDir * Random.Range(0f,range);

        GameObject enemy = Instantiate(EnemyPrefab, transform.position, Quaternion.identity);

        enemy.transform.position += fullLengthDir; 
       
    }



}
