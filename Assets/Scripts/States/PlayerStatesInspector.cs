using GribnoySup.TowerUp.States.MoveStates;
using GribnoySup.TowerUp.Player;

namespace GribnoySup.TowerUp.States
{
    public class PlayerStatesInspector
    {
        private MovementStatesManager _movementStatesManager;
        private AttackStatesManager _attackStatesManager;
        
        private MainPlayer _mainPlayer;
        
        
        
        public PlayerStatesInspector(MainPlayer mainPlayer)
        {
            _mainPlayer = mainPlayer;
        }

        public void Init(MovementStatesManager movementStatesManager, AttackStatesManager attackStatesManager)
        {
            _movementStatesManager = movementStatesManager;
            _attackStatesManager = attackStatesManager;

            InitFallState();
            InitJumpState();
        }
        
        private void InitFallState()
        {
            var fallState = _movementStatesManager.MovementStatesContainer.GetStateByType(MoveStateType.Fall);
            fallState.StateExecuteStarted += () => _mainPlayer.SetActiveTriggerDetector(true);
            
            fallState.StateExecuteEnded += _movementStatesManager.ClearCurrentState;
            fallState.StateExecuteEnded += _mainPlayer.Jump;
        }
        
        private void InitJumpState()
        {
            var jumpState = _movementStatesManager.MovementStatesContainer.GetStateByType(MoveStateType.Jump);
            jumpState.StateExecuteStarted += () => _mainPlayer.SetActiveTriggerDetector(false);
            
            jumpState.StateExecuteEnded += _movementStatesManager.ClearCurrentState;
            jumpState.StateExecuteEnded += () => _mainPlayer.SetActiveTriggerDetector(true);
        }
        
    }
}