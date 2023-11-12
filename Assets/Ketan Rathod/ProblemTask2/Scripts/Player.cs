using ProblemTask1;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProblemTask2
{
    public class Player : MonoBehaviour
    {
        WeaponManager weaponManager;

        [SerializeField] KeyCode WeaponInforMation;

        public static EventHandler<int> OnAmmoUpdate { get; set; }
        public static EventHandler<string> OnWeaponStateUpdate { get; set; }
        public static EventHandler<int> OnTotalMagazineSizeUpdate { get; set; }
        public static EventHandler<IWeaponInfo> OnWeaponChanged { get; set; }


        private void Awake()
        {
            weaponManager = GetComponent<WeaponManager>();
        }
        
        private void Update()
        {
            if (Input.GetKeyDown(WeaponInforMation))
            {   
                if (weaponManager.WeaponInfo!=null)
                {
                        Debug.Log($"Weapon Name {weaponManager.WeaponInfo.Name} \n " +
                            $"Weapon Damage {weaponManager.WeaponInfo.Damage} \n" +
                            $"Weapon MagazineSize {weaponManager.WeaponInfo.MagazineSize} \n" +
                            $"Weapon TotalMagazineSize {weaponManager.WeaponInfo.TotalMagazineSize} \n" +
                            $"Weapon FireRate {weaponManager.WeaponInfo.FireRate}"+
                            $"Weapon Ammo {weaponManager.WeaponInfo.Ammo}");
                    }
                }
        }
    }
}
