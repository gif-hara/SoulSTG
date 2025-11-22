using UnityEngine;

namespace SoulSTG.ActorControllers.OnHitActions
{
    public class GiveDamage : IOnHitAction
    {
        [field: SerializeField]
        private float power;

        public void Invoke(Actor owner, Actor bulletActor, Actor hitActor)
        {
            hitActor.GetAbility<Abilities.Status>().TakeDamage(power);
        }
    }
}
