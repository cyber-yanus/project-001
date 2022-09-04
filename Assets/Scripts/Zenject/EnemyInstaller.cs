using GribnoySup.TowerUp.TriggerManagers.Variants;
using DefaultNamespace.PoolObjects;
using GribnoySup.TowerUp.Enemys;
using UnityEngine;
using Zenject;

namespace GribnoySup.TowerUp.Zenject
{
    public class EnemyInstaller : MonoInstaller
    {
        [SerializeField] private GameObjectInstallSettings settings;
        
        
        
        public override void InstallBindings()
        {
            BindEnemyPool();
            BindEnemyPrefab();
            BindEnemyTriggerManager();
        }

        private void BindEnemyPrefab()
        {
            Enemy enemy =
                Container.InstantiatePrefabForComponent<Enemy>(settings.Prefab, settings.SpawnPoint);

            Container
                .Bind<Enemy>()
                .FromInstance(enemy)
                .AsSingle();    
        }
        
        private void BindEnemyTriggerManager()
        {
            Container
                .Bind<EnemyTriggerManager>()
                .FromNew()
                .AsSingle()
                .NonLazy();
        }

        private void BindEnemyPool()
        {
            Container.BindMemoryPool<Enemy, EnemyPool>().FromComponentInNewPrefab(settings.Prefab);
        }
    }
}