using System.Collections.Generic;

namespace SoulSTG.ActorControllers.Abilities
{
    public sealed class WeaponController : IActorAbility
    {
        private Actor actor;

        private readonly HashSet<string> blockedTags = new();

        public void Activate(Actor actor)
        {
            this.actor = actor;
        }

        public bool TryAttack()
        {
            if (blockedTags.Count > 0)
            {
                return false;
            }


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
