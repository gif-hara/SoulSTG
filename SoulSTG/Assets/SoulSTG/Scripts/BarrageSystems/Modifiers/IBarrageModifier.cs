using System.Threading;
using Cysharp.Threading.Tasks;
using SoulSTG.ActorControllers;
using UnityEngine;

namespace SoulSTG.BarrageSystems.Modifiers
{
    public interface IBarrageModifier
    {
        UniTask InvokeAsync(Data data);

        public readonly struct Data
        {
            public Actor Owner { get; }
            public Transform SpawnPoint { get; }
            public FloatContainer FloatContainer { get; }
            public CancellationToken CancellationToken { get; }

            public Data(Actor owner, Transform spawnPoint, FloatContainer floatContainer, CancellationToken cancellationToken)
            {
                Owner = owner;
                SpawnPoint = spawnPoint;
                FloatContainer = floatContainer;
                CancellationToken = cancellationToken;
            }
        }
    }
}
