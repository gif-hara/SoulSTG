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
                    var camTransform = @this.camera.transform;
                    var forward = camTransform.forward;
                    var right = camTransform.right;
                    forward.y = 0;
                    right.y = 0;
                    forward.Normalize();
                    right.Normalize();
                    var moveVelocity = right * moveInput.x + forward * moveInput.y;
                    @this.actorMovement.Move(moveVelocity * @this.playerSpec.MoveSpeed);
                })
                .RegisterTo(cancellationToken);
        }
    }
}
