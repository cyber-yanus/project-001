using UnityEngine;
using System;

namespace GribnoySup.TowerUp.Zenject
{
    [Serializable]
    public class GameObjectInstallSettings
    {
        public Transform SpawnPoint; 
        public GameObject Prefab;
    }
}