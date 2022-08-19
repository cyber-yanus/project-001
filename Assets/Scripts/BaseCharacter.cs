using GribnoySup.TowerUp.Player;
using UnityEngine;

namespace DefaultNamespace
{
    public abstract class BaseCharacter : MonoBehaviour
    {
        [SerializeField] private TriggerDetector triggerDetector;

        public HealthInspector HealthInspector { get; protected set; }

        public TriggerDetector TriggerDetector => triggerDetector;



        private void Awake()
        {
            Init();
        }

        protected virtual void Init()
        {
            HealthInspector = new HealthInspector();
        }
        
        public void SetActiveTriggerDetector(bool value)
        {
            triggerDetector.SetActiveValue(value);
        }
    }
}