using GribnoySup.TowerUp.TriggerObjects;

namespace GribnoySup.TowerUp.TriggerManagers
{
    public abstract class BaseTriggerManager
    {
        protected abstract void SelectTriggerEnteredAction(TriggerObject triggerObject);
    }
}