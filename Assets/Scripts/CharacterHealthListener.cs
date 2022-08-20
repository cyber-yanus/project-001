

namespace DefaultNamespace
{
    public class CharacterHealthListener
    {
        private BaseCharacter _targetCharacter;
        
        
        
        public void ConnectDeathWithHealth(BaseCharacter baseCharacter)
        {
            baseCharacter.HealthInspector.HealthChanged += health =>
            {
                if (health <= 0)
                    baseCharacter.Die();
                else if (health >= baseCharacter.HealthInspector.MaxHealth)
                {
                    //ToDo: активируется еффект получения максимального здоровья  
                }
                else if (health <= baseCharacter.HealthInspector.MaxHealth / 4)
                {
                    //ToDo: активируется еффект обозночения скорой кончины
                }
            };
        }
        
        
        
        
    }
}