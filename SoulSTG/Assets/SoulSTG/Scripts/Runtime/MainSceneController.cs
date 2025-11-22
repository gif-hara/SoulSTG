using HK;
using R3;
using SoulSTG.ActorControllers;
using SoulSTG.ActorControllers.Abilities;
using SoulSTG.ActorControllers.Brains;
using SoulSTG.MasterDataSystem;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SoulSTG
{
    public class MainSceneController : MonoBehaviour
    {
        [field: SerializeField]
        private MasterData masterData;

        [SerializeField]
        private string playerActorSpecId;

        [field: SerializeField]
        private Actor playerPrefab;

        [field: SerializeField]
        private Transform spawnPoint;

        [field: SerializeField]
        private PlayerInput playerInputPrefab;

        [field: SerializeField]
        private WorldCameraController worldCameraControllerPrefab;

        void Awake()
        {
            Application.targetFrameRate = 60;
            TinyServiceLocator.Register(new GameObjectPool())
                .RegisterTo(destroyCancellationToken);
            TinyServiceLocator.Register(masterData)
                .RegisterTo(destroyCancellationToken);
            var worldCameraController = Instantiate(worldCameraControllerPrefab);
            var player = playerPrefab.Spawn(masterData.ActorSpecs.Get(playerActorSpecId), spawnPoint.position, spawnPoint.rotation);
            var playerInput = Instantiate(playerInputPrefab);
            var brainController = player.GetAbility<Brain>();
            brainController.Attach(new Player(playerInput, worldCameraController.WorldCamera, masterData.PlayerSpec));
            worldCameraController.SetDefaultCameraTarget(player.transform);
        }
    }
}
