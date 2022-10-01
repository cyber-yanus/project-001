using GribnoySup.TowerUp.Enemys;
using Zenject;
using System;

namespace DefaultNamespace.PoolObjects
{
    public class EnemyPool : MemoryPool<Enemy>
    {
        private CharacterHealthListener _characterHealthListener;

        public event Action<Enemy> Spawned;
        public event Action<Enemy> Despawned;
        
        
         [Inject]
         private void Construct(CharacterHealthListener characterHealthListener)
         {
             _characterHealthListener = characterHealthListener;
         }

        protected override void OnSpawned(Enemy enemy)
        {
            base.OnSpawned(enemy);
            
            enemy.gameObject.SetActive(true);
            
            Spawned?.Invoke(enemy);
        }

        protected override void OnDespawned(Enemy enemy)
        {
            base.OnDespawned(enemy);
            
            enemy.gameObject.SetActive(false);
            
            Despawned?.Invoke(enemy);
        }

        protected override void OnCreated(Enemy enemy)
        {
            base.OnCreated(enemy);

            enemy.Died += () => Despawn(enemy);
           
            _characterHealthListener.ActivateHealthStepActions(enemy);
        }
    }
}