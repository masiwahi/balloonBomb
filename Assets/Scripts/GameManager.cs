using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject enemyPrefab;   // 积己且 利 橇府普
    public float spawnInterval = 10f; // 积己 埃拜(檬)
    public int spawnCount = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnEnemy()
    {
        spawnCount++;
        Instantiate(enemyPrefab, new Vector3(22.5f,1,22.5f), transform.rotation);

        if(spawnCount > 10 && spawnInterval > 1f)
        {
            spawnCount = 0;
            spawnInterval -= 0.5f;
        }
    }
}
