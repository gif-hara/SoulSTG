using System.Threading;
using Cysharp.Threading.Tasks;
using SoulSTG;
using UnityEngine;

namespace HK
{
    /// <summary>
    /// 
    /// </summary>
    public static partial class Extensions
    {
        public static CancellationToken GetLifeTimeToken<T>(this T self) where T : Component
        {
            return TinyServiceLocator.Resolve<GameObjectPool>().TryGetLifeTimeToken(self, out var token) ? token : self.GetCancellationTokenOnDestroy();
        }
    }
}