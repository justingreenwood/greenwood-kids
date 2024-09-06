using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] float mainThrust = 1000f;
    [SerializeField] float rotationThrust = 100f;
    [SerializeField] AudioClip mainThrustAudio;

    [SerializeField] ParticleSystem mainThrustParticles;
    [SerializeField] ParticleSystem leftThrustParticles;
    [SerializeField] ParticleSystem rightThrustParticles;

    Rigidbody rb;
    AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {

        ProcessThrust();
        ProcessRotate();

    }

    void ProcessThrust()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }

    }

    void ProcessRotate()
    {
        var thrust = Vector3.forward * rotationThrust * Time.deltaTime;
        if (Input.GetKey(KeyCode.A))
        {
            RotateLeft();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RotateRight();
        }
        else
        {
            EndRotationParticles();
        }


    }
    void StartThrusting()
    {
        if (audioSource.isPlaying == false)
        {
            audioSource.PlayOneShot(mainThrustAudio);
            mainThrustParticles.Play();
        }
        rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
    }

    void StopThrusting()
    {
        audioSource.Stop();
        mainThrustParticles.Stop();
    }

    void RotateRight()
    {
        if (leftThrustParticles.isPlaying == false)
        {
            rightThrustParticles.Stop();
            leftThrustParticles.Play();
        }
        TransformRotate(-rotationThrust);
    }

    void RotateLeft()
    {
        if (rightThrustParticles.isPlaying == false)
        {
            leftThrustParticles.Stop();
            rightThrustParticles.Play();
        }
        TransformRotate(rotationThrust);
    }
    void EndRotationParticles()
    {
        if (rightThrustParticles.isPlaying || leftThrustParticles.isPlaying)
        {
            leftThrustParticles.Stop();
            rightThrustParticles.Stop();
        }
    }

    void TransformRotate(float rotationThisFrame)
    {
        rb.freezeRotation = true; // freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false;
    }
}
