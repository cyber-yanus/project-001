using System;

namespace GribnoySup.TowerUp.States
{
    public interface IStateContainer<T> where T : Enum
    {
        public IState GetStateByType(T moveStateType);
    }
}