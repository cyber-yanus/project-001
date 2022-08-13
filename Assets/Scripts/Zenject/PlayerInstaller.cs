using GribnoySup.TowerUp.TriggerManagers.Variants;
using GribnoySup.TowerUp.Player;
using UnityEngine;
using Zenject;
using System;


namespace GribnoySup.TowerUp.Zenject
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private PlayerInstallSettings settings;
        
        
        
        public override void InstallBindings()
        {
            BindPlayerPrefab();            
            BindPlayerStateManager();
            BindPLayerTriggerManager();
        }

        private void BindPlayerPrefab()
        {
            MainPlayer mainPlayer =
                Container.InstantiatePrefabForComponent<MainPlayer>(settings.PlayerPrefab, settings.SpawnPoint);

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
        
        
        [Serializable]
        public class PlayerInstallSettings
        {
            public Transform SpawnPoint; 
            public GameObject PlayerPrefab;
        }
    }
}