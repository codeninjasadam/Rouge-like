using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class WeaponManager : MonoBehaviour
{
    public List<Weapon> equippedWeapons = new List<Weapon>();

    void Update()
    {
        foreach (Weapon w in equippedWeapons)
        {
            if (w != null)
            {
                w.HandleWeapon();
            }
        }
    }

    public void AddWeapon(Weapon newWeapon)
    {
        equippedWeapons.Add(newWeapon);
    }
}
