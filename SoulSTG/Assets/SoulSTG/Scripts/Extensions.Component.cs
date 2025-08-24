using System.Threading;
using SoulSTG;
using UnityEngine;

namespace HK
{
    /// <summary>
    /// 
    /// </summary>
    public static partial class Extensions
    {
        public static CancellationToken GetLifeTimeToken<T>(this T self) where T : Component => TinyServiceLocator.Resolve<GameObjectPool>().GetLifeTimeToken(self);
    }
}