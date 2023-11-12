using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProblemTask2
{
    [CreateAssetMenu(fileName ="Weapon",menuName ="ProblemTask2/Create New Weapon")]
    public class Weapon : ScriptableObject, IWeapon
    {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public int Damage { get; private set; }
        [field: SerializeField] public int MagazineSize { get; private set; }
        [field: SerializeField] public int TotalMagazineSize { get; private set; }
        [field: SerializeField] public int FireRate { get; private set; }
        [field: SerializeField] public int Ammo { get; private set; }

        int tempFiring = 0;

        public Weapon(string name, int damage, int magazineSize, int totalMagazineSize, int fireRate, int ammo)
        {
            Name = name;
            Damage = damage;
            MagazineSize = magazineSize;
            TotalMagazineSize = totalMagazineSize;
            FireRate = fireRate;
            Ammo = ammo;
        }
        public Weapon()
        {

        }
        public Weapon(Weapon weapon)
        {
            Name = weapon.Name;
            Damage = weapon.Damage;
            MagazineSize = weapon.MagazineSize;
            TotalMagazineSize=weapon.TotalMagazineSize;
            FireRate=weapon.FireRate;
            Ammo=weapon.Ammo;
        }

        public void Fire()
        {
            if (Ammo > 0)
            {
                tempFiring++;

                if (tempFiring >= FireRate)
                {
                    tempFiring = 0;
                    Ammo--;
                    Player.OnAmmoUpdate?.Invoke(this, Ammo);
                }
            }
            else
            {
                Player.OnWeaponStateUpdate?.Invoke(this, "Please Reload Your Weapon!");
            }

        }

        public void Reload()
        {
            tempFiring = 0;
            
            if (TotalMagazineSize <= 0)
            {
                Player.OnWeaponStateUpdate?.Invoke(this, "Reload faild! No Magazine Found");
                return;  
            }

            Ammo = MagazineSize;
            TotalMagazineSize -= MagazineSize;

            Player.OnWeaponStateUpdate?.Invoke(this, "Reload done");
            Player.OnAmmoUpdate?.Invoke(this, Ammo);
            Player.OnTotalMagazineSizeUpdate?.Invoke(this, TotalMagazineSize);
        }
    }
}
