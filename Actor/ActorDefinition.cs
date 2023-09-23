using System.Collections.Generic;
using UnityEngine;
using IdleGame.CharacterStats;

namespace IdleGame
{
    public class ActorDefinition : MonoBehaviour
    {
        #region Actors

        [SerializeField] public Actor actor;

        [SerializeField] public GameObject _head;
        [SerializeField] public GameObject _top;
        [SerializeField] public GameObject _bottom;
        [SerializeField] public GameObject _mainHand;
        [SerializeField] public GameObject _offHand;

        //private Character character;
        private Actor _enemy;
        public Actor Enemy => _enemy;

        private ActorDefinition _enemyDef;
        public ActorDefinition EnemyDef => _enemyDef;
        [SerializeField]
        private ParticleSystem gfx_DamageEffect;
        public ParticleSystem GFX_DamageEffect => gfx_DamageEffect;

        #region Player

        // Head Equipment
        public List<Sprite> _headWalkSprites { get; set; } = null;
        public List<Sprite> _headAttackOneHandSprites { get; set; } = null;
        public List<Sprite> _headAttackTwoHandSprites { get; set; } = null;
        public List<Sprite> _headDeathSprites { get; set; } = null;

        // Top Equipment
        public List<Sprite> _topWalkSprites { get; set; } = null;
        public List<Sprite> _topAttackOneHandSprites { get; set; } = null;
        public List<Sprite> _topAttackTwoHandSprites { get; set; } = null;
        public List<Sprite> _topDeathSprites { get; set; } = null;

        // Bottom Equipment
        public List<Sprite> _bottomWalkSprites { get; set; } = null;
        public List<Sprite> _bottomAttackOneHandSprites { get; set; } = null;
        public List<Sprite> _bottomAttackTwoHandSprites { get; set; } = null;
        public List<Sprite> _bottomDeathSprites { get; set; } = null;

        // Main Hand Equipment
        public List<Sprite> _mainHandWalkSprites { get; set; } = null;
        public List<Sprite> _mainHandAttackOneHandSprites { get; set; } = null;
        public List<Sprite> _mainHandAttackTwoHandSprites { get; set; } = null;
        public List<Sprite> _mainHandDeathSprites { get; set; } = null;

        // OffHand Equipment
        public List<Sprite> _offHandWalkSprites { get; set; } = null;
        public List<Sprite> _offHandAttackOneHandSprites { get; set; } = null;
        public List<Sprite> _offHandAttackTwoHandSprites { get; set; } = null;
        public List<Sprite> _offHandDeathSprites { get; set; } = null;

        #endregion Player

        #endregion Actors

        #region Boolleans

        private bool _enemyIsAlive = false;
        public bool EnemyIsAlive => _enemyIsAlive;

        [SerializeField]
        private bool _oneHanded = true;
        public bool OneHanded => _oneHanded;

        private bool _isInvisible = false;
        public bool IsInvisible => _isInvisible;

        #endregion Boolleans

        #region Counters

        private int _healthRegenCounter = 0;
        public int HealthRegenCounter => _healthRegenCounter;

        #endregion Counters

        #region State

        public STATE state = STATE.WALK;
        private STATE previousState = STATE.WALK;
        public enum STATE { WALK, ATTACK, DEAD, PAUSE };

        public bool isPaused;

        #endregion State

        #region Processing

        private void Awake()
        {
            if (this.tag == "Player")
            {
                actor.UpdatePlayerBonusStatistics();
                GameManager.playerObject = this.gameObject;
                
            }
            if (this.tag == "Enemy")
            {
                actor.UpdateEnemyStatistics();
                GameManager.enemyObject = this.gameObject;
            }
            //gfx_DamageEffect = GetComponent<ParticleSystem>();
            state = STATE.WALK;
            //actor.UpdateDamageEffect(gameObject.GetComponent<ParticleSystem>());
            isPaused = false;
            actor.ResetActor();
        }

        private float healthRegenSpeedCheck => GameManager.IsNormalSpeed == true ? 600f : 300f;

