using System.Linq;
using System;

namespace GribnoySup.TowerUp.States.MoveStates
{
    public abstract class BaseMoveState : IMovementState
    {
        public MovementStatesContainer MovementStatesContainer { get; private set; }
        protected IStateConfig<MoveStateType> StateConfig;

        public Action StateExecuteStarted { get; set; }
        public Action StateExecuteEnded { get; set; }


        
        public void InitMovementState(MovementStatesContainer movementStatesContainer)
        {
            MovementStatesContainer = movementStatesContainer;
        }

        public bool IsIgnoredState(MoveStateType type)
        {
            return StateConfig.IgnoreStateTypes.Any(ignoreStateType => type == ignoreStateType);
        }
        
        public virtual void Execute() { }
    }
}