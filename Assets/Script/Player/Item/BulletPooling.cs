using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public GameObject BulletPrefab;
    [SerializeField] private int PoolSize;
    private Queue<GameObject> pool;

    private void Awake()
    {
        pool = new Queue<GameObject>();
        for (int i = 0; i <= PoolSize; i++)
        {
            GameObject obj = Instantiate(BulletPrefab);
            obj.SetActive(false);
            pool.Enqueue(obj);
        }

    }

    public GameObject GetBullet()
    {
        if(pool.Count > 0)
        {
            GameObject obj = pool.Dequeue();
            obj.SetActive(true);
            return obj;
        }
        else
        {
            GameObject obj = Instantiate(BulletPrefab);
            return obj;
        }
    } 
    
    public void ReturnBullet(GameObject obj)
    {
        obj.SetActive(false);
        pool.Enqueue(obj);
    }    
}
