using System;
using System.Collections.Generic;
using SoulSTG.ActorControllers;
using UnityEngine;

namespace SoulSTG.WeaponControllers
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField]
        private List<SceneViewElement> sceneViews = new();

        [Serializable]
        public class SceneViewElement
        {
            [field: SerializeField]
            public string LocatorName { get; private set; }

            [field: SerializeField]
            public Transform SceneView { get; private set; }
        }

        public void Activate(Actor actor)
        {
        }
    }
}
