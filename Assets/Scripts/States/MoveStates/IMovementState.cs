

namespace GribnoySup.TowerUp.States.MoveStates
{
    public interface IMovementState : IState<MoveStateType>
    {
        public MovementStatesContainer MovementStatesContainer { get; }

        public void InitMovementState(MovementStatesContainer movementStatesContainer);
    }
}