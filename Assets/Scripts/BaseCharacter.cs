using GribnoySup.TowerUp.Damages;
using GribnoySup.TowerUp.Player;
using UnityEngine;
using System;

namespace DefaultNamespace
{
    public abstract class BaseCharacter : MonoBehaviour, IDamageTaker, IDying
    {
        [SerializeField] private TriggerDetector triggerDetector;
        [SerializeField] protected HealthInspector healthInspector;

        public event Action Died;
        
        public TriggerDetector TriggerDetector => triggerDetector;
        public HealthInspector HealthInspector => healthInspector;


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

        public void SetActiveTriggerDetector(bool value)
        {
            triggerDetector.SetActiveValue(value);
        }
    }

 
}