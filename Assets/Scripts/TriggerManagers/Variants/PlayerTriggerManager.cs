using System;
using GribnoySup.TowerUp.TriggerObjects;
using GribnoySup.TowerUp.Damages;
using GribnoySup.TowerUp.Player;
using UnityEngine;


namespace GribnoySup.TowerUp.TriggerManagers.Variants
{
    [Serializable]
    public class PlayerTriggerManager : BaseCharacterTriggerManager<MainPlayer>
    {
        public override void Init(MainPlayer targetCharacter)
        {
            base.Init(targetCharacter);
            
            Activate();
        }

        protected override void SelectTriggerEnteredAction(TriggerObject triggerObject)
        {
            if (!triggerObject)
                return;
            
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
            TargetCharacter.Attack();
            TargetCharacter.Jump();
            
            Debug.Log("Triggered with enemy");
        }

        private void TriggerEnemyWeaponAction(IDamageGiver damageGiver)
        {
            DamageSystem.Activate(damageGiver, TargetCharacter);
            
            Debug.Log("Player minus heal");
        }

        private void TriggerBonusAction()
        {
            TargetCharacter.Attack();
            TargetCharacter.Jump();
            
            Debug.Log("Get Bonus");
        }
    }
}