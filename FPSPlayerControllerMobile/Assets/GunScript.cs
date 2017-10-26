using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;
using UnityEngine;

public class GunScript : MonoBehaviour {

    public float damage = 10f;
    public float range = 200f;
    public float fireRate = 15f;
    private float nextTimeToFire = 0f;

    //for Ammo and reloading
    public int maxAmmo = 10;
    public int currentAmmo;
    public float reloadTime = 1f;
    private bool isReloading = false;
    public Animator animator;

    public GameObject impactEffect;
    public Camera fpsCam;
    //Used to display the ammo
    public Text ammo;

    //Use for initialization
    //only called at start
    void Start()
    {
        currentAmmo = maxAmmo;
    }
    //Called everytime
    //The reason we need this to help the guns reload, without this function the gun will get stuck in relaod if you switch weapons
    void OnEnable()
    { 
        isReloading = false;
        animator.SetBool("Reloading", false);

    }

	// Update is called once per frame
	void Update () {
        ammo.text = "Ammo: " + currentAmmo.ToString() + "/ " + maxAmmo.ToString();
        if (isReloading)
        {
            return;
        }
        if(currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        if (CrossPlatformInputManager.GetButton("Shoot") && Time.time >- nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }

	}
    //Creates a co rountine, we can pause the function, we pause for "reloadTime"
    IEnumerator Reload()
    {
        isReloading = true;
        //Debug.Log("Reloading....");
        animator.SetBool("Reloading", true);
        yield return new WaitForSeconds(reloadTime - 0.25f);
        animator.SetBool("Reloading", false);
        yield return new WaitForSeconds(0.25f);
        currentAmmo = maxAmmo;
        isReloading = false;

    }

    public void Shoot()
    {
        currentAmmo--;
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            //Debug.Log(hit.transform.name);
            //This will creat many objects so we cannot forget to destroy them afterwards
            GameObject impactHit = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactHit, 3f);
        }

    }
    void OnGui()
    {
        GUI.Label(new Rect(-155, 153, 160, 30), "Ammo: " + currentAmmo + "/ " + maxAmmo);
    }
}
