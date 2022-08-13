using GribnoySup.TowerUp.States.MoveStates.Variants;
using GribnoySup.TowerUp.States.AttackStates;
using GribnoySup.TowerUp.States.MoveStates;
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
    }
}