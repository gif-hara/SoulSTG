using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using SoulSTG.ActorControllers;
using SoulSTG.ActorControllers.FloatSelectors;
using TNRD;
using UnityEngine;

namespace SoulSTG.BarrageSystems.Modifiers
{
    [Serializable]
    public sealed class RegisterOrUpdateFloatContainer : IBarrageModifier
    {
        [field: SerializeField]
        private Element[] elements;

        public UniTask InvokeAsync(Actor owner, Transform spawnPoint, FloatContainer floatContainer, CancellationToken cancellationToken)
        {
            foreach (var element in elements)
            {
                floatContainer.RegisterOrUpdate(element.Key, element.Selector.Value.GetValue(owner));
            }
            return UniTask.CompletedTask;
        }

        [Serializable]
        public sealed class Element
        {
            [field: SerializeField]
            public string Key { get; private set; }

            [field: SerializeField]
            public SerializableInterface<IFloatSelector> Selector { get; private set; }
        }
    }
}
