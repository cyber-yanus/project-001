using GribnoySup.TowerUp.Configs;
using Zenject;
using System;
using DG.Tweening;


namespace GribnoySup.TowerUp.States.MoveStates.Variants
{
    public class JumpState : IMovementState
    {
        private MovementStatesContainer _movementStatesContainer;
        
        private JumpConfig _jumpConfig;
        
        public event Action StateExecuteStarted;
        public event Action StateExecuteEnded;


        
        public JumpState(DiContainer diContainer)
        {
            _jumpConfig = diContainer.Resolve<JumpConfig>();
        }

        public void InitMovementState(MovementStatesContainer movementStatesContainer)
        {
            _movementStatesContainer = movementStatesContainer;
        }

        public void Execute()
        {
            Jump();   
        }

        private void Jump()
        {
            StateExecuteStarted?.Invoke();
            
            var jumpPositionY = _jumpConfig.MaxJumpPositionY;
            var jumpDuration = _jumpConfig.JumpDuration;
            var jumpAnimationType = _jumpConfig.JumpAnimationType;
            
            var target = _movementStatesContainer.Target;
            
            _movementStatesContainer.MovementTween?.Kill();
            _movementStatesContainer.MovementTween = target.DOMoveY(jumpPositionY, jumpDuration)
                .SetEase(jumpAnimationType)
                .OnComplete(() => StateExecuteEnded?.Invoke());
        }
    }
}