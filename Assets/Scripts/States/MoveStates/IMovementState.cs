

namespace GribnoySup.TowerUp.States.MoveStates
{
    public interface IMovementState : IState
    {
        public void InitMovementState(MovementStatesContainer movementStatesContainer);
    }
}