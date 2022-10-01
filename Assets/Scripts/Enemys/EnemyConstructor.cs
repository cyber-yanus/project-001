using GribnoySup.TowerUp.Configs;
using DefaultNamespace;

namespace GribnoySup.TowerUp.Enemys
{
    public class EnemyConstructor
    {
        private CharacterHealthListener _characterHealthListener;
        private EnemyConfigsContainer _enemyConfigsContainer;


        
        public EnemyConstructor(EnemyConfigsContainer enemyConfigsContainer)
        {
            _enemyConfigsContainer = enemyConfigsContainer;
        }

        public void BuildByType(Enemy enemy, EnemyType type)
        {
            var enemyConfig = _enemyConfigsContainer.GetEnemyConfigByType(type);

            enemy.CurrentEnemyType = type;
            
            enemy.HealthInspector.AddMaxHealthPoints(enemyConfig.MaxHealthValue);
            enemy.HealthInspector.AddHealthPoints(enemyConfig.MaxHealthValue);

            var enemyEntity = enemy.EnemyEntitiesContainer.GetEnemyEntityByType(type);
            enemyEntity.SetActiveTargetObject(true);

            enemy.EnemyTriggerManager.AddTriggerDetector(enemyEntity.TriggerDetector);
            enemy.EnemyTriggerManager.Activate();
        }

        public void Exterminate(Enemy enemy)
        {
            enemy.HealthInspector.AddMaxHealthPoints(0);
            enemy.HealthInspector.AddHealthPoints(0);

            enemy.EnemyTriggerManager.Deactivate();
            enemy.EnemyTriggerManager.AddTriggerDetector(null);
            
            var enemyEntity = enemy.EnemyEntitiesContainer.GetEnemyEntityByType(enemy.CurrentEnemyType);
            enemyEntity.SetActiveTargetObject(false);

            enemy.CurrentEnemyType = EnemyType.None;
        }
    }
}