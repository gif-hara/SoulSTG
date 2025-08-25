using Cysharp.Threading.Tasks;
using HK;
using R3;
using R3.Triggers;
using SoulSTG.BarrageSystems;

namespace SoulSTG.ActorControllers.Abilities
{
    public class ActorBulletSystem : IActorAbility
    {
        private Actor actor;

        public BarrageSpawnData BarrageSpawnData;

        private float coolTime;

        public void Activate(Actor actor)
        {
            this.actor = actor;
            this.actor.UpdateAsObservable()
                .Subscribe(this, (_, @this) =>
                {
                    if (@this.coolTime > 0)
                    {
                        @this.coolTime -= UnityEngine.Time.deltaTime;
                    }
                })
                .RegisterTo(actor.GetLifeTimeToken());
        }

        public bool TryFire()
        {
            if (coolTime > 0)
            {
                return false;
            }
            BarrageSpawnData.SpawnAsync(actor).Forget();
            return true;
        }

        public void SetCoolTime(float coolTime)
        {
            this.coolTime = coolTime;
        }
    }
}
