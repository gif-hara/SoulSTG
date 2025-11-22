using HK;

namespace SoulSTG.ActorControllers.OnHitActions
{
    public class ReleaseToPoolBulletActor : IOnHitAction
    {
        public void Invoke(Actor owner, Actor bulletActor, Actor hitActor)
        {
            TinyServiceLocator.Resolve<GameObjectPool>().Release(bulletActor);
        }
    }
}
