using ProblemTask1;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProblemTask2
{
    public class EquipmentsUI : MonoBehaviour
    {
    
        private void OnEnable()
        {
            Player.OnTotalMagazineSizeUpdate += OnTotalMagazineSizeUpdate;
            Player.OnWeaponStateUpdate += OnWeaponStateUpdate;
            Player.OnAmmoUpdate += OnAmmoUpdate;
            Player.OnWeaponChanged += OnWeaponChanged;
        }

        private void OnDisable()
        {
            Player.OnTotalMagazineSizeUpdate -= OnTotalMagazineSizeUpdate;
            Player.OnWeaponStateUpdate -= OnWeaponStateUpdate;
            Player.OnAmmoUpdate -= OnAmmoUpdate;
            Player.OnWeaponChanged -= OnWeaponChanged;
        }

        private void OnWeaponChanged(object sender, IWeaponInfo e)
        {
            Debug.Log($"Weapon has changed to {e.Name}");
        }

        private void OnAmmoUpdate(object sender, int e)
        {
            Debug.Log($"Ammo Size {e}");
        }

        private void OnWeaponStateUpdate(object sender, string e)
        {
            Debug.LogError(e);
        }

        private void OnTotalMagazineSizeUpdate(object sender, int e)
        {
            Debug.Log($"Magazine Size {e}");
        }
    }
}
