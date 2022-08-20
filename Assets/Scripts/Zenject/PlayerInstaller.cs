using GribnoySup.TowerUp.TriggerManagers.Variants;
using GribnoySup.TowerUp.Player;
using UnityEngine;
using Zenject;


namespace GribnoySup.TowerUp.Zenject
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private GameObjectInstallSettings settings;
        
        
        
        public override void InstallBindings()
        {
            BindPlayerPrefab();            
            BindPlayerStateManager();
            BindPLayerTriggerManager();
        }

        private void BindPlayerPrefab()
        {
            MainPlayer mainPlayer =
                Container.InstantiatePrefabForComponent<MainPlayer>(settings.Prefab, settings.SpawnPoint);

            Container
                .Bind<MainPlayer>()
                .FromInstance(mainPlayer)
                .AsSingle();
        }

        private void BindPlayerStateManager()
        {
            Container
                .Bind<PlayerStateManager>()
                .FromNew()
                .AsSingle()
                .NonLazy();
        }

        private void BindPLayerTriggerManager()
        {
            Container
                .Bind<PlayerTriggerManager>()
                .FromNew()
                .AsSingle()
                .NonLazy();
        }
    }
}