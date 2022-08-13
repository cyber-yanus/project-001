using GribnoySup.TowerUp.States.AttackStates;
using Zenject;

namespace GribnoySup.TowerUp.States
{
    public class AttackStatesManager : BaseStatsManager<AttackStateType>
    {
        public AttackStatesContainer AttackStatesContainer => StatesContainer as AttackStatesContainer;
        
        public AttackStatesManager(DiContainer diContainer)
        {
            StatesContainer = diContainer.Resolve<AttackStatesContainer>();
        }
    }
}