using DefaultNamespace.PoolObjects;
using GribnoySup.TowerUp.Enemys;
using UnityEngine;
using Zenject;

namespace GribnoySup.TowerUp.Zenject
{
    public class EnemyInstaller : MonoInstaller
    {
        [SerializeField] private GameObject enemyPrefab;
        
        
        
        public override void InstallBindings()
        {
            BindEnemyPool();
            BindEnemyConstructor();
        }
        
        private void BindEnemyPool()
        {
            Container.BindMemoryPool<Enemy, EnemyPool>().FromComponentInNewPrefab(enemyPrefab);
        }

        private void BindEnemyConstructor()
        {
            Container.Bind<EnemyConstructor>().FromNew().AsSingle();
        }
    }
}