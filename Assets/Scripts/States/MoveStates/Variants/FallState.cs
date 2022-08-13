using GribnoySup.TowerUp.Configs;
using DG.Tweening;
using Zenject;


namespace GribnoySup.TowerUp.States.MoveStates.Variants
{
    public class FallState : BaseMoveState
    {
        private FallConfig _fallConfig;
        
        

        public FallState(DiContainer diContainer)
        {
            _fallConfig = diContainer.Resolve<FallConfig>();
            StateConfig = _fallConfig;
        }

        public override void Execute()
        {
            Fall();
        }

        private void Fall()
        {
            StateExecuteStarted?.Invoke();
            
            var endPositionY = _fallConfig.MaxFallPositionY;
            var fallDuration = _fallConfig.FallDuration;
            var fallAnimationType = _fallConfig.FallAnimationType;

            var target = MovementStatesContainer.Target;
            
            MovementStatesContainer.MovementTween?.Kill();
            MovementStatesContainer.MovementTween = target.DOMoveY(endPositionY, fallDuration)
                .SetEase(fallAnimationType)
                .OnComplete(() => StateExecuteEnded?.Invoke());
        }
    }
}