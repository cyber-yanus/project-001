using GribnoySup.TowerUp.States.MoveStates;
using System;


namespace GribnoySup.TowerUp.States
{
    public interface IStateActivator
    {
        public event Action<MoveStateType> MoveStateActivated;
    }
}