        private void FixedUpdate()
        {
            if (!isPaused)  // If not paused
            {
                _healthRegenCounter++;  // Increase 1 tick on regen timer
                if (HealthRegenCounter >= healthRegenSpeedCheck)  // After 10 seconds (Based on Fixed Time of 60FPS)
                {
                    _healthRegenCounter = 0;    // Reset counter
                    actor.RegenHP();    // Call regeneration for actor
                }
                switch (state)  // Checks actor's state
                {
                    case STATE.WALK:
                        actor.Walk(this);
                        break;
                    case STATE.ATTACK:
                        actor.Combat(this, Enemy, EnemyDef);
                        break;
                    case STATE.DEAD:
                        actor.Dead(this, this.actor);
                        break;
                    case STATE.PAUSE:
                        //Debug.Log($"{this.name} Previous State: {previousState}");
                        //Debug.Log($"{this.name} Previous State: {previousState}");
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (state)
                {
                    case STATE.WALK:
                    case STATE.ATTACK:
                    case STATE.DEAD:
                    previousState = this.state;
                        break;
                }
                this.state = STATE.PAUSE;
            }
            //Debug.Log($"{this.name} Previous State: {previousState} State : {state}");
            if (this.tag == "Player")
            {
                actor.UpdatePlayerBonusStatistics();
            }
        }

        public void IAmInvisibile()
        {
            _isInvisible = !_isInvisible;
        }

        public void UpdatedDifficulty()
        {
            actor.UpdateEnemyStatistics();
        }

        #endregion Processing

        #region Death Processing

        public void IGotHit()
        {
            if (!IsInvisible)
            {
                GameObject newObject = new GameObject();
                newObject.transform.SetParent(this.transform, false);
                //GameObject newObject = Instantiate(new GameObject(), this.transform, false);
                //newObject.name = "I WAS JUST MADE WHERE AM I!?!?!?";
                //newObject.transform.SetParent(this.transform, false);
                ParticleSystem particleSystem = gfx_DamageEffect;
                particleSystem = Instantiate(particleSystem, this.transform, false);
                //particleSystem.transform.SetParent(this.transform, true);
                //newObject.name = "THIS IS THE ONE THAT IS MADE";
                particleSystem.transform.SetParent(newObject.transform, false);
                Destroy(newObject, GameManager.IsNormalSpeed == true ? 1f : 0.5f);
            }
        }

        public void IDied()
        {
            this.GetComponent<BoxCollider2D>().enabled = false;
            GameManager.UpdateMonsterKill(actor.ActorID);
            this.state = STATE.DEAD;
            _enemyDef.state = STATE.WALK;
            _enemy.state = Actor.STATE.WALK;

            StartCoroutine(Enemy.EnemyVanish(EnemyDef));
        }

        public void IWillLiveAgain(int actorID)
        {
            switch (actorID)
            {
                case 0:
                    StartCoroutine(actor.LowRebirth(actor, this));
                    break;
                default:
                    GameManager.UpdateExperiencePerHour(this.actor.CurrentExperience);
                    this.actor = null;
                    this._enemy = null;
                    GameManager.enemyObject = null;
                    //Debug.Log($"I am {this.actor} and my enemy is {Enemy}");
                    Destroy(this.gameObject);
                    break;
            }
        }

        public void ILiveAagin()
        {
            this.GetComponent<BoxCollider2D>().enabled = true;
            actor.ResetActor();
        }

        #endregion Death Processing

        #region Actor Speed Manipulation

        public void PauseActor()
        {
            if (!isPaused)
                this.isPaused = true;
        }

        public void UnpauseActor()
        {
            if (isPaused)
            {
                this.state = previousState;
                this.isPaused = false;
            }
        }

        #endregion Actor Speed Manipulation

        public void LoadSavedGame(SaveGameData data)
        {
            actor.LoadPlayer(data);
        }
        public void Rebirth(float[] values)
        {
            actor.Rebirth(values);
        }

        #region Collision

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<ActorDefinition>())
            {
                this.state = STATE.ATTACK;
                Actor actor = other.GetComponent<ActorDefinition>().actor;
                if (actor != null)
                {
                    this._enemyDef = other.GetComponent<ActorDefinition>();
                    this._enemy = actor;
                    this._enemyIsAlive = true;
                }
            }
        }

        #endregion Collision
    }
}