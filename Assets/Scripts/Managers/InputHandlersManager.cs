using GribnoySup.TowerUp.Player;
using UnityEngine;
using Lean.Touch;
using Zenject;


namespace DefaultNamespace
{
    public class InputHandlersManager : MonoBehaviour
    {
        [SerializeField] private LeanFingerSwipe swipeHandler;

        private MainPlayer _mainPlayer;


        
        [Inject]
        private void Construct(MainPlayer mainPlayer)
        {
            _mainPlayer = mainPlayer;
            
            swipeHandler.OnFinger.AddListener(SwipeAction);
        }
        
        private void SwipeAction(LeanFinger arg0)
        { 
            _mainPlayer.Fall();
        }
        
    }
}