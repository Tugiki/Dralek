using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemySpawner : MonoBehaviour
{
    public enum EnemyType
    {
        Slime,
        Warrior,
        Tank
    }

    public enum TileMapType
    {
        SlimeSpawn,
        WarriorSpawn,
        TankSpawn
    }

    
    public Tilemap tilemap;
    public int maxLiveEnemies = 6;
    public float spawnInterval = 3.0f;
    public GameObject[] enemyPrefab;

    private List<Vector3> spawnPoints = new List<Vector3>();
    private List<GameObject> liveEnemies = new List<GameObject>();
    private bool isSpawning = false;

    void Start()
    {
        SpawnPositions();
        StartCoroutine(SpawnObjectsIfNeeded());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private int ActiveEnemyCount()
    {
        liveEnemies.RemoveAll(item => item == null);
        return liveEnemies.Count;
    }
    private IEnumerator SpawnObjectsIfNeeded()
    {
        isSpawning = true;
        while(ActiveEnemyCount() < maxLiveEnemies)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnInterval);
        }
        isSpawning = false;
    }

    private bool PositionHasEnemy(Vector3 positionCheck)
    {
        return liveEnemies.Any(checkObj => checkObj != null && Vector3.Distance(checkObj.transform.position, positionCheck) < 1.0f);
    }

    private EnemyType RandomEnemyType()
    {
        float randomChoice = Random.value;
         /* Düzenlenecek */
        return EnemyType.Slime;
    }
    private void SpawnEnemy()
    {
        if (spawnPoints.Count == 0) return;

        Vector3 spawnPosition = Vector3.zero;
        bool validPositionFound = false;

        while(!validPositionFound && spawnPoints.Count > 0)
        {
            int randomIndex = Random.Range(0, spawnPoints.Count);
            Vector3 potentialPosition = spawnPoints[randomIndex];
            Vector3 leftPosition = potentialPosition + Vector3.left;
            Vector3 rightPosition = potentialPosition + Vector3.right;

            if(!PositionHasEnemy(leftPosition) && !PositionHasEnemy(rightPosition))
            {
                spawnPosition = potentialPosition;
                validPositionFound = true;
            }
            else
            {
                spawnPoints.RemoveAt(randomIndex);
            }
        }

        if(validPositionFound)
        {
            EnemyType enemyType = RandomEnemyType();
            GameObject gameObject = Instantiate(enemyPrefab[(int)enemyType], spawnPosition, Quaternion.identity);
            liveEnemies.Add(gameObject);
        }
    }

    private void SpawnPositions()
    {
        spawnPoints.Clear();
        BoundsInt boundsInt = tilemap.cellBounds;
        TileBase[] allTiles = tilemap.GetTilesBlock(boundsInt);
        Vector3 start = tilemap.CellToWorld(new Vector3Int(boundsInt.xMin, boundsInt.yMin, 0));
        
        for(int x = 0; x < boundsInt.size.x; x++)
        {
            for(int y = 0; y < boundsInt.size.y; y++)
            {
                TileBase tile = allTiles[x + y * boundsInt.size.x];
                if(tile != null)
                {
                    Vector3 place = start + new Vector3(x + 0.5f, y, 0);
                    spawnPoints.Add(place);
                }
            }
        }


    }
}
