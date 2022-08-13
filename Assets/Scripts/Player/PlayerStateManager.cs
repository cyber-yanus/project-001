using GribnoySup.TowerUp.States.AttackStates;
using GribnoySup.TowerUp.States.MoveStates;
using GribnoySup.TowerUp.States;
using System;
using Zenject;


namespace GribnoySup.TowerUp.Player
{
    public class PlayerStateManager : IStateMachine
    {
        private MovementStatesContainer _movementStatesContainer;
        private AttackStatesContainer _attackStatesContainer;

        private MoveStateType _currentMoveStateType;
        private AttackStateType _currentAttackStateType;

        
        
        private PlayerStateManager(DiContainer diContainer)
        {
            var mainPlayer = diContainer.Resolve<MainPlayer>();

            _movementStatesContainer = diContainer.Resolve<MovementStatesContainer>();
            _attackStatesContainer = diContainer.Resolve<AttackStatesContainer>();

            _movementStatesContainer.Init(mainPlayer.transform);
            
            mainPlayer.MoveStateActivated += ActivateMoveState;
            mainPlayer.AttackStateActivated += ActivateAttackState;
        }

        private void ActivateMoveState(MoveStateType moveStateType)
        {
            if(moveStateType == _currentMoveStateType)
                return;

            _currentMoveStateType = moveStateType;
        
            ActivateState(_movementStatesContainer, moveStateType);
        }

        private void ActivateAttackState(AttackStateType attackStateType)
        {
            if(attackStateType == _currentAttackStateType)
                return;
            
            _currentAttackStateType = attackStateType;
            
            ActivateState(_attackStatesContainer, attackStateType);
        }

        private void ActivateState<T>(IStateContainer<T> stateContainer, T type) where T : Enum
        {
            var state = stateContainer.GetStateByType(type);
            state?.Execute();
        }
    }
}