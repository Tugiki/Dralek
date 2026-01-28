using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int maxLiveEnemies = 6;
    public float spawnInterval = 3.0f;
    public GameObject[] enemyPrefab;

    private List<Vector3> spawnPoints = new List<Vector3>();
    private List<GameObject> liveEnemies = new List<GameObject>();
    private bool isSpawning = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnPositions()
    {
        spawnPoints.Clear();
        spawnPoints.Add(new Vector3(-7.5f, -3.5f, 0));
        spawnPoints.Add(new Vector3(7.5f, -3.5f, 0));
        

    }
}
