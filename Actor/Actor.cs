using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System;
using UnityEngine.Serialization;

namespace IdleGame
{
    [CreateAssetMenu(fileName = "New Actor", menuName = "Actor")]
    [System.Serializable]
    public class Actor : ScriptableObject
    {
        #region Statistics

        // General stats
        #region General Statistics

        public STATE state = STATE.WALK;
        public enum STATE { WALK, ATTACK, DEAD };

        [SerializeField] private int _id;
        public int ActorID => _id;

        [SerializeField] private string _name;
        public string Name => _name;

        [SerializeField] private float _level;
        public float Level => _level;

        #endregion General Statistics

        #region Pool Statistics

        // Pool stats
        [SerializeField] private float _maxHealth;
        public float MaxHealth => _maxHealth;

        [SerializeField]
        private float _currentHealth;
        public float CurrentHealth => _currentHealth;

        [SerializeField] private float _regenHealth;
        public float RegenHealth => _regenHealth;

        [SerializeField] private float _maxMana;
        public float MaxMana => _maxMana;

        private float _currentMana;
        public float CurrentMana => _currentMana;

        [SerializeField] private float _regenMana;
        public float RegenMana => _regenMana;

        #endregion Pool Statistics

        #region Base Statistics

        // Base base stats
        [SerializeField] private float _baseStrength;
        public float BaseStrength => _baseStrength;

        [SerializeField] private float _baseIntelligence;
        public float BaseIntelligence => _baseIntelligence;

        [SerializeField] private float _baseConstitution;
        public float BaseConstitution => _baseConstitution;

        [SerializeField] private float _baseWisdom;
        public float BaseWisdom => _baseWisdom;

        [SerializeField] private float _baseAgility;
        public float BaseAgility => _baseAgility;

        [SerializeField] private float _baseDexterity;
        public float BaseDexterity => _baseDexterity;

        [SerializeField] private float _baseCharisma;
        public float BaseCharisma => _baseCharisma;

        [SerializeField] private float _baseLuck;
        public float BaseLuck => _baseLuck;

        #endregion Base Statistics

        #region Bonus Statistics

        // Bonus base stats
        private float _bonusStrength = 1f;
        public float BonusStrength => _bonusStrength;

        private float _bonusIntelligence = 1f;
        public float BonusIntelligence => _bonusIntelligence;

        private float _bonusWisdom = 1f;
        public float BonusWisdom => _bonusWisdom;

        private float _bonusConstitution = 1f;
        public float BonusConstitution => _bonusConstitution;

        private float _bonusAgility = 1f;
        public float BonusAgility => _bonusAgility;

        private float _bonusDexterity = 1f;
        public float BonusDexterity => _bonusDexterity;

        private float _bonusCharisma = 1f;
        public float BonusCharisma => _bonusCharisma;

        private float _bonusLuck = 1f;
        public float BonusLuck => _bonusLuck;

        #endregion Bonus Statistics

        #region Final Statistics

        // Final stats
        private float _finalStrength => BaseStrength + BonusStrength;
        public float FinalStrength => _finalStrength;

        private float _finalIntelligence => BaseIntelligence + BonusIntelligence;
        public float FinalIntelligence => _finalIntelligence;

        private float _finalWisdom => BaseWisdom + BonusWisdom;
        public float FinalWisdom => _finalWisdom;

        private float _finalConstitution => BaseConstitution + BonusConstitution;
        public float FinalConstitution => _finalConstitution;

        private float _finalAgility => BaseAgility + BonusAgility;
        public float FinalAgility => _finalAgility;

        private float _finalDexterity => BaseDexterity + BonusDexterity;
        public float FinalDexterity => _finalDexterity;

        private float _finalCharisma => BaseCharisma + BonusCharisma;
        public float FinalCharisma => _finalCharisma;

        private float _finalLuck => BaseLuck + BonusLuck;
        public float FinalLuck => _finalLuck;

        #endregion Final Statistics

        #region Combat Statistics

        // Combat stats
        private float _attack => (FinalStrength * (FinalDexterity / FinalAgility));
        public float Attack => _attack;
        private float _defense => (FinalConstitution * (FinalLuck / FinalAgility));
        public float Defense => _defense;

        private float _amountOfDamage;
        public float AmountOfDamage => _amountOfDamage;

        #region Defense Break

