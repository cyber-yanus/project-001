using GribnoySup.TowerUp.Damages;
using GribnoySup.TowerUp.Player;
using UnityEngine;

namespace DefaultNamespace
{
    public abstract class BaseCharacter : MonoBehaviour, IDamageTaker, IDying
    {
        [SerializeField] private TriggerDetector triggerDetector;
        [SerializeField] protected HealthInspector healthInspector;

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

        public void Die()
        {
             Debug.Log($"{gameObject.name} DIE");  
        }

        public void SetActiveTriggerDetector(bool value)
        {
            triggerDetector.SetActiveValue(value);
        }
    }

 
}