using System;

namespace GribnoySup.TowerUp.States
{
    public interface IStateConfig<T> where T : Enum
    {
        public T[] IgnoreStateTypes { get; }
    }
}