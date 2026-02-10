using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class AllSpawner : MonoBehaviour
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

    public Tilemap[] tilemaps; // 0=SlimeSpawn, 1=Warrior Spawn, 2=Tank Spawn
    public GameObject[] enemyPrefabs; // 0=Slime, 1=Warrior, 2=Tank
    public float spawnInterval = 3.0f;
    public int maxLiveEnemies = 6;
    // public float gemLifeTime = 10f; 

    private List<Vector3> validSpawnPositions = new List<Vector3>(); // 0=SlimeSpawn, 1=Warrior Spawn, 2=Tank Spawn
    private List<GameObject> spawnObjects = new List<GameObject>();
    private bool isSpawning = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GatherValidPositions()
    {
        validSpawnPositions.Clear();
        BoundsInt boundsInt = tilemaps[0].cellBounds; // Assuming all tilemaps have the same bounds
    }
}