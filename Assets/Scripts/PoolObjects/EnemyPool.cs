using GribnoySup.TowerUp.Enemys;
using UnityEngine;
using Zenject;

namespace DefaultNamespace.PoolObjects
{
    public class EnemyPool : MemoryPool<Enemy>
    {
        private CharacterHealthListener _characterHealthListener;
        
        
        
         [Inject]
         private void Construct(CharacterHealthListener characterHealthListener)
         {
             _characterHealthListener = characterHealthListener;
         }

        protected override void OnSpawned(Enemy enemy)
        {
            enemy.HealthInspector.AddHealthPoints(enemy.HealthInspector.MaxHealth);
            
            Debug.Log("enemy Spawned");
        }

        protected override void OnCreated(Enemy enemy)
        {
            base.OnCreated(enemy);
            
            _characterHealthListener.ConnectDeathWithHealth(enemy);
        }
    }
}