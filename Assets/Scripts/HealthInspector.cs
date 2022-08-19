using System;

namespace DefaultNamespace
{
    public class HealthInspector
    {
        public int Health { get; private set; }

        public event Action<int> HealthChanged;



        public void UpdateHealthPoints(int diffValue)
        {
            Health += diffValue;
            HealthChanged?.Invoke(Health);
        }

        public void AddHealthPoints(int health)
        {
            Health = health;
            HealthChanged?.Invoke(Health);
        }

    }
}