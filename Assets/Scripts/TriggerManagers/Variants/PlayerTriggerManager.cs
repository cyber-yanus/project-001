using GribnoySup.TowerUp.TriggerObjects;
using GribnoySup.TowerUp.Damages;
using GribnoySup.TowerUp.Player;
using UnityEngine;
using Zenject;

namespace GribnoySup.TowerUp.TriggerManagers.Variants
{
    public class PlayerTriggerManager : BaseTriggerManager
    {
        private MainPlayer _mainPlayer;
        private DamageSystem _damageSystem;


        
        [Inject]
        private void Construct(MainPlayer mainPlayer)
        {
            _damageSystem = new DamageSystem();
            
            _mainPlayer = mainPlayer;
            _mainPlayer.TriggerDetector.TriggerEntered += SelectTriggerEnteredAction;
        }
        
        protected override void SelectTriggerEnteredAction(TriggerObject triggerObject)
        {
            switch (triggerObject.Type)
            {
                case TriggerObjectType.Enemy:
                    TriggerEnemyAction();
                    break;
                
                case TriggerObjectType.EnemyWeapon:
                    var damageGiver = triggerObject.GetComponent<IDamageGiver>();
                    TriggerEnemyWeaponAction(damageGiver);
                    break;
                
                case TriggerObjectType.Bonus:
                    TriggerBonusAction();
                    break;
            }
        }

        private void TriggerEnemyAction()
        {
            _mainPlayer.Attack();
            _mainPlayer.Jump();
            
            Debug.Log("Triggered with enemy");
        }

        private void TriggerEnemyWeaponAction(IDamageGiver damageGiver)
        {
            _damageSystem.Activate(damageGiver, _mainPlayer);
            
            Debug.Log("player minus heal");
        }

        private void TriggerBonusAction()
        {
            _mainPlayer.Attack();
            _mainPlayer.Jump();
            
            Debug.Log("Get Bonus");
        }
    }
}