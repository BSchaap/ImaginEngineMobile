using UnityStandardAssets.CrossPlatformInput;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour {
    //Indexes of weapons go from top -> bottom of hierarchy in unity
    public int selectedWeapon = 0;

	// Use this for initialization
	void Start () {
        selectWeapon();
	}
	
	// Update is called once per frame
	void Update () {

        int previousSelectedWeapon = selectedWeapon;

        //Handles changing the weapon
        if (CrossPlatformInputManager.GetButtonDown("Change"))
        {
            if(selectedWeapon >= transform.childCount - 1)
            {
                selectedWeapon = 0;
            }
            else
            {
                selectedWeapon++;
            }
        }
        //Responsible for actually changing the weapons
        if(previousSelectedWeapon != selectedWeapon)
        {
            selectWeapon();
        }

    }
    public void selectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }
}
