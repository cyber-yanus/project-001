using UnityEngine;
using System;
using GribnoySup.TowerUp.TriggerObjects;

namespace GribnoySup.TowerUp.Player
{
    public class TriggerDetector : MonoBehaviour
    {
        public event Action<TriggerObject> TriggerEntered;
        
        
        
        private void OnTriggerEnter2D(Collider2D collider)
        {
            var triggerObject = collider.GetComponent<TriggerObject>();
            TriggerEntered?.Invoke(triggerObject);
        }
    }
}