        [SerializeField]
        private float _defenseBreakLimit => Defense / 10;
        public float DefenseBreakLimit => _defenseBreakLimit;

        private float _currentDefenseBreak;
        public float CurrentDefenseBreak => _currentDefenseBreak;
        private float _defenseBreaker => (float)Mathf.Round(Attack / 10);
        public float DefenseBreaker => _defenseBreaker;
        private bool _defenseBroken => _currentDefenseBreak <= 0;

        #endregion Defense Break

        #endregion Combat Statistics

        #region Resources

        // Resources
        [SerializeField] private float _currentExperience;
        public float CurrentExperience => _currentExperience;

        [SerializeField] private float _requiredExperience;
        public float RequiredExperience => _requiredExperience;

        [SerializeField] private float _gold;
        public float Gold => _gold;

        #endregion Resources

        #region Particle Effects

        //public ParticleSystem gfx_DamageEffect;

        #endregion Particle Effects

        #region NPC Statistics

        [SerializeField]
        private float _moveSpeed;
        public float MoveSpeed => _moveSpeed;

        [SerializeField] private float _baseExperience;
        public float BaseExperience => _baseExperience;

        [SerializeField] private float _baseGold;
        public float BaseGold => _baseGold;

        #endregion NPC Statistics

        #endregion Statistics

        #region Animation Frames

        // WALKING
        [SerializeField]
        private List<Sprite> _walkSprites;
        public List<Sprite> WalkSprites => _walkSprites;
        public Sprite WalkSprite => _walkSprites[WalkFrame];
        private int _walkFrame = 0;
        public int WalkFrame => _walkFrame;

        // ATTACKING
        [SerializeField]
        private List<Sprite> _attackSpritesOneHanded;
        public List<Sprite> OneHandSprites => _attackSpritesOneHanded;
        public Sprite AttackSpriteOneHanded => _attackSpritesOneHanded[AttackFrameOneHanded];
        private int _attackFrameOneHanded = 0;
        public int AttackFrameOneHanded => _attackFrameOneHanded;

        [SerializeField]
        private List<Sprite> _attackSpritesTwoHanded;
        public List<Sprite> TwoHandSprites => _attackSpritesTwoHanded;
        public Sprite AttackSpriteTwoHanded => _attackSpritesTwoHanded[AttackFrameTwoHanded];
        private int _attackFrameTwoHanded = 0;
        public int AttackFrameTwoHanded => _attackFrameTwoHanded;

        // DEAD
        [SerializeField]
        private List<Sprite> _deathSprites;
        public List<Sprite> DeathSprites => _deathSprites;
        public Sprite DeathSprite => _deathSprites[DeathFrame];
        private int _deathFrame = 0;
        public int DeathFrame => _deathFrame;

        // Frame Manipulation
        [SerializeField]
        private int _framesPerSecond;
        public int FramesPerSecond => _framesPerSecond;

        [SerializeField]
        private int _baseFramesPerSecond;
        public int BaseFramesPerSecond => _baseFramesPerSecond;

        private int _currentFrame = 0;
        public int CurrentFrame => _currentFrame;


        private Sprite _currentSprite;
        public Sprite CurrentSprite => _currentSprite;

        #endregion Animation Frames 

        #region Booleans

        private bool _isDead;
        public bool IsDead => _isDead;

        private bool _rebirthing = false;
        public bool IsRebirthing => _rebirthing;

        //private static bool _isNormalSpeed;
        //public static bool IsNormalSpeed => _isNormalSpeed;
        private void Awake()
        {
            //_isNormalSpeed = GameManager.IsNormalSpeed;
        }
        //public void UpdateDamageEffect(ParticleSystem gfx)
        //{
        //    gfx_DamageEffect = gfx;
        //}

        #endregion Booleans

        #region Methods

        // Simple damage calculation
        public void Damage(float amount, ActorDefinition actorDefinition)
        {
            if (!_defenseBroken)
            {
                if (Defense < amount)
                {
                    _amountOfDamage = amount - Defense;
                    _currentHealth -= AmountOfDamage;
                    actorDefinition.IGotHit();
                }
                else
                {
                    _currentDefenseBreak -= actorDefinition.Enemy.DefenseBreaker;
                    if (_defenseBroken)
                    {
                        _currentHealth -= amount;
                        actorDefinition.IGotHit();
                        actorDefinition.IGotHit();
                    }
                }
            }
            else
            {
                _amountOfDamage = amount;
                _currentHealth -= AmountOfDamage;
            }


            if (CurrentHealth <= 0)
            {
                if (actorDefinition.tag == "Enemy")
                {
                    actorDefinition.Enemy.Reward(CurrentExperience, Gold);
                }
                actorDefinition.IDied();
            }
        }

