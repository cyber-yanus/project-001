

using System;

namespace DefaultNamespace
{
    public interface IDying
    {
        public event Action Died;
        
        public void Die();
    }
}