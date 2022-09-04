using System.Collections.Generic;
using GribnoySup.TowerUp.Enemys;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;
using System;

namespace DefaultNamespace.PoolObjects
{
    public class EnemySpawner : MonoBehaviour
    {
        private EnemyPool _enemyPool;

        private List<Enemy> _spawnedEnemyList;



        [Inject]
        private void Construct(EnemyPool enemyPool)
        {
            _enemyPool = enemyPool;
            _spawnedEnemyList = new List<Enemy>();

            _enemyPool.Despawned += DespawnAction;
        }

        private void Start()
        {
            Activate();
        }

        private async void Activate()
        {
            await UniTask.Delay(TimeSpan.FromSeconds(2f));
            
            _enemyPool.Spawn();
        }
        
        private void DespawnAction(Enemy enemy)
        {
            _spawnedEnemyList.Remove(enemy);
            
            Activate();
        }
    }
}