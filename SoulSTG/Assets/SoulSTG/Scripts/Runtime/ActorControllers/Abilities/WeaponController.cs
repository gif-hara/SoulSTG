using System.Collections.Generic;
using SoulSTG.WeaponControllers;
using UnityEngine;

namespace SoulSTG.ActorControllers.Abilities
{
    public sealed class WeaponController : IActorAbility
    {
        private Actor actor;

        private readonly HashSet<string> blockedTags = new();

        private List<Weapon> weapons = new();

        public void Activate(Actor actor)
        {
            this.actor = actor;
        }

        public void AddWeapon(Weapon weaponPrefab)
        {
            var weapon = Object.Instantiate(weaponPrefab, actor.transform);
            weapons.Add(weapon);
            weapon.Activate(actor);
        }

        public void InsertWeaponAt(Weapon weaponPrefab, int index)
        {
            var weapon = Object.Instantiate(weaponPrefab, actor.transform);
            weapons.Insert(index, weapon);
            weapon.Activate(actor);
        }

        public bool TryAttack()
        {
            if (blockedTags.Count > 0)
            {
                return false;
            }

            // TODO: 他の武器の攻撃も行えるようにする
            weapons[0].Attack();

            return true;
        }

        public void AddBlockedTag(string tag)
        {
            blockedTags.Add(tag);
        }

        public void RemoveBlockedTag(string tag)
        {
            blockedTags.Remove(tag);
        }
    }
}
