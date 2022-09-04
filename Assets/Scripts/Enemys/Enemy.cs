using GribnoySup.TowerUp.TriggerManagers.Variants;
using DefaultNamespace;


namespace GribnoySup.TowerUp.Enemys
{
    public class Enemy : BaseCharacter
    {
        private EnemyTriggerManager _enemyTriggerManager;



        public void Awake()
        {
            _enemyTriggerManager = new EnemyTriggerManager(this);
        }
    }
}