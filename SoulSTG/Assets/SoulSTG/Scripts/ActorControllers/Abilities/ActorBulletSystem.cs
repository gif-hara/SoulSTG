using Cysharp.Threading.Tasks;
using HK;
using UnityEngine.Assertions;

namespace SoulSTG.ActorControllers.Abilities
{
    public class ActorBulletSystem : IActorAbility
    {
        private Actor actor;

        private GameObjectPool gameObjectPool;

        public ActorSpawnData SpawnData;

        private readonly Container cachedContainer = new();

        public void Activate(Actor actor)
        {
            this.actor = actor;
            gameObjectPool = TinyServiceLocator.Resolve<GameObjectPool>();
        }

        public bool TryFire()
        {
            SpawnData.SpawnAsync(cachedContainer).Forget();
            return true;
        }
    }
}
