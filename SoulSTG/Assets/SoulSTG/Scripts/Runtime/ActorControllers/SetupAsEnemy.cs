using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using HK;
using R3;
using SoulSTG.ActorControllers.Abilities;
using SoulSTG.ActorControllers.OnDieActions;
using SoulSTG.MasterDataSystem;
using TNRD;
using UnityEngine;
using VitalRouter.R3;

namespace SoulSTG.ActorControllers
{
    public class SetupAsEnemy : MonoBehaviour
    {
        [field: SerializeField]
        private Actor actor;

        [field: SerializeField]
        private string actorSpecId;

#if UNITY_EDITOR
        [ClassesOnly]
#endif
        [field: SerializeField]
        private List<SerializableInterface<IOnDieAction>> onDieActions;

        void Start()
        {
            actor.AddAbility(new Status(TinyServiceLocator.Resolve<MasterData>().ActorSpecs.Get(actorSpecId)));
            actor.Event.Router.AsObservable<ActorEvent.OnDie>()
                .Subscribe((this, actor), static (evt, t) =>
                {
                    var (@this, actor) = t;
                    @this.InvokeOnDieActionsAsync(actor, actor.GetLifeTimeToken()).Forget();
                }
            )
            .RegisterTo(actor.GetLifeTimeToken());
        }

        private async UniTask InvokeOnDieActionsAsync(Actor actor, CancellationToken cancellationToken)
        {
            foreach (var action in onDieActions)
            {
                await action.Value.InvokeAsync(actor, cancellationToken);
            }

        }

#if UNITY_EDITOR
        void OnValidate()
        {
            actor = GetComponent<Actor>();
        }
#endif
    }
}
