using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class PlayerControls : MonoBehaviour
{
    [Header("General Setup Settings")]
    [Tooltip("The speed the ship moves from player input")]
    [SerializeField] float controlSpeed = 25f;
    [Tooltip("The distance the ship can move left and right")][SerializeField] float xRange = 10f;
    [Tooltip("The distance the ship can move up and down")][SerializeField] float yRange = 8f;

    [Header("Screen position based tuning")]

    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float positionYawFactor = -1.5f;

    [Header("Player input based tuning")]
    [SerializeField] float controlPitchFactor = -20f;
    [SerializeField] float controlRollFactor = -25f;

    [Header("Laser gun array")]
    [Tooltip("Add all player lasers here")][SerializeField] GameObject[] lasers;

    float xThrow, yThrow;


    void Update()
    {

        ProcessTranslation();
        ProcessRotation();
        ProcessFire();

    }

    void ProcessRotation()
    {
        float pitchFromPosition = transform.localPosition.y * positionPitchFactor;
        float pitchFromControl = yThrow * controlPitchFactor;
        float pitch = pitchFromControl + pitchFromPosition;


        float yaw = transform.localPosition.x * positionYawFactor;

        float roll = xThrow*controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    void ProcessTranslation()
    {
        xThrow = Input.GetAxis("Horizontal");
        float xOffset = controlSpeed * xThrow * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        yThrow = Input.GetAxis("Vertical");
        float yOffset = controlSpeed * yThrow * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);


        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

    void ProcessFire()
    {

        if (Input.GetButton("Fire1"))
        {
            LaserActivation(true);
        }
        else
        {
            LaserActivation(false);
        }

    }

    void LaserActivation(bool isActivated)
    {

        foreach(GameObject laser in lasers)
        {

            var laserEmission = laser.GetComponent<ParticleSystem>().emission;
            laserEmission.enabled = isActivated;
            //laser.SetActive(isActivated);
            
        }
        
    }

}
