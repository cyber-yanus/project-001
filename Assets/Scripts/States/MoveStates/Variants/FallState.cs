using GribnoySup.TowerUp.Configs;
using DG.Tweening;
using UnityEngine;
using Zenject;
using System;


namespace GribnoySup.TowerUp.States.MoveStates.Variants
{
    public class FallState : IMovementState
    {
        private MovementStatesContainer _movementStatesContainer;
        
        private FallConfig _fallConfig;

        public event Action StateExecuteStarted;
        public event Action StateExecuteEnded;



        public FallState(DiContainer diContainer)
        {
            _fallConfig = diContainer.Resolve<FallConfig>();
        }

        public void InitMovementState(MovementStatesContainer movementStatesContainer)
        {
            _movementStatesContainer = movementStatesContainer;
        }

        public void Execute()
        {
            Fall();
        }

        private void Fall()
        {
            StateExecuteStarted?.Invoke();
            
            var endPositionY = _fallConfig.MaxFallPositionY;
            var fallDuration = _fallConfig.FallDuration;
            var fallAnimationType = _fallConfig.FallAnimationType;

            var target = _movementStatesContainer.Target;
            
            _movementStatesContainer.MovementTween?.Kill();
            _movementStatesContainer.MovementTween = target.DOMoveY(endPositionY, fallDuration)
                .SetEase(fallAnimationType)
                .OnComplete(() => StateExecuteEnded?.Invoke());
        }
    }
}