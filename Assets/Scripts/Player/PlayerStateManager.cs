using GribnoySup.TowerUp.States;
using Zenject;


namespace GribnoySup.TowerUp.Player
{
    public class PlayerStateManager : IStateMachine
    {
        private PlayerStatesInspector _playerStatesInspector;


        private PlayerStateManager(DiContainer diContainer)
        {
            var mainPlayer = diContainer.Resolve<MainPlayer>();

            _playerStatesInspector = new PlayerStatesInspector(mainPlayer);

            var attackStatesManager = diContainer.Resolve<AttackStatesManager>();
            var movementStatesManager = diContainer.Resolve<MovementStatesManager>();

            var attackStatesContainer = attackStatesManager.AttackStatesContainer;
            var movementStatesContainer = movementStatesManager.MovementStatesContainer;
            
            _playerStatesInspector.Init(movementStatesManager, attackStatesManager);

            movementStatesContainer.Init(mainPlayer.transform);
            
            mainPlayer.MoveStateActivated += movementStatesManager.ActivateState;
            mainPlayer.AttackStateActivated += attackStatesManager.ActivateState;
        }
    }
}