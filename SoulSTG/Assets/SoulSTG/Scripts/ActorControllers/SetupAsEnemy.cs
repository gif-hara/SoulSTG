using HK;
using SoulSTG.ActorControllers.Abilities;
using SoulSTG.MasterDataSystem;
using UnityEngine;

namespace SoulSTG.ActorControllers
{
    public class SetupAsEnemy : MonoBehaviour
    {
        [field: SerializeField]
        private Actor actor;

        [field: SerializeField]
        private string actorSpecId;

        void Start()
        {
            actor.AddAbility(new ActorStatus(TinyServiceLocator.Resolve<MasterData>().ActorSpecs.Get(actorSpecId)));
        }

#if UNITY_EDITOR
        void OnValidate()
        {
            actor = GetComponent<Actor>();
        }
#endif
    }
}