        public void GainGold(float gold, int stacks)
        {
            _gold += gold * stacks;
        }

        public void UseItem(float amount)
        {
            if (!IsDead)
            {
                if (CurrentHealth + amount < MaxHealth)
                {
                    _currentHealth += amount;
                }
                else
                {
                    _currentHealth = MaxHealth;
                }
            }
        }
        public void RegenHP()
        {
            if (!IsDead)
            {
                if (CurrentHealth + RegenHealth < MaxHealth)
                {
                    _currentHealth += RegenHealth;
                }
                else
                {
                    _currentHealth = MaxHealth;
                }
            }
            //Debug.Log(CurrentHealth);
        }

        // Walk process
        public void Walk(ActorDefinition actor)
        {
            _currentFrame++; // Should increase the value of the "Count" every 1/60th of a second
            if (CurrentFrame >= FramesPerSecond)    // IF the currentFrame is >= FramesPerSecond(60/15 = 4 frames per second) update the actual frame
            {
                _walkFrame++;   // Update the current walk frame value
                if (WalkFrame == _walkSprites.Count - 1)    // If the current walkFrame is out of the index range, set to 0
                {
                    _walkFrame = 0;
                }
                _currentSprite = WalkSprite;     // Update the current sprite to be the walksprite
                actor.GetComponent<SpriteRenderer>().sprite = CurrentSprite;
                _currentFrame = 0;  // Reset the current frame to 0
                if (actor.tag == "Enemy")
                {
                    actor.transform.Translate(Vector2.left * (MoveSpeed * Time.deltaTime), Space.World);
                    //Debug.Log($"I am {actor} my transform.position.x is {actor.transform.position.x}");
                    if (actor.transform.position.x <= -3)
                    {
                        actor.IWillLiveAgain(this.ActorID);
                    }
                }
                else
                {
                    // Head
                    if (actor._headWalkSprites != null)
                    {
                        actor._head.GetComponent<SpriteRenderer>().sprite = actor._headWalkSprites[WalkFrame];
                    }
                    else
                    {
                        actor._head.GetComponent<SpriteRenderer>().sprite = null;
                    }

                    // Top
                    if (actor._topWalkSprites != null)
                    {
                        actor._top.GetComponent<SpriteRenderer>().sprite = actor._topWalkSprites[WalkFrame];
                    }
                    else
                    {
                        actor._top.GetComponent<SpriteRenderer>().sprite = null;
                    }

                    // Bottom
                    if (actor._bottomWalkSprites != null)
                    {
                        actor._bottom.GetComponent<SpriteRenderer>().sprite = actor._bottomWalkSprites[WalkFrame];
                    }
                    else
                    {
                        actor._bottom.GetComponent<SpriteRenderer>().sprite = null;
                    }

                    // Main Hand
                    if (actor._mainHandWalkSprites != null)
                    {
                        actor._mainHand.GetComponent<SpriteRenderer>().sprite = actor._mainHandWalkSprites[WalkFrame];
                    }
                    else
                    {
                        actor._mainHand.GetComponent<SpriteRenderer>().sprite = null;
                    }

                    // Two Hand
                    if (actor._offHandWalkSprites != null)
                    {
                        actor._offHand.GetComponent<SpriteRenderer>().sprite = actor._offHandWalkSprites[WalkFrame];
                    }
                    else
                    {
                        actor._offHand.GetComponent<SpriteRenderer>().sprite = null;
                    }
                }
            }
        }

