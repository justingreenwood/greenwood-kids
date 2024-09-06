using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    [SerializeField] float deathDelay = 1.0f;
    [SerializeField] ParticleSystem explosionParticles;
    [SerializeField] GameObject playerRenderer;

    void OnTriggerEnter(Collider other)
    {
        Death();
    }

    void Death()
    {
        explosionParticles.Play();
        GetComponent<PlayerControls>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        playerRenderer.GetComponent<MeshRenderer>().enabled = false;
        Invoke("ReloadLevel", deathDelay);
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
