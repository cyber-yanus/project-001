using GribnoySup.TowerUp.States.MoveStates;
using GribnoySup.TowerUp.States.MoveStates.Variants;
using Zenject;

namespace GribnoySup.TowerUp.Zenject
{
    public class StatesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindFallState();
            BindJumpState();
            
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
    }
}