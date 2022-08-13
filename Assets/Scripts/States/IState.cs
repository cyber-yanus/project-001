using System;

namespace GribnoySup.TowerUp.States
{
    public interface IState
    {
        public event Action StateExecuteStarted;
        public event Action StateExecuteEnded;
        
        public void Execute();
    }
}