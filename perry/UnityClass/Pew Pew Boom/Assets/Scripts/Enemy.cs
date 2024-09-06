using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] GameObject hitVFX;
    [SerializeField] int points = 1;
    [SerializeField] float hitPoints = 2;

    GameObject parentGameObject;
    ScoreBoard scoreboard;
    void Start()
    {
        scoreboard = FindObjectOfType<ScoreBoard>();

        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
        parentGameObject = GameObject.FindWithTag("SpawnAtRuntime");
    }

    void OnParticleCollision(GameObject other)
    {
        hitPoints--;
        //scoreboard.IncreaseScore(points);
        if (hitPoints < 0.1)
        {
            DeathSequence();
        }
        else
        {
            InstatiateVFX(hitVFX);
        }
    }

    void DeathSequence()
    {
        
        scoreboard.IncreaseScore(points);
        InstatiateVFX(deathVFX);
        Destroy(gameObject);
    }

    void InstatiateVFX(GameObject VFX)
    {
        GameObject vfx = Instantiate(VFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parentGameObject.transform;
    }

}
