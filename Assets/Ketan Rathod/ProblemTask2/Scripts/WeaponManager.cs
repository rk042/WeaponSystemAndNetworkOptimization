using ProblemTask2;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProblemTask1
{
    public class WeaponManager : MonoBehaviour
    {
        [field: SerializeField] Weapon weaponPrimaryOne { get; set; }
        [field: SerializeField] Weapon weaponPrimaryTwo { get; set; }
        [field: SerializeField] Weapon weaponSecondary { get; set; }

        [SerializeField] KeyCode ReadloadKey = KeyCode.R;
        [SerializeField] KeyCode SwipePrimaryWeapon = KeyCode.Alpha1;
        [SerializeField] KeyCode SwipeToSecondaryWeapon = KeyCode.Alpha2;

        Weapon SelectedWeapon;
        Weapon _weaponPrimaryOne;
        Weapon _weaponPrimaryTwo;
        Weapon _weaponSecondary;

        public IWeapon WeaponInfo { get; private set; }
      
        private void Awake()
        {
            _weaponPrimaryOne = new(weaponPrimaryOne);
            _weaponPrimaryTwo = new(weaponPrimaryTwo);
            _weaponSecondary = new(weaponSecondary);

            SelectedWeapon = _weaponPrimaryOne;
            WeaponInfo = SelectedWeapon;
        }
        

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(SwipePrimaryWeapon))
            {
                if (SelectedWeapon == _weaponPrimaryOne || SelectedWeapon == _weaponSecondary)
                {
                    ChangeWeapon(_weaponPrimaryTwo);
                }
                else if (SelectedWeapon == _weaponPrimaryTwo || SelectedWeapon == _weaponSecondary)
                {
                    ChangeWeapon(_weaponPrimaryOne);
                }
            }

            if (Input.GetKeyDown(SwipeToSecondaryWeapon))
            {
                if (SelectedWeapon != _weaponSecondary)
                {
                    ChangeWeapon(_weaponSecondary);
                }
                else
                {
                    Debug.Log("Already Secondary Weapon is selected!");
                }
            }

            if (Input.GetKeyDown(ReadloadKey))
            {
                SelectedWeapon.Reload();
            }

            if (Input.GetMouseButton(0))
            {
                SelectedWeapon.Fire();
            }
        }

        private void ChangeWeapon(Weapon weapon)
        {
            SelectedWeapon = weapon;
            WeaponInfo = SelectedWeapon;
            Player.OnWeaponChanged?.Invoke(this, weapon);
        }
    }
}
