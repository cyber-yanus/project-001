using GribnoySup.TowerUp.States.MoveStates;

namespace GribnoySup.TowerUp.States
{
    public class MovementStatesManager : BaseStatsManager<MoveStateType>
    {
        public MovementStatesContainer MovementStatesContainer => StatesContainer as MovementStatesContainer;

        public MovementStatesManager(MovementStatesContainer movementStatesContainer)
        {
            StatesContainer = movementStatesContainer;
        }
    }
}