        // Combat process
        public void Combat(ActorDefinition actor, Actor enemy, ActorDefinition enemyDef)
        {
            _currentFrame++; // Should increase the value of the "Count" every 1/60th of a second
            if (CurrentFrame >= FramesPerSecond)    // IF the currentFrame is >= FramesPerSecond(60/15 = 4 frames per second) update the actual frame
            {
                if (actor.OneHanded)
                {
                    _attackFrameOneHanded++;   // Update the current walk frame value
                    if (AttackFrameOneHanded == _attackSpritesOneHanded.Count - 1)    // If the current Frame is out of the index range, set to 0
                    {
                        _attackFrameOneHanded = 0;
                        enemy.Damage(this.Attack, enemyDef);
                        Debug.Log($"Actor: {actor.name} \n Enemy Current Health: {enemy.name} {enemy.CurrentHealth} Enemy Max Health: {enemy.MaxHealth}");
                    }
                    _currentSprite = AttackSpriteOneHanded;     // Update the current sprite to be the AttakSprite
                    if (actor.tag == "Player")
                    {
                        DressPlayerAttackingOneHand(actor);
                    }
                }
                else
                {
                    _attackFrameTwoHanded++;   // Update the current walk frame value
                    if (AttackFrameTwoHanded == _attackSpritesTwoHanded.Count - 1)    // If the current Frame is out of the index range, set to 0
                    {
                        _attackFrameTwoHanded = 0;
                        enemy.Damage(this.Attack, enemyDef);
                        //Debug.Log(enemy);
                    }
                    _currentSprite = AttackSpriteTwoHanded;     // Update the current sprite to be the AttakSprite
                    if (actor.tag == "Player")
                    {
                        DressPlayerAttackingTwoHand(actor);
                    }
                }
                actor.GetComponent<SpriteRenderer>().sprite = CurrentSprite;
                _currentFrame = 0;  // Reset the current frame to 0
            }
        }

        #region DressPlayerAttacking

        public void DressPlayerAttackingOneHand(ActorDefinition actor)
        {
            // Head
            if (actor._headAttackOneHandSprites != null)
            {
                actor._head.GetComponent<SpriteRenderer>().sprite = actor._headAttackOneHandSprites[AttackFrameOneHanded];
            }
            else
            {
                actor._head.GetComponent<SpriteRenderer>().sprite = null;
            }

            // Top
            if (actor._topAttackOneHandSprites != null)
            {
                actor._top.GetComponent<SpriteRenderer>().sprite = actor._topAttackOneHandSprites[AttackFrameOneHanded];
            }
            else
            {
                actor._top.GetComponent<SpriteRenderer>().sprite = null;
            }

            // Bottom
            if (actor._bottomAttackOneHandSprites != null)
            {
                actor._bottom.GetComponent<SpriteRenderer>().sprite = actor._bottomAttackOneHandSprites[AttackFrameOneHanded];
            }
            else
            {
                actor._bottom.GetComponent<SpriteRenderer>().sprite = null;
            }

            // Main Hand
            if (actor._mainHandAttackOneHandSprites != null)
            {
                actor._mainHand.GetComponent<SpriteRenderer>().sprite = actor._mainHandAttackOneHandSprites[AttackFrameOneHanded];
            }
            else
            {
                actor._mainHand.GetComponent<SpriteRenderer>().sprite = null;
            }

            // Two Hand
            if (actor._offHandAttackOneHandSprites != null)
            {
                actor._offHand.GetComponent<SpriteRenderer>().sprite = actor._offHandAttackOneHandSprites[AttackFrameOneHanded];
            }
            else
            {
                actor._offHand.GetComponent<SpriteRenderer>().sprite = null;
            }
        }
        public void DressPlayerAttackingTwoHand(ActorDefinition actor)
        {
            // Head
            if (actor._headAttackTwoHandSprites != null)
            {
                actor._head.GetComponent<SpriteRenderer>().sprite = actor._headAttackTwoHandSprites[AttackFrameTwoHanded];
            }
            else
            {
                actor._head.GetComponent<SpriteRenderer>().sprite = null;
            }

            // Top
            if (actor._topAttackTwoHandSprites != null)
            {
                actor._top.GetComponent<SpriteRenderer>().sprite = actor._topAttackTwoHandSprites[AttackFrameTwoHanded];
            }
            else
            {
                actor._top.GetComponent<SpriteRenderer>().sprite = null;
            }

            // Bottom
            if (actor._bottomAttackTwoHandSprites != null)
            {
                actor._bottom.GetComponent<SpriteRenderer>().sprite = actor._bottomAttackTwoHandSprites[AttackFrameTwoHanded];
            }
            else
            {
                actor._bottom.GetComponent<SpriteRenderer>().sprite = null;
            }

            // Main Hand
            if (actor._mainHandAttackTwoHandSprites != null)
            {
                actor._mainHand.GetComponent<SpriteRenderer>().sprite = actor._mainHandAttackTwoHandSprites[AttackFrameTwoHanded];
            }
            else
            {
                actor._mainHand.GetComponent<SpriteRenderer>().sprite = null;
            }

            // Two Hand
            if (actor._offHandAttackTwoHandSprites != null)
            {
                actor._offHand.GetComponent<SpriteRenderer>().sprite = actor._offHandAttackTwoHandSprites[AttackFrameTwoHanded];
            }
            else
            {
                actor._offHand.GetComponent<SpriteRenderer>().sprite = null;
            }
        }

