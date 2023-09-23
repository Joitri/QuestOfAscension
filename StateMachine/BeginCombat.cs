using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IdleGame.Combat
{
    public class BeginCombat : State
    {
        public BeginCombat(BattleSystem battleSystem) : base(battleSystem) { }
        public override IEnumerator Start()
        {
            yield return new WaitForSeconds(2f);
            BattleSystem.SetState(new BeginCombat(BattleSystem));
        }
    }
}