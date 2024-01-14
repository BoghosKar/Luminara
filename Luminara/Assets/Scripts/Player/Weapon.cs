using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
public Transform firePoint;
    public int damage = 40;
    public GameObject impactEffect;
    public LineRenderer lineRenderer;
    public AudioSource shootSfx;
    public AudioSource reloadSfx;
    public AudioSource outOfAmmoSfx; // Custom sound effect for out of ammo
    public Animation reloadAnim;
    public Text ammoText;
    public GameObject[] magazines;

    public int bulletsInMagazine = 5;
    public int activeMagazineIndex = 0; // Index of the active magazine
    public bool isReloading = false;
    public bool isOutOfAmmo = false; // Indicates if the player is out of ammo

    public float reloadTime = 2f;

    private void Start()
    {
        UpdateAmmoUI();
    }

    void Update()
    {
        if (Time.timeScale > 0)
        {
            if (Input.GetButtonDown("Fire1") && bulletsInMagazine > 0 && !isReloading && !isOutOfAmmo)
            {
                StartCoroutine(Shoot());
                shootSfx.Play();
            }

            // if (Input.GetKeyDown(KeyCode.R) && bulletsInMagazine == 0 && !isReloading && !isOutOfAmmo)
            // {
            //     StartCoroutine(Reload());
            // }

            if (Input.GetButtonDown("Fire1") && isOutOfAmmo)
            {
                PlayOutOfAmmoSound();
            }
        }
    }

    IEnumerator Shoot()
    {
        bulletsInMagazine--;
        UpdateAmmoUI();

        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right);
        Vector3 endPos;

        if (hitInfo)
        {
            Enemy enemy = hitInfo.transform.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            Instantiate(impactEffect, hitInfo.point, Quaternion.identity);
            endPos = hitInfo.point;
        }
        else
        {
            endPos = firePoint.position + firePoint.right * 100;
        }

        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, endPos);
        lineRenderer.enabled = true;

        yield return new WaitForSeconds(0.05f);

        lineRenderer.enabled = false;

        if (bulletsInMagazine == 0 && !isReloading)
        {
            if (activeMagazineIndex < magazines.Length - 1)
            {
                StartCoroutine(Reload());
            }
            else
            {
                isOutOfAmmo = true;
                ammoText.text = "Out of Ammo";
                magazines[activeMagazineIndex].SetActive(false);
            }
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        reloadAnim.Play();
        reloadSfx.Play();
        yield return new WaitForSeconds(reloadTime); 

        magazines[activeMagazineIndex].SetActive(false);
        activeMagazineIndex++;
        magazines[activeMagazineIndex].SetActive(true);
        bulletsInMagazine = 5;

        isReloading = false;
        UpdateAmmoUI();
    }

    public void UpdateAmmoUI()
    {
        if (!isOutOfAmmo)
        {
            ammoText.text = "Ammo: " + bulletsInMagazine + "/5";
        }
    }

    public void PlayOutOfAmmoSound()
    {
        if (outOfAmmoSfx != null)
        {
            outOfAmmoSfx.Play();
        }
    }
}
