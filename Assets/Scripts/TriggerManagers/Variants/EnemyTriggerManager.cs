using GribnoySup.TowerUp.TriggerObjects;
using GribnoySup.TowerUp.Damages;
using GribnoySup.TowerUp.Enemys;
using UnityEngine;
using Zenject;

namespace GribnoySup.TowerUp.TriggerManagers.Variants
{
    public class EnemyTriggerManager : BaseTriggerManager
    {
        private Enemy _enemy;
        private DamageSystem _damageSystem;
        
        

        [Inject]
        private void Construct(Enemy enemy)
        {
            _damageSystem = new DamageSystem();
            
            _enemy = enemy;
            _enemy.TriggerDetector.TriggerEntered += SelectTriggerEnteredAction;
            _enemy.SetActiveTriggerDetector(true);
        }

        protected override void SelectTriggerEnteredAction(TriggerObject triggerObject)
        {
            switch (triggerObject.Type)
            {
                case TriggerObjectType.PlayerWeapon:
                    var damageGiver = triggerObject.GetComponent<IDamageGiver>();
                    PlayerWeaponTriggerEntered(damageGiver);
                    break;
            }
        }

        private void PlayerWeaponTriggerEntered(IDamageGiver damageGiver)
        {
            _damageSystem.Activate(damageGiver, _enemy);
            Debug.Log("Enemy minus heal");
        }
    }
}