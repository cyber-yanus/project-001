using DG.Tweening;
using UnityEngine;

namespace GribnoySup.TowerUp.Configs
{
    [CreateAssetMenu(fileName = "Fall Config", menuName = "Configs/Fall")]
    public class FallConfig : ScriptableObject
    {
        [SerializeField] private float maxFallPositionY;
        [SerializeField] private float fallDuration;
        [SerializeField] private Ease fallAnimationType;

        public float MaxFallPositionY => maxFallPositionY;
        public float FallDuration => fallDuration;
        public Ease FallAnimationType => fallAnimationType;
    }
}