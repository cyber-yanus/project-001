using GribnoySup.TowerUp.TriggerObjects;
using GribnoySup.TowerUp.Player;
using UnityEngine;
using System;

namespace GribnoySup.TowerUp.TriggerManagers
{
    [Serializable]
    public abstract class BaseTriggerManager
    {
        [SerializeField] private TriggerDetector triggerDetector;
        
        
        
        public void Activate()
        {
            triggerDetector.TriggerEntered += SelectTriggerEnteredAction;
            triggerDetector.SetActiveValue(true);
        }

        public void Deactivate()
        {
            triggerDetector.TriggerEntered -= SelectTriggerEnteredAction;
            triggerDetector.SetActiveValue(false);
        }

        public void AddTriggerDetector(TriggerDetector triggerDetector)
        {
            this.triggerDetector = triggerDetector;
        }

        protected abstract void SelectTriggerEnteredAction(TriggerObject triggerObject);
    }
}