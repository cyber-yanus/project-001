using GribnoySup.TowerUp.States.MoveStates;
using Zenject;

namespace GribnoySup.TowerUp.States
{
    public class MovementStatesManager : BaseStatsManager<MoveStateType>
    {
        public MovementStatesContainer MovementStatesContainer => StatesContainer as MovementStatesContainer;

        public MovementStatesManager(DiContainer diContainer)
        {
            StatesContainer = diContainer.Resolve<MovementStatesContainer>();
        }
    }
}