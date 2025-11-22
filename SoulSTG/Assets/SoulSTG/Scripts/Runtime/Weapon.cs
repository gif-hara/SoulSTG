using System;
using System.Collections.Generic;
using SoulSTG.ActorControllers;
using SoulSTG.ActorControllers.Abilities;
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

            [field: SerializeField]
            public Vector3 LocalPosition { get; private set; }

            [field: SerializeField]
            public Quaternion LocalRotation { get; private set; }

            [field: SerializeField]
            public Vector3 LocalScale { get; private set; } = Vector3.one;
        }

        public void Activate(Actor actor)
        {
            var locatorHolder = actor.GetAbility<SceneViewController>().SceneView.LocatorHolder;

            foreach (var sceneView in sceneViews)
            {
                var locator = locatorHolder.Get(sceneView.LocatorName);
                sceneView.SceneView.SetParent(locator, false);
                sceneView.SceneView.localPosition = sceneView.LocalPosition;
                sceneView.SceneView.localRotation = sceneView.LocalRotation;
                sceneView.SceneView.localScale = sceneView.LocalScale;
            }
        }
    }
}
