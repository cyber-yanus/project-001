using GribnoySup.TowerUp.TriggerObjects;
using GribnoySup.TowerUp.Damages;
using DefaultNamespace;



namespace GribnoySup.TowerUp.TriggerManagers
{
    public class BaseCharacterTriggerManager<T> : BaseTriggerManager where T : BaseCharacter
    {
        protected T TargetCharacter;
        protected DamageSystem DamageSystem;

        
        
        public virtual void Init(T targetCharacter)
        {
            TargetCharacter = targetCharacter;
            DamageSystem = new DamageSystem();
        }

        protected override void SelectTriggerEnteredAction(TriggerObject triggerObject)
        { }
    }
}