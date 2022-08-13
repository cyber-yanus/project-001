using GribnoySup.TowerUp.States.MoveStates.Variants;
using GribnoySup.TowerUp.States.AttackStates;
using GribnoySup.TowerUp.States.MoveStates;
using GribnoySup.TowerUp.States;
using Zenject;

namespace GribnoySup.TowerUp.Zenject
{
    public class StatesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindFallState();
            BindJumpState();

            BindAttackStatesContainer();
            BindMovementStatesContainer();
            
            BindAttackStatesManager();
            BindMovementStatesManager();
        }

        private void BindJumpState()
        {
            Container
                .Bind<JumpState>()
                .FromNew()
                .AsTransient();
        }

        private void BindFallState()
        {
            Container
                .Bind<FallState>()
                .FromNew()
                .AsTransient();
        }

        private void BindMovementStatesContainer()
        {
            Container
                .Bind<MovementStatesContainer>()
                .FromNew()
                .AsTransient();
        }
        
        private void BindAttackStatesContainer()
        {
            Container
                .Bind<AttackStatesContainer>()
                .FromNew()
                .AsTransient();
        }
        
        private void BindMovementStatesManager()
        {
            Container
                .Bind<MovementStatesManager>()
                .FromNew()
                .AsTransient();
        }
        
        private void BindAttackStatesManager()
        {
            Container
                .Bind<AttackStatesManager>()
                .FromNew()
                .AsTransient();
        }
    }
}