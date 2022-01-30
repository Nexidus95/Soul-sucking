using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    public GameObject gun;
    public GameObject sword;

    private WeaponType currentlyEquipped = WeaponType.None;

    void Start()
    {
        GameObject[] weapons = new GameObject[] { gun, sword };
        for(int i = 0; i < 2; i++)
        {
            if(weapons[i].activeSelf)
            {
                currentlyEquipped = (WeaponType) i+1;
                SwitchWeapon(currentlyEquipped);
                return;
            }
        }
        SwitchWeapon(WeaponType.Gun);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            CycleWeapon();
        }
    }

    private void SwitchWeapon(WeaponType weaponType)
    {
        currentlyEquipped = weaponType;
        switch (weaponType)
        {
            case WeaponType.Sword:
                FindObjectOfType<AudioManager>().Play($"weapon_switch_sword");
                gun.SetActive(false);
                sword.SetActive(true);
                break;
            case WeaponType.Gun:
                FindObjectOfType<AudioManager>().Play($"weapon_switch_gun");
                gun.SetActive(true);
                sword.SetActive(false);
                break;
            default:
                gun.SetActive(false);
                sword.SetActive(false);
                break;
        }
    }

    public void CycleWeapon()
    {
        switch (currentlyEquipped)
        {
            case WeaponType.Gun:
                SwitchWeapon(WeaponType.Sword);
                break;
            case WeaponType.Sword:
                SwitchWeapon(WeaponType.Gun);
                break;
            default:
                SwitchWeapon(WeaponType.Gun);
                break;
        }
    }
}
public enum WeaponType
{
    None = 0,
    Gun,
    Sword,
}
