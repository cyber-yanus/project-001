using GribnoySup.TowerUp.Configs;
using DG.Tweening;
using Zenject;



namespace GribnoySup.TowerUp.States.MoveStates.Variants
{
    public class JumpState : BaseMoveState
    {
        private JumpConfig _jumpConfig;
        
        
        
        public JumpState(DiContainer diContainer)
        {
            _jumpConfig = diContainer.Resolve<JumpConfig>();
            StateConfig = _jumpConfig;
        }

        public override void Execute()
        {
            Jump();   
        }

        private void Jump()
        {
            StateExecuteStarted?.Invoke();
            
            var jumpPositionY = _jumpConfig.MaxJumpPositionY;
            var jumpDuration = _jumpConfig.JumpDuration;
            var jumpAnimationType = _jumpConfig.JumpAnimationType;
            
            var target = MovementStatesContainer.Target;
            
            MovementStatesContainer.MovementTween?.Kill();
            MovementStatesContainer.MovementTween = target.DOMoveY(jumpPositionY, jumpDuration)
                .SetEase(jumpAnimationType)
                .OnComplete(() => StateExecuteEnded?.Invoke());
        }
    }
}