using System.Collections.Generic;
using SoulSTG.ActorControllers.Abilities;
using SoulSTG.MasterDataSystem;
using TNRD;
using UnityEngine;
using UnityEngine.Assertions;

namespace SoulSTG.ActorControllers
{
    public class Actor : MonoBehaviour
    {
#if UNITY_EDITOR
        [ClassesOnly]
#endif
        [SerializeField]
        private List<SerializableInterface<IActorAbility>> abilities = new();

        public readonly ActorEvent Event = new();

        void Awake()
        {
            foreach (var ability in abilities)
            {
                ability.Value.Activate(this);
            }
        }

        public T GetAbility<T>() where T : class, IActorAbility
        {
            foreach (var ability in abilities)
            {
                if (ability.Value is T typedAbility)
                {
                    return typedAbility;
                }
            }

            Assert.IsTrue(false, $"Ability of type {typeof(T)} not found on Actor {name}.");
            return null;
        }

        public bool TryGetAbility<T>(out T ability) where T : class, IActorAbility
        {
            foreach (var a in abilities)
            {
                if (a.Value is T typedAbility)
                {
                    ability = typedAbility;
                    return true;
                }
            }

            ability = null;
            return false;
        }

        public Actor Spawn(ActorSpec spec, Vector3 position, Quaternion rotation)
        {
            var instance = Instantiate(this, position, rotation);
            var weaponController = instance.GetAbility<WeaponController>();
            foreach (var weaponPrefab in spec.InitialWeaponPrefabs)
            {
                weaponController.AddWeapon(weaponPrefab);
            }
            return instance;
        }
    }
}
