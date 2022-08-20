namespace GribnoySup.TowerUp.Damages
{
    public class DamageSystem
    {
        public void Activate(IDamageGiver damageGiver, IDamageTaker damageTaker)
        {
            var damage = damageGiver.Damage;
            damageTaker.TakeDamage(damage);
        }
    }
}