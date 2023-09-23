using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IdleGame.Combat
{
    public class BattleSystem : StateMachine
    {
        private BattleState _state;

        //[SerializeField] private BattleUI ui;
        [SerializeField] private Actor player;
        [SerializeField] private Actor enemy;

        public Actor Player => player;
        public Actor Enemy => enemy;
        //public BattleUI Interface => ui;

        private void Start()
        {
            //Interface.Initialize(player, enemy);

            _state = BattleState.Walk;
            SetState(new BeginCombat(this));
        }

        public void OnAttack()
        {
            if (_state != BattleState.Attack) return;
            StartCoroutine(State.Attack());
        }

        public void OnWalk()
        {
            if (_state != BattleState.Damaged) return;
            StartCoroutine(State.Walk());
        }

        //private IEnumerator BeginCombat()
        //{
        //    //Interface.SetDialogText($"A wild {Enemy.Name} appeared!");

        //    yield return new WaitForSeconds(2f);

        //    _state = BattleState.Attack;
        //    StartCoroutine(PlayerTurn());
        //}

        //private IEnumerator PlayerTurn()
        //{
        //    //Interface.SetDialogText("Choose an action.");
        //    yield break;
        //}

        //private IEnumerator PlayerAttack()
        //{
        //    var isDead = Enemy.Damage(Player.Attack);

        //    yield return new WaitForSeconds(1f);

        //    if (isDead)
        //    {
        //        _state = BattleState.Won;
        //        StartCoroutine(EndGame());
        //    }
        //    else
        //    {
        //        _state = BattleState.Attack;
        //        StartCoroutine(EnemyTurn());
        //    }
        //}

        //private IEnumerator PlayerHeal()
        //{
        //    //Interface.SetDialogText($"{Player.Name} feels renewed strength!");

        //    Player.RegenHP(5);

        //    yield return new WaitForSeconds(1f);

        //    _state = BattleState.Attack;
        //    StartCoroutine(EnemyTurn());
        //}

        //private IEnumerator EnemyTurn()
        //{
        //    //Interface.SetDialogText($"{Enemy.Name} attacks!");

        //    var isDead = Player.Damage(Enemy.Attack);

        //    yield return new WaitForSeconds(1f);

        //    if (isDead)
        //    {
        //        _state = BattleState.Lost;
        //        StartCoroutine(EndGame());
        //    }
        //    else
        //    {
        //        _state = BattleState.Attack;
        //        StartCoroutine(PlayerTurn());
        //    }
        //}

        //private IEnumerator EndGame()
        //{
        //    switch (_state)
        //    {
        //        case BattleState.Won:
        //            //Interface.SetDialogText("You won the battle!");
        //            break;
        //        case BattleState.Lost:
        //            //Interface.SetDialogText("You were defeated.");
        //            break;
        //        default:
        //            //Interface.SetDialogText("The match was a stalemate!");
        //            break;
        //    }
        //    yield break;
        //}
    }
}