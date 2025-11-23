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

        private Dictionary<System.Type, IActorAbility> cachedAbilities = new();

        void Awake()
        {
            foreach (var ability in abilities)
            {
                ability.Value.Activate(this);
                cachedAbilities[ability.Value.GetType()] = ability.Value;
            }
        }

        public T GetAbility<T>() where T : class, IActorAbility
        {
            if (cachedAbilities.TryGetValue(typeof(T), out var ability))
            {
                return (T)ability;
            }

            Assert.IsTrue(false, $"Ability of type {typeof(T)} not found on Actor {name}.");
            return null;
        }

        public bool TryGetAbility<T>(out T ability) where T : class, IActorAbility
        {
            if (cachedAbilities.TryGetValue(typeof(T), out var foundAbility))
            {
                ability = (T)foundAbility;
                return true;
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
