using UnityEngine;

namespace GribnoySup.TowerUp.TriggerObjects
{
    public class TriggerObject : MonoBehaviour
    {
        [SerializeField] private TriggerObjectType type;

        public TriggerObjectType Type => type;
    }
}