using GribnoySup.TowerUp.TriggerObjects;
using GribnoySup.TowerUp.Damages;
using GribnoySup.TowerUp.Enemys;
using UnityEngine;
using System;

namespace GribnoySup.TowerUp.TriggerManagers.Variants
{
    [Serializable]
    public class EnemyTriggerManager : BaseCharacterTriggerManager<Enemy>
    {
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
            DamageSystem.Activate(damageGiver, TargetCharacter);
            
            Debug.Log("Enemy minus heal");
        }
    }
}