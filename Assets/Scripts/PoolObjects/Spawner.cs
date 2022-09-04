using System.Collections;
using GribnoySup.TowerUp.Enemys;
using UnityEngine;
using Zenject;

namespace DefaultNamespace.PoolObjects
{
    public class Spawner : MonoBehaviour
    {
        [Inject] private EnemyPool enemyPool;


        
        private IEnumerator Start()
        {
            yield return new WaitForSeconds(10f);

            var enemy = enemyPool.Spawn();

            yield return new WaitForSeconds(10f);
            
            enemyPool.Despawn(enemy);

            yield return new WaitForSeconds(5f);
            
            enemyPool.Spawn();
        }
    }
}