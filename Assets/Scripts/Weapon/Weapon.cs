using GribnoySup.TowerUp.Damages;
using UnityEngine;

namespace DefaultNamespace.Weapon
{
    public class Weapon : MonoBehaviour, IDamageGiver
    {
        [SerializeField] private int damage;
        
        public int Damage => damage;
    }
}