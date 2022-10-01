using UnityEngine;
using System;

namespace GribnoySup.TowerUp.Enemys
{
    [Serializable]
    public class EnemyEntitiesContainer
    {
        [SerializeField] private EnemyEntity[] enemyEntities;



        public EnemyEntity GetEnemyEntityByType(EnemyType enemyType)
        {
            foreach (var enemyEntity in enemyEntities)
            {
                var enemyEntityType = enemyEntity.EnemyType;
                if (enemyType == enemyEntityType)
                    return enemyEntity;
            }

            return null;
        }
    }
}