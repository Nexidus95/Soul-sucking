using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponScript : MonoBehaviour
{
    //bullet
    public GameObject bullet;

    //bullet force
    public float shootForce, upwardForce;

    //Gun stats
    public float timeBetweenShooting, spread, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;

    int bulletsleft, bulletsshot;
    bool shooting, readytoshoot, reloading;

    public Rigidbody player;
    public float recoilForce;

    public Camera fpsCam;
    public Transform attackPoint;

    public bool allowInvoke = true;

    public GameObject muzzleFlash;
    public TextMeshProUGUI ammoDisplay;


    private void Awake()
    {
        bulletsleft = magazineSize;
        readytoshoot = true;
    }

    // Update is called once per frame
    private void Update()
    {
        MyInput();

        if(ammoDisplay != null)
        {
            ammoDisplay.SetText(bulletsleft / bulletsPerTap + "/" + magazineSize / bulletsPerTap);
        }
    }

    private void MyInput()
    {
        if (allowButtonHold)
        {
            shooting = Input.GetKey(KeyCode.Mouse0);
        }
        else
        {
            shooting = Input.GetKeyDown(KeyCode.Mouse0);
        }

        if(Input.GetKeyDown(KeyCode.R) && bulletsleft < magazineSize && !reloading)
        {
            Reload();
        }
        if(readytoshoot && shooting && !reloading && bulletsleft <= 0)
        {
            Reload();
        }

        if(readytoshoot && shooting && !reloading && bulletsleft > 0)
        {
            bulletsshot = 0;

            Shoot();
        }
    }

    private void Shoot()
    {
        readytoshoot = false;

        Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        //Checking if raycast hit something
        Vector3 targetPoint;
        if(Physics.Raycast(ray, out hit))
        {
            targetPoint = hit.point;
        }
        else
        {
            targetPoint = ray.GetPoint(75);
        }

        //calculate direction form attack point to target point
        Vector3 directionWithoutSpread = targetPoint - attackPoint.position;

        //spread calculation
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        //Direction with spread
        Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x, y, 0);

        GameObject currentBullet = Instantiate(bullet, attackPoint.position, Quaternion.identity);
        currentBullet.transform.forward = directionWithSpread.normalized;

        currentBullet.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * shootForce, ForceMode.Impulse);
        currentBullet.GetComponent<Rigidbody>().AddForce(fpsCam.transform.up * upwardForce, ForceMode.Impulse);

        if(muzzleFlash != null)
        {
            Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);
        }

        bulletsleft--;
        bulletsshot++;

        if (allowInvoke)
        {
            Invoke("ResetShot", timeBetweenShooting);
            allowInvoke = false;

            player.AddForce(-directionWithSpread.normalized * recoilForce, ForceMode.Impulse);
        }
        if(bulletsshot < bulletsPerTap && bulletsleft > 0)
        {
            Invoke("Shoot", timeBetweenShots);
        }
    }

    private void ResetShot()
    {
        readytoshoot = true;
        allowInvoke = true;
    }

    private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }

    private void ReloadFinished()
    {
        bulletsleft = magazineSize;
        reloading = false;
    }

}