        #endregion DressPlayerAttacking

        // Death process
        public void Dead(ActorDefinition actorDef, Actor actor)
        {
            //Debug.Log($"CurrentFrame: {CurrentFrame}");
            _currentFrame++; // Should increase the value of the "Count" every 1/60th of a second
            if (CurrentFrame >= FramesPerSecond)    // IF the currentFrame is >= FramesPerSecond(60/15 = 4 frames per second) update the actual frame
            {
                if (!IsDead)
                {
                    _deathFrame++;   // Update the current death frame value
                    if (DeathFrame <= _deathSprites.Count - 1)
                    {
                        _currentSprite = DeathSprite;     // Update the current sprite to be the deathprite
                        if (actorDef.tag == "Player")
                        {
                            DressPlayerDeath(actorDef);
                        }
                    }
                    else    // If the current deathFrame is the last one, set _isDead to true
                    {
                        _isDead = true; // Prevents looping of death animation
                    }
                }

                actorDef.GetComponent<SpriteRenderer>().sprite = CurrentSprite;
                _currentFrame = 0;  // Reset the current frame count to 0
                //Debug.Log($"_deathSprites.Count: {_deathSprites.Count}  \n DeathFrame: {DeathFrame}");
                if (actorDef.tag == "Enemy")
                {
                    actorDef.transform.Translate(Vector2.left * (MoveSpeed * Time.deltaTime), Space.World);
                    if (actorDef.transform.position.x <= -3)
                    {
                        GameManager.UpdateExperiencePerHour(CurrentExperience);
                        actorDef.IWillLiveAgain(actor.ActorID);
                    }
                }
                else
                {
                    if (!IsRebirthing)
                    {
                        _rebirthing = true;
                        actorDef.IWillLiveAgain(actor.ActorID);
                    }
                }
            }
        }

        #region DressPlayerDeath

        public void DressPlayerDeath(ActorDefinition actor)
        {
            // Head
            if (actor._headDeathSprites != null)
            {
                actor._head.GetComponent<SpriteRenderer>().sprite = actor._headDeathSprites[DeathFrame];
            }
            else
            {
                actor._head.GetComponent<SpriteRenderer>().sprite = null;
            }

            // Top
            if (actor._topDeathSprites != null)
            {
                actor._top.GetComponent<SpriteRenderer>().sprite = actor._topDeathSprites[DeathFrame];
            }
            else
            {
                actor._top.GetComponent<SpriteRenderer>().sprite = null;
            }

            // Bottom
            if (actor._bottomDeathSprites != null)
            {
                actor._bottom.GetComponent<SpriteRenderer>().sprite = actor._bottomDeathSprites[DeathFrame];
            }
            else
            {
                actor._bottom.GetComponent<SpriteRenderer>().sprite = null;
            }

            // Main Hand
            if (actor._mainHandDeathSprites != null)
            {
                actor._mainHand.GetComponent<SpriteRenderer>().sprite = actor._mainHandDeathSprites[DeathFrame];
            }
            else
            {
                actor._mainHand.GetComponent<SpriteRenderer>().sprite = null;
            }

            // Two Hand
            if (actor._offHandDeathSprites != null)
            {
                actor._offHand.GetComponent<SpriteRenderer>().sprite = actor._offHandDeathSprites[DeathFrame];
            }
            else
            {
                actor._offHand.GetComponent<SpriteRenderer>().sprite = null;
            }
        }

        #endregion DressPlayerAttacking

        #region Rewards

