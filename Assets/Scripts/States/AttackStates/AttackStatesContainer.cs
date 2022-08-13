namespace GribnoySup.TowerUp.States.AttackStates
{
    public class AttackStatesContainer : IStateContainer<AttackStateType>
    {

        public AttackStatesContainer()
        {
            
        }


        public IState GetStateByType(AttackStateType moveStateType)
        {
            // switch (moveStateType)
            // {
            //     case AttackStateType.Attack:
            //         return;
            //     
            //     case AttackStateType.BoostAttack:
            //         return;
            //     
            //     default: return null;
            // }

            return null;
        }
    }
}