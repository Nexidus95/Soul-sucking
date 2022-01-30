using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    public GameObject gun;
    public GameObject sword;
    public GameObject soulSucker;

    private WeaponType currentlyEquipped = WeaponType.None;

    void Start()
    {
        GameObject[] weapons = new GameObject[] { gun, sword, soulSucker };
        for(int i = 0; i < 3; i++)
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
                soulSucker.SetActive(false);
                break;
            case WeaponType.SoulSucker:
                gun.SetActive(false);
                sword.SetActive(false);
                soulSucker.SetActive(true);
                break;
            case WeaponType.Gun:
                FindObjectOfType<AudioManager>().Play($"weapon_switch_gun");
                gun.SetActive(true);
                sword.SetActive(false);
                soulSucker.SetActive(false);
                break;
            default:
                gun.SetActive(false);
                sword.SetActive(false);
                soulSucker.SetActive(false);
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
    SoulSucker,
}
