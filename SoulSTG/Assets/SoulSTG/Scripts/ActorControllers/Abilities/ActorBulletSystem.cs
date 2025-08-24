using HK;
using UnityEngine.Assertions;

namespace SoulSTG.ActorControllers.Abilities
{
    public class ActorBulletSystem : IActorAbility
    {
        private Actor actor;

        private GameObjectPool gameObjectPool;

        public Actor bulletPrefab;

        public void Activate(Actor actor)
        {
            this.actor = actor;
            gameObjectPool = TinyServiceLocator.Resolve<GameObjectPool>();
        }

        public bool TryFire()
        {
            var bullet = gameObjectPool.Rent(bulletPrefab);
            Assert.IsNotNull(bullet);
            bullet.transform.position = actor.transform.position;
            bullet.transform.rotation = actor.transform.rotation;
            return true;
        }
    }
}
