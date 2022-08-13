using GribnoySup.TowerUp.TriggerObjects;
using GribnoySup.TowerUp.Player;
using UnityEngine;
using Zenject;

namespace GribnoySup.TowerUp.TriggerManagers.Variants
{
    public class PlayerTriggerManager : BaseTriggerManager
    {
        private MainPlayer _mainPlayer;



        [Inject]
        private void Construct(MainPlayer mainPlayer)
        {
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
                    TriggerEnemyWeaponAction();
                    break;
                
                case TriggerObjectType.Bonus:
                    TriggerBonusAction();
                    break;
            }
            
            RequiredTriggerAction();
        }

        private void TriggerEnemyAction()
        {
            Debug.Log("Attack");
        }

        private void TriggerEnemyWeaponAction()
        {
            Debug.Log("player minus heal");
        }

        private void TriggerBonusAction()
        {
            Debug.Log("Get Bonus");
        }

        private void RequiredTriggerAction()
        {
            _mainPlayer.Jump();
            _mainPlayer.Attack();
        }
    }
}