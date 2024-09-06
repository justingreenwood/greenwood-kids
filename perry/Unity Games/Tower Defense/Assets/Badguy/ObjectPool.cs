using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{

    [SerializeField] GameObject badguyPrefab;
    [SerializeField][Range(0, 50)] int poolLimit = 5;
    [SerializeField] [Range(0.1f, 30f)] float spawnTimer = 1f;

    GameObject[] pool;

    void Awake()
    {

        FillPool();

    }

    void FillPool()
    {
        pool = new GameObject[poolLimit];

        for(int i = 0; i < pool.Length; i++)
        {
            pool[i]= Instantiate(badguyPrefab, transform);
            pool[i].gameObject.SetActive(false);
        }

    }

    void Start()
    {

        StartCoroutine(SpawnBadguy());
        
    }


    void Update()
    {
        
    }

    void EnableObjects()
    {
        for (int i = 0; i<pool.Length; i++)
        {
            if (pool[i].activeInHierarchy == false)
            {
                pool[i].SetActive(true);
                return;
            }
        }
    }


    IEnumerator SpawnBadguy()
    {
        while (true)
        {
            EnableObjects();
            yield return new WaitForSeconds(spawnTimer);
        }

    }

}
