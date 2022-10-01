using DG.Tweening;
using GribnoySup.TowerUp.States;
using GribnoySup.TowerUp.States.MoveStates;
using UnityEngine;

namespace GribnoySup.TowerUp.Configs
{
    [CreateAssetMenu(fileName = "Fall Config", menuName = "Configs/Fall")]
    public class FallConfig : ScriptableObject, IStateConfig<MoveStateType>
    {
        [SerializeField] private float maxFallPositionY;
        [SerializeField] private float fallDuration;
        [SerializeField] private Ease fallAnimationType;
        [Space]
        [SerializeField] private MoveStateType[] ignoreStateTypes;

        public float MaxFallPositionY => maxFallPositionY;
        public float FallDuration => fallDuration;
        public Ease FallAnimationType => fallAnimationType;
        
        public MoveStateType[] IgnoreStateTypes => ignoreStateTypes;
    }
}