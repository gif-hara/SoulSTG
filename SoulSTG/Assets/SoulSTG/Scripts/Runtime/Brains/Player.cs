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

        private Movement actorMovement;

        public Player(PlayerInput playerInput, Camera camera, PlayerSpec playerSpec)
        {
            this.playerInput = playerInput;
            this.camera = camera;
            this.playerSpec = playerSpec;
        }

        public void Attach(Actor actor, CancellationToken cancellationToken)
        {
            actorMovement = actor.GetAbility<Movement>();

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
            playerInput.actions["Fire"].OnPerformedAsObservable()
                .Subscribe((this, actor), static (_, t) =>
                {
                    var (@this, actor) = t;
                    actor.GetAbility<WeaponController>().TryAttack();
                })
                .RegisterTo(cancellationToken);
            playerInput.actions["Interact"].OnPerformedAsObservable()
                .Subscribe((this, actor), static (_, t) =>
                {
                    Debug.Log("Interact pressed");
                    var (@this, actor) = t;
                    actor.GetAbility<SceneViewController>().SceneView.Animator.SetTrigger("Damage");
                })
                .RegisterTo(cancellationToken);
        }
    }
}
