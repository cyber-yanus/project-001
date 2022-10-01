using GribnoySup.TowerUp.Enemys;
using UnityEngine;
using System;

namespace GribnoySup.TowerUp.Configs
{
    [Serializable]
    public class EnemyConfig
    {
        [SerializeField] private EnemyType enemyType;
        [Space]
        [SerializeField] private int maxHealthValue;

        public EnemyType EnemyType => enemyType;
        public int MaxHealthValue => maxHealthValue;
    }
}