using DefaultNamespace;
using Zenject;

namespace GribnoySup.TowerUp.Zenject
{
    public class BaseCharacterInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindCharacterHealthListener();
        }

        private void BindCharacterHealthListener()
        {
            Container.Bind<CharacterHealthListener>().FromNew().AsSingle();
        }
    }
}