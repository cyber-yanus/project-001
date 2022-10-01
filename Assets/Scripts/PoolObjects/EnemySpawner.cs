using Random = UnityEngine.Random;
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
        [SerializeField] private int maxSpawnCount;
        [SerializeField] private int delay;

        private List<Enemy> _spawnedEnemyList;
        
        private EnemyPool _enemyPool;
        private EnemyConstructor _enemyConstructor;



        [Inject]
        private void Construct(EnemyPool enemyPool, EnemyConstructor enemyConstructor)
        {
            _enemyPool = enemyPool;
            _enemyConstructor = enemyConstructor;

            _spawnedEnemyList = new List<Enemy>();

            _enemyPool.Despawned += DeSpawnAction;
            _enemyPool.Spawned += SpawnAction;
        }

        private void Start()
        {
            Activate();
        }

        private async void Activate()
        {
            while (true)
            {
                await UniTask.WaitUntil(() => _spawnedEnemyList.Count < maxSpawnCount);
                
                await UniTask.Delay(TimeSpan.FromSeconds(Random.Range(3,delay)));

                _enemyPool.Spawn();

                await UniTask.WaitForEndOfFrame();
            }
        }

        private void SpawnAction(Enemy enemy)
        {
            _spawnedEnemyList.Add(enemy);
            _enemyConstructor.BuildByType(enemy, EnemyType.Default);
        }

        private void DeSpawnAction(Enemy enemy)
        {
            _spawnedEnemyList.Remove(enemy);
            _enemyConstructor.Exterminate(enemy);
        }
    }
}