        public void Reward(float experience, float gold)
        {
            if (this.ActorID == 0)
            {
                _currentExperience += experience;
                if (CurrentExperience >= RequiredExperience)
                {
                    while (CurrentExperience >= RequiredExperience)
                    {
                        LevelUp();
                    }
                }
                _gold += gold;
            }

            _currentDefenseBreak = DefenseBreakLimit;
            //Debug.Log($"{name} Current Defense Break: {CurrentDefenseBreak}");
            //Debug.Log($"{name} Defense Break Limit: {DefenseBreakLimit}");
            //Debug.Log($"{name} Defense Breaker: {DefenseBreaker}");
            //Debug.Log($"{this} has recieved {experience} and their current experience is {CurrentExperience}");
        }

        public void ReturnReward(float experience, float gold, SaveGameData data)
        {
            if (this.ActorID == 0)
            {
                _bonusStrength = data.bonusStr;
                _bonusIntelligence = data.bonusInt;
                _bonusWisdom = data.bonusWis;
                _bonusConstitution = data.bonusCon;
                _bonusDexterity = data.bonusDex;
                _bonusAgility = data.bonusAgi;
                _bonusLuck = data.bonusLuk;
                _bonusCharisma = data.bonusCha;

                _currentExperience += Mathf.Round(experience);

                if (CurrentExperience >= RequiredExperience)
                {
                    while (CurrentExperience >= RequiredExperience)
                    {
                        LevelUp();
                    }
                }
                {
                    _gold += Mathf.Round(gold);
                }

                _currentHealth = MaxHealth;
                _currentDefenseBreak = DefenseBreakLimit;
            }
            //Debug.Log($"{name} Current Defense Break: {CurrentDefenseBreak}");
            //Debug.Log($"{name} Defense Break Limit: {DefenseBreakLimit}");
            //Debug.Log($"{name} Defense Breaker: {DefenseBreaker}");
            //Debug.Log($"{this} has recieved {experience} and their current experience is {CurrentExperience}");
        }
        private void LevelUp()
        {
            this._level++;
            this._requiredExperience = (Level * ((GameManager.WorldRank * GameManager.MonsterRank) + (100 * (Level + 1))));

            this._baseStrength += (float)Mathf.Round(this.ActorID == 0 ? 5f : this.BonusStrength / 10);
            this._baseIntelligence += (float)Mathf.Round(this.ActorID == 0 ? 5f : this.BonusIntelligence / 10);
            this._baseWisdom += (float)Mathf.Round(this.ActorID == 0 ? 5f : this.BonusWisdom / 10);
            this._baseConstitution += (float)Mathf.Round(this.ActorID == 0 ? 5f : this.BonusConstitution / 10);
            this._baseAgility += (float)Mathf.Round(this.ActorID == 0 ? 5f : this.BonusAgility / 10);
            this._baseDexterity += (float)Mathf.Round(this.ActorID == 0 ? 5f : this.BonusDexterity / 10);
            this._baseCharisma += (float)Mathf.Round(this.ActorID == 0 ? 5f : this.BonusCharisma / 10);
            this._baseLuck += (float)Mathf.Round(this.ActorID == 0 ? 5f : this.BonusLuck / 10);

            UpdatePlayerSecondaryStatitstics();
        }

        #endregion Rewards

        #region Statistical Adjustments

        //Used to set the currentHealth to max health when enemy is spawned, or player first starts the game.
        public void ResetActor()
        {
            this._currentHealth = this._maxHealth;
            this._walkFrame = 0;
            this._attackFrameOneHanded = 0;
            this._attackFrameTwoHanded = 0;
            this._currentFrame = 0;
            this._deathFrame = 0;
            this._isDead = false;
            this._rebirthing = false;
        }

