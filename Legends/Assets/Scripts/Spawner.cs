using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] private GameObject toSpawn;
    [SerializeField] protected int spawnCount = 0;
    [SerializeField] protected float spawnInterval = 2f;
    [SerializeField] private Transform target;
    // Start is called before the first frame update
    public virtual void Start()
    {
        StartSpawn();
    }

    public virtual void StartSpawn()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            Invoke("SpawnObject", i * spawnCount);
        }
    }

    private void SpawnObject()
    {
        GameObject spawnedObject = Instantiate(toSpawn, transform.position, Quaternion.identity);
        Enemy enemy = spawnedObject.GetComponent<Enemy>();
        enemy.target = target;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
