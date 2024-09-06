using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Weapons : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 20f;
    [SerializeField] ParticleSystem flashVFX;
    [SerializeField] GameObject areaHitVFX;
    [SerializeField] GameObject enemyHitVFX;
    [SerializeField] AmmoType ammoType;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] TextMeshProUGUI ammoDisplay;

    bool canShoot = true;
    [SerializeField] float timeBetweenShots = 0.5f;

    private void OnEnable()
    {
        canShoot = true;
    }

    void Update()
    {
        

        if (Input.GetMouseButtonDown(0) && canShoot)
        {
           StartCoroutine(Shoot());
        }
        ammoDisplay.text = ammoSlot.GetAmountOfAmmo(ammoType).ToString();
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        if (ammoSlot.GetAmountOfAmmo(ammoType) > 0)
        {
            ammoSlot.ReduceAmountOfAmmo(ammoType);
            flashVFX.Play();
            ProjectRaycast();
        }
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;
    }

    private void ProjectRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {

            EnemyHealth enemyHealth = hit.transform.GetComponent<EnemyHealth>();
            if (enemyHealth!= null)
            {
                CreateHitVFX(hit, enemyHitVFX);
                enemyHealth.TakeDamage(damage);
            }
            else
            {
                CreateHitVFX(hit, areaHitVFX);
            }

        }
        else
        {
            return;
        }
    }

    private void CreateHitVFX(RaycastHit hit, GameObject hitVFX)
    {
        GameObject impactVFX = Instantiate(hitVFX, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impactVFX, 1f);
    }
}
