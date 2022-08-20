using UnityEngine;
using System;
using UnityEngine.Serialization;

namespace DefaultNamespace
{
    [Serializable]
    public class HealthInspector
    {
        [SerializeField] private int maxHealth;
        [SerializeField] private int currentHealth;

        public int MaxHealth => maxHealth;
        public int CurrentHealth => currentHealth;
        

        public event Action<int> HealthChanged;



        public void UpdateHealthPoints(int diffValue)
        {
            currentHealth += diffValue;
            HealthChanged?.Invoke(CurrentHealth);
            
            Debug.Log($"character updated health = {CurrentHealth}");
        }

        public void AddHealthPoints(int newHealth)
        {
            currentHealth = newHealth;
            HealthChanged?.Invoke(CurrentHealth);
        }

    }
}