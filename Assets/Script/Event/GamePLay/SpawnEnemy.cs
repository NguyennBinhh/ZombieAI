using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject PrefabEnemy;

    public int CountEnemy = 0;
    public int CountEnemyKilled = 0;
    public void Spawn(Vector3 PostionSpawn, int Quantity)
    {
        int Count = 0;
        if (Count <= Quantity)
        {
            Instantiate(PrefabEnemy, PostionSpawn, Quaternion.identity);
            CountEnemy++;
        }
    }    
    
}
