using System;
using UnityEngine;

namespace ProblemTask2
{
    public interface IWeaponInfo
    {
        public int Ammo { get; }
        public int Damage { get; }
        public int MagazineSize { get; }
        public int TotalMagazineSize { get; }
        public int FireRate { get; }
        public string Name { get; }
    }

    public interface IWeapon : IWeaponInfo
    {
        public void Fire();
        public void Reload();
    }
}
