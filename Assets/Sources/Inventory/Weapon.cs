using System;
using NUnit.Framework;
using UnityEngine;

namespace Sources.Inventory
{
    public abstract class Weapon: MonoBehaviour, IWeapon
    {
        public string Name { get; }

        public abstract void Attack();
    }
}