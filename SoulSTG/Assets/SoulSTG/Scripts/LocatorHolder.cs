using System;
using HK;
using UnityEngine;

namespace SoulSTG
{
    public class LocatorHolder : MonoBehaviour
    {
        [SerializeField]
        private Element.DictionaryList elements;

        public Transform Get(string name)
        {
            return elements.Get(name).Transform;
        }

        [Serializable]
        public class Element
        {
            [SerializeField]
            private Transform transform;
            public Transform Transform => transform;

            [SerializeField]
            private string overrideName;

            [Serializable]
            public class DictionaryList : DictionaryList<string, Element>
            {
                public DictionaryList() : base(x => string.IsNullOrEmpty(x.overrideName) ? x.transform.name : x.overrideName)
                {
                }
            }
        }
    }
}
