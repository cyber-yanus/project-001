using GribnoySup.TowerUp.States.MoveStates;
using GribnoySup.TowerUp.States.AttackStates;
using System;


namespace GribnoySup.TowerUp.States
{
    public interface IStateActivator
    {
        public event Action<MoveStateType> MoveStateActivated;
        public event Action<AttackStateType> AttackStateActivated;
    }
}