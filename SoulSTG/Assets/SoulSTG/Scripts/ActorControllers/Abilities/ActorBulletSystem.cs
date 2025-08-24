using HK;
using UnityEngine.Assertions;

namespace SoulSTG.ActorControllers.Abilities
{
    public class ActorBulletSystem : IActorAbility
    {
        private Actor actor;

        private GameObjectPool gameObjectPool;

        public ActorSpawnData SpawnData;

        public void Activate(Actor actor)
        {
            this.actor = actor;
            gameObjectPool = TinyServiceLocator.Resolve<GameObjectPool>();
        }

        public bool TryFire()
        {
            var bullet = SpawnData.Spawn();
            Assert.IsNotNull(bullet);
            bullet.transform.position = actor.transform.position;
            bullet.transform.rotation = actor.transform.rotation;
            return true;
        }
    }
}
