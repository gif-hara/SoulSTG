using R3;
using R3.Triggers;
using UnityEngine;

namespace SoulSTG.ActorControllers.Abilities
{
    public class ActorMovement : IActorAbility
    {
        private Actor actor;

        private Vector3 velocity;

        public Quaternion TargetRotation { get; private set; }

        private float rotationSpeed = 10.0f;

        private readonly ReactiveProperty<bool> isMoving = new(false);
        public ReadOnlyReactiveProperty<bool> IsMoving => isMoving;

        public readonly ReactiveProperty<bool> CanMove = new(true);

        public readonly ReactiveProperty<bool> CanMoveFromEvent = new(true);

        public readonly ReactiveProperty<bool> CanRotate = new(true);

        public readonly ReactiveProperty<bool> CanRotateFromEvent = new(true);

        public void Move(Vector3 velocity)
        {
            this.velocity = velocity;
        }

        public void Rotate(Quaternion rotation)
        {
            TargetRotation = rotation;
        }

        public void RotateImmediate(Quaternion rotation)
        {
            TargetRotation = rotation;
            actor.transform.rotation = rotation;
        }

        public void SetRotationSpeed(float rotationSpeed)
        {
            this.rotationSpeed = rotationSpeed;
        }

        public void Activate(Actor actor)
        {
            this.actor = actor;
            actor.UpdateAsObservable()
                .Subscribe(this, static (_, @this) =>
                {
                    var deltaTime = @this.actor.GetAbility<ActorTime>().Time.deltaTime;
                    if (@this.velocity == Vector3.zero || !@this.CanMove.Value)
                    {
                        @this.isMoving.Value = false;
                    }
                    else
                    {
                        @this.actor.transform.position += @this.velocity * deltaTime;
                        @this.isMoving.Value = true;
                    }
                    @this.velocity = Vector3.zero;
                    var position = @this.actor.transform.position;
                    position.y = 0.0f;
                    @this.actor.transform.position = position;
                    @this.actor.transform.rotation = @this.TargetRotation;
                })
                .RegisterTo(actor.destroyCancellationToken);
        }
    }
}
