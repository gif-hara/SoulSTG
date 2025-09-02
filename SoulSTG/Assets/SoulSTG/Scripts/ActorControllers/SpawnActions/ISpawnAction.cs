using System.Threading;
using Cysharp.Threading.Tasks;

namespace SoulSTG.ActorControllers.SpawnActions
{
    public interface ISpawnAction
    {
        UniTask InvokeAsync(Data data);

        public readonly struct Data
        {
            public Actor Owner { get; }
            public Actor SpawnedActor { get; }
            public FloatContainer FloatContainer { get; }
            public CancellationToken CancellationToken { get; }

            public Data(Actor owner, Actor spawnedActor, FloatContainer floatContainer, CancellationToken cancellationToken)
            {
                Owner = owner;
                SpawnedActor = spawnedActor;
                FloatContainer = floatContainer;
                CancellationToken = cancellationToken;
            }
        }
    }
}
