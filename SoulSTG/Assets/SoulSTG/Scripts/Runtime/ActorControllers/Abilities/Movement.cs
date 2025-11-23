using R3;
using R3.Triggers;
using UnityEngine;

namespace SoulSTG.ActorControllers.Abilities
{
    public class Movement : IActorAbility
    {
        private Actor actor;

        private TimeController timeController;

        private Vector2 velocity;

        public Quaternion TargetRotation { get; private set; }

        private float rotationSpeed = 10.0f;

        private readonly ReactiveProperty<bool> isMoving = new(false);
        public ReadOnlyReactiveProperty<bool> IsMoving => isMoving;

        public float MoveSpeedRate { get; set; } = 1.0f;

        public float RotateSpeedRate { get; set; } = 1.0f;

        public void Move(Vector2 velocity)
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
            timeController = actor.GetAbility<TimeController>();
            actor.UpdateAsObservable()
                .Subscribe(this, static (_, @this) =>
                {
                    var deltaTime = @this.timeController.Time.deltaTime;
                    if (@this.velocity == Vector2.zero)
                    {
                        @this.isMoving.Value = false;
                    }
                    else
                    {
                        @this.actor.transform.position += (Vector3)@this.velocity * deltaTime * @this.MoveSpeedRate;
                        @this.isMoving.Value = true;
                    }
                    @this.velocity = Vector2.zero;
                    @this.actor.transform.rotation = Quaternion.Lerp(@this.actor.transform.rotation, @this.TargetRotation, @this.rotationSpeed * deltaTime * @this.RotateSpeedRate);
                })
                .RegisterTo(actor.destroyCancellationToken);
        }
    }
}
