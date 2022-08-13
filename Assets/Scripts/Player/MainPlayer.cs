using GribnoySup.TowerUp.States.AttackStates;
using GribnoySup.TowerUp.States.MoveStates;
using GribnoySup.TowerUp.States;
using UnityEngine;
using System;

namespace GribnoySup.TowerUp.Player
{
    public class MainPlayer : MonoBehaviour, IStateActivator
    {
        [SerializeField] private TriggerDetector triggerDetector;

        public TriggerDetector TriggerDetector => triggerDetector;
        
        public event Action<MoveStateType> MoveStateActivated;
        public event Action<AttackStateType> AttackStateActivated;

        

        public void Fall()
        {
            MoveStateActivated?.Invoke(MoveStateType.Fall);
        }

        public void Jump()
        {
            MoveStateActivated?.Invoke(MoveStateType.Jump);
        }

        public void Attack()
        {
            AttackStateActivated?.Invoke(AttackStateType.Attack);
        }

        public void BoostAttack()
        {
            AttackStateActivated?.Invoke(AttackStateType.BoostAttack);
        }
    }
}