using GribnoySup.TowerUp.States.MoveStates;
using DG.Tweening;
using GribnoySup.TowerUp.States;
using UnityEngine;


namespace GribnoySup.TowerUp.Configs
{
    [CreateAssetMenu(fileName = "Jump Config", menuName = "Configs/Jump")]
    public class JumpConfig : ScriptableObject, IStateConfig<MoveStateType>
    {
        [SerializeField] private float maxJumpPositionY;
        [SerializeField] private float jumpDuration;
        [SerializeField] private Ease jumpAnimationType;
        [Space]
        [SerializeField] private MoveStateType[] ignoreStateTypes;


        public float MaxJumpPositionY => maxJumpPositionY;
        public float JumpDuration => jumpDuration;
        public Ease JumpAnimationType => jumpAnimationType;

        public MoveStateType[] IgnoreStateTypes => ignoreStateTypes;
    }
}