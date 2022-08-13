using GribnoySup.TowerUp.TriggerObjects;
using UnityEngine;
using System;

namespace GribnoySup.TowerUp.Player
{
    public class TriggerDetector : MonoBehaviour
    {
        private bool _isActive;
        
        public event Action<TriggerObject> TriggerEntered;
        
        
        
        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (!_isActive) 
                return;

            var triggerObject = collider.GetComponent<TriggerObject>();
            TriggerEntered?.Invoke(triggerObject);
        }

        public void SetActiveValue(bool value)
        {
            _isActive = value;
        }
    }
}