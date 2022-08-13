using DG.Tweening;
using UnityEngine;

namespace GribnoySup.TowerUp.Configs
{
    [CreateAssetMenu(fileName = "Jump Config", menuName = "Configs/Jump")]
    public class JumpConfig : ScriptableObject
    {
        [SerializeField] private float maxJumpPositionY;
        [SerializeField] private float jumpDuration;
        [SerializeField] private Ease jumpAnimationType;

        public float MaxJumpPositionY => maxJumpPositionY;
        public float JumpDuration => jumpDuration;
        public Ease JumpAnimationType => jumpAnimationType;
    }
}