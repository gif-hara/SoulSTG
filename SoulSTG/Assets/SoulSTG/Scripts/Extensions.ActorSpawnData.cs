using SoulSTG;
using SoulSTG.ActorControllers;

namespace HK
{
    /// <summary>
    /// 
    /// </summary>
    public static partial class Extensions
    {
        public static Actor Spawn(this ActorSpawnData self)
        {
            var actor = TinyServiceLocator.Resolve<GameObjectPool>().Rent(self.ActorPrefab);
            return actor;
        }
    }
}