using GribnoySup.TowerUp.Enemys;
using UnityEngine;
using Zenject;

namespace GribnoySup.TowerUp.Configs
{
    
    [CreateAssetMenu(fileName = "Enemy Config", menuName = "Configs/Enemy")]
    public class EnemyConfigsContainer : ScriptableObjectInstaller<EnemyConfigsContainer>
    {
        [SerializeField] private EnemyConfig[] enemyConfigs;


        
        public override void InstallBindings()
        {
            Container
                .Bind<EnemyConfigsContainer>()
                .FromScriptableObject(this)
                .AsSingle();
        }

        public EnemyConfig GetEnemyConfigByType(EnemyType type)
        {
            foreach (var enemyConfig in enemyConfigs)
            {
                var enemyType = enemyConfig.EnemyType;
                if (type == enemyType)
                    return enemyConfig;
            }
            
            return null;
        }
    }
}