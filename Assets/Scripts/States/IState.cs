using System;

namespace GribnoySup.TowerUp.States
{
    public interface IState<T> where T : Enum
    {
        public Action StateExecuteStarted { get; set; }
        public Action StateExecuteEnded { get; set; }

        public void Execute();
        public bool IsIgnoredState(T type);
    }
}