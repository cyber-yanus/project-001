using GribnoySup.TowerUp.Configs;
using UnityEngine;
using Zenject;

namespace GribnoySup.TowerUp.Zenject
{
    
    [CreateAssetMenu(fileName = "Movement States Config", menuName = "States Config/Movement States Config")]
    public class MovementStatesConfig : ScriptableObjectInstaller<MovementStatesConfig>
    {
        [SerializeField] private FallConfig fallConfig;
        [SerializeField] private JumpConfig jumpConfig;


        
        public override void InstallBindings()
        {
            Container.BindInstance(fallConfig).AsSingle();
            Container.BindInstance(jumpConfig).AsSingle();
        }
    }
}