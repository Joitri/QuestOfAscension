using System.Collections;

namespace IdleGame.Combat
{
    public abstract class State
    {
        protected BattleSystem BattleSystem;
        public State(BattleSystem battleSystem)
        {
            BattleSystem = battleSystem;
        }

        public virtual IEnumerator Start()
        {
            yield break;
        }

        public virtual IEnumerator Walk()
        {
            yield break;
        }
        public virtual IEnumerator Attack()
        {
            yield break;
        }
        //public virtual IEnumerator BeginCombat()
        //{
        //    yield break;
        //}
    }
}