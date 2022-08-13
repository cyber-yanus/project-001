using System;

namespace GribnoySup.TowerUp.States
{
    public abstract class BaseStatsManager<T> where T : Enum
    {
        protected IStateContainer<T> StatesContainer;
        
        private IState<T> _currentState;

        

        public void ActivateState(T type)
        {
            if (_currentState != null)
                if (_currentState.IsIgnoredState(type))
                    return;

            var state = StatesContainer.GetStateByType(type);
            state?.Execute();
            
            _currentState = state;
        }

        public void ClearCurrentState()
        {
            _currentState = null;
        }
    }
}