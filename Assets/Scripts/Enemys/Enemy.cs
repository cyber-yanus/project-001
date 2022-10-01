using GribnoySup.TowerUp.TriggerManagers.Variants;
using DefaultNamespace;
using UnityEngine;



namespace GribnoySup.TowerUp.Enemys
{
    public class Enemy : BaseCharacter
    {
        [SerializeField] private EnemyTriggerManager enemyTriggerManager;
        [SerializeField] private EnemyEntitiesContainer enemyEntitiesContainer;

        public EnemyType CurrentEnemyType { get; set; }
        
        public EnemyTriggerManager EnemyTriggerManager => enemyTriggerManager;
        public EnemyEntitiesContainer EnemyEntitiesContainer => enemyEntitiesContainer;
        
        
        
        protected override void Init()
        {
            base.Init();
            
            enemyTriggerManager.Init(this);
        }
    }
}