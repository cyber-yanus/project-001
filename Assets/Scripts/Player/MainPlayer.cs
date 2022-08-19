using GribnoySup.TowerUp.States.AttackStates;
using GribnoySup.TowerUp.States.MoveStates;
using GribnoySup.TowerUp.States;
using DefaultNamespace;
using System;


namespace GribnoySup.TowerUp.Player
{
    public class MainPlayer : BaseCharacter, IStateActivator
    {
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