        public void UpdateEnemySecondaryStatitstics()
        {
            /*MAXHP * (0.1 + (CON - Lv) * 0.01) (* as for maximum recovery quantity the 20% of MAXHP)*/
            this._currentExperience = (float)Mathf.Round(BaseExperience * ((GameManager.MonsterRank + (GameManager.MapRank + GameManager.WorldRank) * GameManager.PlayerRebirths)));
            while (CurrentExperience >= RequiredExperience)
            {
                LevelUp();
            }

            // Pool Stats
            this._maxHealth = (float)Mathf.Round((FinalConstitution / (Level + 1) * 50) + 25);
            this._regenHealth = (float)Mathf.Round(MaxHealth / 10);
            this._maxMana = (float)Mathf.Round((FinalWisdom / (Level + 1) * 50) + 25);
            this._regenMana = (float)Mathf.Round(MaxMana / 10);


            // Rewards
            this._gold = (float)Mathf.Round(BaseGold * (GameManager.MonsterRank + (GameManager.MapRank + GameManager.WorldRank)));

            this._currentDefenseBreak = DefenseBreakLimit;
            //Debug.Log($"Bonus Strength: {BonusStrength} Bonus Constitution: {BonusConstitution} GameManager: {GameManager.MapRank}{GameManager.MonsterRank}{GameManager.WorldRank}");
            //Debug.Log($"{this.name} Defense Break Limit: {DefenseBreakLimit}");
            //Debug.Log($"{this.name} Defense Breaker: {DefenseBreaker}");

        }
        public void UpdatePlayerSecondaryStatitstics()
        {
            /*MAXHP * (0.1 + (CON - Lv) * 0.01) (* as for maximum recovery quantity the 20% of MAXHP)*/
            this._maxHealth += (float)Mathf.Round((BaseConstitution / (Level + 1) * 50) + 25);
            this._regenHealth = (float)Mathf.Round(MaxHealth / 10);
            this._maxMana += (float)Mathf.Round((BaseWisdom / (Level + 1) * 50) + 25);
            this._regenMana = (float)Mathf.Round(MaxMana / 10);
        }

        // Player Bonuses must be kept updated
        public void UpdatePlayerBonusStatistics()
        {
            this._bonusStrength = Character.strengthLevel + 1;
            this._bonusIntelligence = Character.intelligenceLevel + 1;
            this._bonusWisdom = Character.wisdomLevel + 1;
            this._bonusConstitution = Character.constitutionLevel + 1;
            this._bonusDexterity = Character.dexterityLevel + 1;
            this._bonusAgility = Character.agilityLevel + 1;
            this._bonusLuck = Character.luckLevel + 1;
            this._bonusCharisma = Character.charismaLevel + 1;
        }

        public void UpdateEnemyStatistics()
        {
            this._bonusStrength = (GameManager.MapRank * (GameManager.MonsterRank + GameManager.WorldRank));
            this._bonusIntelligence = (GameManager.MapRank * (GameManager.MonsterRank + GameManager.WorldRank));
            this._bonusWisdom = (GameManager.MapRank * (GameManager.MonsterRank + GameManager.WorldRank));
            this._bonusConstitution = (GameManager.MapRank * (GameManager.MonsterRank + GameManager.WorldRank));
            this._bonusAgility = (GameManager.MapRank * (GameManager.MonsterRank + GameManager.WorldRank));
            this._bonusDexterity = (GameManager.MapRank * (GameManager.MonsterRank + GameManager.WorldRank));
            this._bonusCharisma = (GameManager.MapRank * (GameManager.MonsterRank + GameManager.WorldRank));
            this._bonusLuck = (GameManager.MapRank * (GameManager.MonsterRank + GameManager.WorldRank));
            UpdateEnemySecondaryStatitstics();
        }

        public void SpeedUpActor()
        {
            if (GameManager.IsNormalSpeed)
            {
                this._framesPerSecond = BaseFramesPerSecond / 2;
                //this._isNormalSpeed = false;
            }
        }

        public void SlowDownActor()
        {
            if (!GameManager.IsNormalSpeed)
            {
                this._framesPerSecond = BaseFramesPerSecond;
                //this._isNormalSpeed = true;
            }
        }

        public void LoadPlayer(SaveGameData data)
        {

            System.DateTime currentTime = new System.DateTime();
            currentTime = System.DateTime.Now;

            System.TimeSpan timeBetween = currentTime - data.lastSave;

            float totalSeconds = (float)timeBetween.TotalSeconds;
            Debug.Log($"Current Time {currentTime} Time Between {timeBetween} Total Seconds {totalSeconds} Experience To Reward Formula {(totalSeconds / 60) / 60}");

            float expToReward = data.experiencePerHour * ((totalSeconds / 60f) / 60f);      // Takes exact seconds and divides it to get a value based on total time, not just hours.
            Debug.Log($"Experience To Reward {expToReward} Experience Per Hour {data.experiencePerHour}");

            this._level = data.level;
            this._maxHealth = data.health;
            this._regenHealth = data.healthRegen;
            this._maxMana = data.mana;
            this._regenMana = data.manaRegen;

            this._baseStrength = data.str;
            this._baseIntelligence = data.intell;
            this._baseWisdom = data.wis;
            this._baseConstitution = data.con;
            this._baseDexterity = data.dex;
            this._baseAgility = data.agi;
            this._baseCharisma = data.cha;
            this._baseLuck = data.luk;

            this._currentExperience = data.curExp;
            this._requiredExperience = data.reqExp;
            this._gold = data.gold;
            ReturnReward(expToReward, 0f, data);
        }

