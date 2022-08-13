using GribnoySup.TowerUp.States.MoveStates.Variants;
using DG.Tweening;
using UnityEngine;
using Zenject;

namespace GribnoySup.TowerUp.States.MoveStates
{
    public class MovementStatesContainer : IStateContainer<MoveStateType>
    {
        private FallState _fallState;
        private JumpState _jumpState;

        public Transform Target { get; private set; }
        public Tween MovementTween { get; set; }



        public MovementStatesContainer(DiContainer diContainer)
        {
            _fallState = diContainer.Resolve<FallState>();
            _jumpState = diContainer.Resolve<JumpState>();
        }

        public void Init(Transform target)
        {
            Target = target;
            
            InitAllStates();
        }

        public IState GetStateByType(MoveStateType moveStateType)
        {
            return moveStateType switch
            {
                MoveStateType.Fall => _fallState,
                MoveStateType.Jump => _jumpState,
                _ => null
            };
        }

        private void InitAllStates()
        {
            _fallState.InitMovementState(this);
            _jumpState.InitMovementState(this);
        }
    }
}