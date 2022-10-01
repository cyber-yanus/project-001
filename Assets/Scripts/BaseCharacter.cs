using GribnoySup.TowerUp.Damages;
using UnityEngine;
using System;

namespace DefaultNamespace
{
    public abstract class BaseCharacter : MonoBehaviour, IDamageTaker, IDying
    {
        [SerializeField] protected HealthInspector healthInspector;

        public HealthInspector HealthInspector => healthInspector;
        
        public event Action Died;


        
        private void Awake()
        {
            Init();
        }

        protected virtual void Init()
        {
        }

        public void TakeDamage(int damage)
        {
            healthInspector.UpdateHealthPoints(-damage);
        }

        public virtual void Die()
        {
            Died?.Invoke();
            Debug.Log($"{gameObject.name} DIE");  
        }
    }
}