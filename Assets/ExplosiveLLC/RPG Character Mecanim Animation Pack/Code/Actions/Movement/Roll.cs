using RPGCharacterAnims.Lookups;
using UnityEngine;
using UnityEngine.EventSystems;

namespace RPGCharacterAnims.Actions
{
    public class Roll : MovementActionHandler<RollType>
    {
        public Roll(RPGCharacterMovementController movement) : base(movement)
        {
        }

        public override bool CanStartAction(RPGCharacterController controller)
        { return controller.canAction && !controller.IsActive("Relax"); }

        protected override void _StartAction(RPGCharacterController controller, RollType rollType)
        {
            Debug.Log(controller.transform.InverseTransformDirection(movement.currentVelocity));
            rollType = DecideRollType(controller.transform.InverseTransformDirection(movement.currentVelocity));
            controller.Roll(rollType);
            movement.currentState = CharacterState.Roll;
		}

        private RollType DecideRollType(Vector3 movementDirection)
        {
            RollType rollType = RollType.Forward;
            if (Mathf.Abs(movementDirection.x) > Mathf.Abs(movementDirection.z))
            {
                if (movementDirection.x < 0.1 )
                {
                    rollType = RollType.Left;
                }
                else if (movementDirection.x > -0.1)
                {
                    rollType = RollType.Right;
                }
            }
            else
            {
                if (movementDirection.z > 0.1 )
                {
                    rollType = RollType.Forward;
                }
                else if (movementDirection.z < -0.1)
                {
                    rollType = RollType.Backward;
                }
            }


            return rollType;
        }

        public override bool IsActive()
        { return movement.currentState != null && (CharacterState)movement.currentState == CharacterState.Roll; }
    }
}