        #region Rebirthing

        public IEnumerator EnemyVanish(ActorDefinition actor)
        {
            yield return new WaitForSeconds(timeToWaitForLowRebirth / 2f);
            if (GameManager.IsPaused)
            {
                actor.IWillLiveAgain(actor.GetComponent<ActorDefinition>().actor.ActorID);
            }
        }

        private float timeToWaitForLowRebirth => GameManager.IsNormalSpeed == true ? 5f : 2.5f;

        public IEnumerator LowRebirth(Actor actor, ActorDefinition actorDef)
        {
            yield return new WaitForSeconds(timeToWaitForLowRebirth);
            
            if (actor.IsRebirthing)
            {
                actor._level = 1;
                actor._currentExperience = 0;
                actor._requiredExperience = 100;
                actor._maxHealth = Mathf.Round(actor._maxHealth / 2);
                actor._currentHealth = Mathf.Round(actor._maxHealth);
                actor._maxMana = Mathf.Round(actor._maxMana / 2);
                actor._currentMana = Mathf.Round(actor._maxMana);

                actor._baseStrength = Mathf.Round(actor._baseStrength / 2);
                actor._baseIntelligence = Mathf.Round(actor._baseIntelligence / 2);
                actor._baseWisdom = Mathf.Round(actor._baseWisdom / 2);
                actor._baseConstitution = Mathf.Round(actor._baseConstitution / 2);
                actor._baseDexterity = Mathf.Round(actor._baseDexterity / 2);
                actor._baseAgility = Mathf.Round(actor._baseAgility / 2);
                actor._baseLuck = Mathf.Round(actor._baseLuck / 2);
                actor._baseCharisma = Mathf.Round(actor._baseCharisma / 2);

                actor._gold = Mathf.Round(actor._gold / 2);
                actor.state = STATE.WALK;
                actorDef.state = ActorDefinition.STATE.WALK;
                actor._rebirthing = false;
                actorDef.ILiveAagin();
                GameManager.UpdateLowRebirths();
            }
        }

        public void Rebirth(float[] values)
        {
            this._level = 1;
            //Debug.Log($"Strength being sent from Actor values[0]: {values[0]}");

            this._currentExperience = 0;
            this._requiredExperience = 100 * (GameManager.TotalPlayerRebirths + 1);

            this._baseStrength = values[0] + (5 * (GameManager.PlayerRebirths + (GameManager.WorldRank + GameManager.MonsterRank)));
            this._baseIntelligence = values[1] + (5 * (GameManager.PlayerRebirths + (GameManager.WorldRank + GameManager.MonsterRank)));
            this._baseWisdom = values[2] + (5 * (GameManager.PlayerRebirths + (GameManager.WorldRank + GameManager.MonsterRank)));
            this._baseConstitution = values[3] + (5 * (GameManager.PlayerRebirths + (GameManager.WorldRank + GameManager.MonsterRank)));
            this._baseDexterity = values[4] + (5 * (GameManager.PlayerRebirths + (GameManager.WorldRank + GameManager.MonsterRank)));
            this._baseAgility = values[5] + (5 * (GameManager.PlayerRebirths + (GameManager.WorldRank + GameManager.MonsterRank)));
            this._baseLuck = values[6] + (5 * (GameManager.PlayerRebirths + (GameManager.WorldRank + GameManager.MonsterRank)));
            this._baseCharisma = values[7] + (5 * (GameManager.PlayerRebirths + (GameManager.WorldRank + GameManager.MonsterRank)));

            this._maxHealth = 100 * (GameManager.TotalPlayerRebirths + 1);
            this._currentHealth = MaxHealth;
            this._maxMana = 100 * (GameManager.TotalPlayerRebirths + 1);
            this._currentMana = MaxMana;
        }


        #endregion Rebirthing

        #endregion Statistical Adjustments

        #endregion Methods
    }
}