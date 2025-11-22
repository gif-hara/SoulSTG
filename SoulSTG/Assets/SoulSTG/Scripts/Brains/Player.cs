using System.Threading;
using HK;
using R3;
using R3.Triggers;
using SoulSTG.ActorControllers.Abilities;
using SoulSTG.MasterDataSystem;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SoulSTG.ActorControllers.Brains
{
    public sealed class Player : IActorBrain
    {
        private readonly PlayerInput playerInput;

        private readonly Camera camera;

        private readonly PlayerSpec playerSpec;

        private ActorMovement actorMovement;

        private bool isFiring;

        public Player(PlayerInput playerInput, Camera camera, PlayerSpec playerSpec)
        {
            this.playerInput = playerInput;
            this.camera = camera;
            this.playerSpec = playerSpec;
        }

        public void Attach(Actor actor, CancellationToken cancellationToken)
        {
            actor.AddAbility<ActorTime>();
            actorMovement = actor.AddAbility<ActorMovement>();

            actorMovement.SetRotationSpeed(playerSpec.RotateSpeed);
            actor.UpdateAsObservable()
                .Subscribe((this, actor), static (_, t) =>
                {
                    var (@this, actor) = t;
                    var moveInput = @this.playerInput.actions["Move"].ReadValue<Vector2>();
                    @this.actorMovement.Move(moveInput * @this.playerSpec.MoveSpeed);
                    if (moveInput != Vector2.zero)
                    {
                        var direction = Quaternion.LookRotation(Vector3.forward, moveInput);
                        @this.actorMovement.Rotate(direction);
                    }
                })
                .RegisterTo(cancellationToken);
        }
    }
}
