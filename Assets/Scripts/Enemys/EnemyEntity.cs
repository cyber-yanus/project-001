using GribnoySup.TowerUp.Player;
using UnityEngine;
using System;

namespace GribnoySup.TowerUp.Enemys
{
    [Serializable]
    public class EnemyEntity
    {
        [SerializeField] private EnemyType enemyType;
        [Space]
        [SerializeField] private GameObject targetGameObject;
        [SerializeField] private TriggerDetector triggerDetector;

        public EnemyType EnemyType => enemyType;
        public TriggerDetector TriggerDetector => triggerDetector;


        public void SetActiveTargetObject(bool value)
        {
            targetGameObject.SetActive(value);
        }
    }
}