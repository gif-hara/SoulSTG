using System;
using Cysharp.Threading.Tasks;
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

        public UniTask InvokeAsync(IBarrageModifier.Data data)
        {
            foreach (var element in elements)
            {
                data.FloatContainer.RegisterOrUpdate(element.Key, element.Selector.Value.GetValue(data.Owner));
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
