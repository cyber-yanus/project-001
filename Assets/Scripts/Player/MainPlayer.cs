using GribnoySup.TowerUp.TriggerManagers.Variants;
using GribnoySup.TowerUp.States.AttackStates;
using GribnoySup.TowerUp.States.MoveStates;
using GribnoySup.TowerUp.States;
using DefaultNamespace;
using System;
using UnityEngine;
using UnityEngine.Serialization;


namespace GribnoySup.TowerUp.Player
{
    public class MainPlayer : BaseCharacter, IStateActivator
    {
        [SerializeField] private PlayerTriggerManager playerTriggerManager;
        
        public event Action<MoveStateType> MoveStateActivated;
        public event Action<AttackStateType> AttackStateActivated;
        
        
        
        protected override void Init()
        {
            base.Init();

            playerTriggerManager.Init(this);
        }

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
        
        
        public PlayerTriggerManager PlayerTriggerManager => playerTriggerManager;
    }
}