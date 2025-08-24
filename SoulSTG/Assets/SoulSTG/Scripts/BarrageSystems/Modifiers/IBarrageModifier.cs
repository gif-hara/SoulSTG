using System.Threading;
using Cysharp.Threading.Tasks;
using SoulSTG.ActorControllers;
using UnityEngine;

namespace SoulSTG.BarrageSystems.Modifiers
{
    public interface IBarrageModifier
    {
        UniTask InvokeAsync(Actor owner, Transform spawnPoint, CancellationToken cancellationToken);
    }
}
