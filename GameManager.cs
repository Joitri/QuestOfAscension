using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IdleGame;
using System;
[System.Serializable()]
public class GameManager : Singleton<GameManager>
{
    // Begin new game as null
    public static GameManager instance;
    // Fields able to be adjusted in unity interface
    //[SerializeField] private GameObject mainMenu;
    public static BackgroundController[] backgrounds;
    public static Spawner spawner;
    private static Rebirth rebirth;
    public static float[] rebirthValues;

    // bools to check game states
    private bool playerActive = false;
    private bool gameOver = false;
    private bool gameStarted = false;

    private static bool _isPaused;
    public static bool IsPaused => _isPaused;

    // Speed of game
    private static bool _isNormalSpeed = true;
    public static bool IsNormalSpeed => _isNormalSpeed;

    // Timer
    private int _timeCounter;
    private const int FIXEDTIME = 3600; // 60 FPS * 60 seconds = 3600 (1 minute)
    private int CurrentTimeSpeed => IsNormalSpeed == true ? FIXEDTIME : FIXEDTIME / 2;


    #region Difficulty

    // Ranks
    private static float _worldRank = 1f;
    public static float WorldRank => _worldRank;

    private static float _monsterRank = 1f;
    public static float MonsterRank => _monsterRank;

    private static float _mapCounter = 1f;
    public static float MapCounter => _mapCounter;

    private static float _mapRank = 1f;
    public static float MapRank => _mapRank;

    // Highest Rank Scores

    private static float _highestWorldRank;
    public static float HighestWorldRank => _highestWorldRank;

    //private static float _highestMapRank;
    //public static float HighestMapRank => _highestMapRank;

    private static float _highestMonsterRank;
    public static float HighestMonsterRank => _highestMonsterRank;

    private static float _highestTotalMonsterCounter;
    public static float HighestTotalMonsterCount => _highestTotalMonsterCounter;

    // Individual Map Scores
    private static float _highestFireMapRank;
    public static float HighestFireMapRank => _highestFireMapRank;

    private static float _highestEarthMapRank;
    public static float HighestEarthMapRank => _highestEarthMapRank;

    private static float _highestWindMapRank;
    public static float HighestWindMapRank => _highestWindMapRank;

    private static float _highestWaterMapRank;
    public static float HighestWaterMapRank => _highestWaterMapRank;

    // Map Tracking
    private static float _currentMapId;
    public static float CurrentMapId => _currentMapId;

    #endregion Difficulty

    #region Kill Counters

    private static float _currentMonsterCounter;
    public static float CurrentMonsterCounter => _currentMonsterCounter;

    private static float _totalMonsterCounter;
    public static float TotalMonsterCounter => _totalMonsterCounter;

    // Player Deaths
    private static float _playerDeaths;
    public static float PlayerDeaths => _playerDeaths;

    // Rebirths
    private static float _playerRebirths;
    public static float PlayerRebirths => _playerRebirths;

    private static float _playerLowRebirths;
    public static float PlayerLowRebirths => _playerLowRebirths;

    private static float _totalPlayerRebirths => PlayerLowRebirths + PlayerRebirths;
    public static float TotalPlayerRebirths => _totalPlayerRebirths;

    // Monster Counters
    // Rat
    private static float _totalRatKills;
    public static float TotalRatKills => _totalRatKills;

    private static float _ratKills;
    public static float RatKills => _ratKills;

    // Wolf
    private static float _totalWolfKills;
    public static float TotalWolfKills => _totalWolfKills;

    private static float _wolfKills;
    public static float WolfKills => _wolfKills;

    // Zombie
    private static float _totalZombieKills;
    public static float TotalZombieKills => _totalZombieKills;

    private static float _zombieKills;
    public static float ZombieKills => _zombieKills;

    // Zombie
    private static float _totalGhoulKills;
    public static float TotalGhoulKills => _totalGhoulKills;

    private static float _ghoulKills;
    public static float GhoulKills => _ghoulKills;

    // Skeleton
    private static float _totalSkeletonKills;
    public static float TotalSkeletonKills => _totalSkeletonKills;

    private static float _skeletonKills;
    public static float SkeletonKills => _skeletonKills;

    // Zombie
    private static float _totalBruteKills;
    public static float TotalBruteKills => _totalBruteKills;

    private static float _bruteKills;
    public static float BruteKills => _bruteKills;

    #endregion Kill Counters

    /* TO DO */
    #region Distance

    //private int _currentMapDistance;
    //public int CurrentMapDistance => _currentMapDistance;

    //private int _totalMapDistance;
    //public int TotalMapDistance => _totalMapDistance;

    #endregion Distance

    #region Save System

    public static GameObject enemyObject;
    [SerializeField] public static GameObject playerObject;
    
    // Idler variables
    public static System.DateTime lastSaveTime;
    private static List<float> experiencePoolValues;
    public static float currentExperiencePool;
    public static float experiencePerHour;
    [SerializeField] public GameObject equipmentPanel;
    [SerializeField ] public static EquipmentPanel equipPanel;
    [SerializeField] public static Inventory inventory;

    // USED TO CHECK HOW TO FIND EQUIPMENT
    //private void CheckHowToSaveEquipment()
    //{
    //    foreach (EquipmentSlot itemSlot in equipmentPanel.GetComponentsInChildren<EquipmentSlot>())
    //    {
    //        Debug.Log($"{itemSlot.Item}");
    //    }
    //    //Debug.Log($"{character.GetComponentsInChildren<ItemSlot>()}");
    //}

    public static void SaveGame()
    {
        SaveSystem.SaveGameData(playerObject);
    }

    public void LoadGame()
    {
        SaveGameData data = SaveSystem.LoadGameData();

        if (data != null)
        {
            if (playerObject == null)
            {
                playerObject = GameObject.FindGameObjectWithTag("Player");
            }

            if (playerObject != null)
            {
                //equipmentPanel.enabled = true;
                //equipmentPanel.GetComponent<EquipmentPanel>().enabled = true;
                playerObject.GetComponent<ActorDefinition>().LoadSavedGame(data);
            }
            _worldRank = data.wRank;
            _monsterRank = data.mRank;
            //_highestMapRank = data.hMapRank;
            _currentMonsterCounter = data.cMonsterCounter;
            _totalMonsterCounter = data.tMonsterCounter;
            _ratKills = data.cRat;
            _totalRatKills = data.tRat;
        }

        UpdateDifficulty();

        if (enemyObject == null)
        {
            enemyObject = GameObject.FindGameObjectWithTag("Enemy");
            //Debug.Log($"Enemy: {enemyObject.name}");
            if (enemyObject != null)
            {
                if (enemyObject.GetComponent<ActorDefinition>())
                {
                    enemyObject.GetComponent<ActorDefinition>().UpdatedDifficulty();
                }
            }
        }
        else
        {
            if (enemyObject.GetComponent<ActorDefinition>())
            {
                enemyObject.GetComponent<ActorDefinition>().UpdatedDifficulty();
            }
        }
    }


    public static void UpdateExperiencePerHour(float value)
    {
        // If the number is at 5... or higher for some reason...
        if (experiencePoolValues.Count >= 5)
        {
            experiencePoolValues.RemoveAt(0);
        }
        
        experiencePoolValues.Add(value);

        // Reset current experience pool
        currentExperiencePool = 0f;

        // Adjust base value by number of floats in collection
        foreach (float f in experiencePoolValues)
        {
            currentExperiencePool += f;
        }

        // Multiply by average of minutes in an hour (5 kills an hour)
        experiencePerHour = currentExperiencePool * 60f;
        if (experiencePoolValues.Count < 5)
            Debug.Log($"ExperiencePoolValue.Count: {experiencePoolValues.Count} Value at [0]: {experiencePoolValues[0]}");
        else
            Debug.Log($"ExperiencePoolValue.Count: {experiencePoolValues.Count} Value at [0]: {experiencePoolValues[0]} Value at [4]: {experiencePoolValues[4]}");
        Debug.Log($"CurrentExperiencePool: {currentExperiencePool} ExperiencePerHour: {experiencePerHour}");
    }

    public static void UpdateMapRanks(float id)
    {
        // Checks current map id and updates highest value achieved at the time
        switch (CurrentMapId)
        {
            case 1:
                if (MapRank > HighestEarthMapRank)
                {
                    _highestEarthMapRank = MapCounter;
                }
                break;
            case 2:
                if (MapRank > HighestFireMapRank)
                {
                    _highestFireMapRank = MapCounter;
                }
                break;
            case 3:
                if (MapRank > HighestWindMapRank)
                {
                    _highestWindMapRank = MapCounter;
                }
                break;
            case 4:
                if (MapRank > HighestWaterMapRank)
                {
                    _highestWaterMapRank = MapCounter;
                }
                break;
        }
        if (id != 0)
        {
            _mapCounter = 1f;
            _mapRank = 1f;
            _currentMapId = id;
        }
    }

    public static void LoadBags()
    {

    }

    #endregion Save System

    #region Unity Processing

    private void Awake()
    {
        //Debug.Log($"GameManager Just Woke Up! {System.DateTime.Now.ToBinary()}");
        _currentMapId = 1;
        rebirth = new Rebirth();
        backgrounds = GameObject.FindObjectsOfType<BackgroundController>();
        spawner = GameObject.FindObjectOfType<Spawner>();
        _timeCounter = 0;
        _isNormalSpeed = true;

        if (playerObject == null)
        {
            playerObject = GameObject.FindWithTag("Player");
        }

        rebirthValues = new float[8];
        rebirthValues = rebirth.RebirthValues();
        _isPaused = false;
        experiencePoolValues = new List<float>();
    }

    private void Start()
    {
        LoadGame();
    }

    private void FixedUpdate()
    {
        if (!IsPaused)
        {
            _timeCounter++;
        }
        //Debug.Log($"{WorldRank} {MonsterRank} {MapRank}");
        switch (_timeCounter)
        {
            //case 0:
            //    Debug.Log($"COUNT DOWN TO DIFFICULTY UPDATE... 10");
            //    break;
            //case 60:
            //    Debug.Log($"COUNT DOWN TO DIFFICULTY UPDATE... 9");
            //    break;
            //case 120:
            //    Debug.Log($"COUNT DOWN TO DIFFICULTY UPDATE... 8");
            //    break;
            //case 180:
            //    Debug.Log($"COUNT DOWN TO DIFFICULTY UPDATE... 7");
            //    break;
            //case 240:
            //    Debug.Log($"COUNT DOWN TO DIFFICULTY UPDATE... 6");
            //    break;
            //case 300:
            //    Debug.Log($"COUNT DOWN TO DIFFICULTY UPDATE... 5");
            //    break;
            //case 360:
            //    Debug.Log($"COUNT DOWN TO DIFFICULTY UPDATE... 4...");
            //    break;
            //case 420:
            //    Debug.Log($"COUNT DOWN TO DIFFICULTY UPDATE... 3......");
            //    break;
            //case 480:
            //    Debug.Log($"COUNT DOWN TO DIFFICULTY UPDATE... 2..........");
            //    break;
            //case 540:
            //    Debug.Log($"COUNT DOWN TO DIFFICULTY UPDATE... 1.............");
            //    break;
            // Sped Up Timer
            case 1200:
                if (!IsNormalSpeed)
                {
                    Debug.Log($"COUNT DOWN TO DIFFICULTY UPDATE... 10");
                }
                break;
            case 1260:
                if (!IsNormalSpeed)
                {
                    Debug.Log($"COUNT DOWN TO DIFFICULTY UPDATE... 9");
                }
                break;
            case 1320:
                if (!IsNormalSpeed)
                {
                    Debug.Log($"COUNT DOWN TO DIFFICULTY UPDATE... 8");
                }
                break;
            case 1380:
                if (!IsNormalSpeed)
                {
                    Debug.Log($"COUNT DOWN TO DIFFICULTY UPDATE... 7");
                }
                break;
            case 1440:
                if (!IsNormalSpeed)
                {
                    Debug.Log($"COUNT DOWN TO DIFFICULTY UPDATE... 6");
                }
                break;
            case 1500:
                if (!IsNormalSpeed)
                {
                    Debug.Log($"COUNT DOWN TO DIFFICULTY UPDATE... 5");
                }
                break;
            case 1560:
                if (!IsNormalSpeed)
                {
                    Debug.Log($"COUNT DOWN TO DIFFICULTY UPDATE... 4...");
                }
                break;
            case 1620:
                if (!IsNormalSpeed)
                {
                    Debug.Log($"COUNT DOWN TO DIFFICULTY UPDATE... 3......");
                }
                break;
            case 1680:
                if (!IsNormalSpeed)
                {
                    Debug.Log($"COUNT DOWN TO DIFFICULTY UPDATE... 2..........");
                }
                break;
            case 1740:
                if (!IsNormalSpeed)
                {
                    Debug.Log($"COUNT DOWN TO DIFFICULTY UPDATE... 1.............");
                }
                break;
            // Normal Timer
            case 3000:
                Debug.Log($"COUNT DOWN TO DIFFICULTY UPDATE... 10");
                break;
            case 3060:
                Debug.Log($"COUNT DOWN TO DIFFICULTY UPDATE... 9");
                break;
            case 3120:
                Debug.Log($"COUNT DOWN TO DIFFICULTY UPDATE... 8");
                break;
            case 3180:
                Debug.Log($"COUNT DOWN TO DIFFICULTY UPDATE... 7");
                break;
            case 3240:
                Debug.Log($"COUNT DOWN TO DIFFICULTY UPDATE... 6");
                break;
            case 3300:
                Debug.Log($"COUNT DOWN TO DIFFICULTY UPDATE... 5");
                break;
            case 3360:
                Debug.Log($"COUNT DOWN TO DIFFICULTY UPDATE... 4...");
                break;
            case 3420:
                Debug.Log($"COUNT DOWN TO DIFFICULTY UPDATE... 3......");
                break;
            case 3480:
                Debug.Log($"COUNT DOWN TO DIFFICULTY UPDATE... 2..........");
                break;
            case 3540:
                Debug.Log($"COUNT DOWN TO DIFFICULTY UPDATE... 1.............");
                break;
        }   // Switch Used For Debug.Log Timers - Sends Warning Based On Time

        //Debug.Log($"Experience Per Hour: {experiencePerHour}");
        //experiencePerHour = currentExperiencePool * 360;    // Current kill experience multiplied for 6 monsters every minute for 1 hour (currentExperience * (6 * 60))

        if (_timeCounter >= CurrentTimeSpeed)
        {
            _mapCounter++;
            UpdateMapRanks(0f);
            UpdateDifficulty();
            lastSaveTime = System.DateTime.Now;
            if (enemyObject != null)
            {
                //Debug.Log($"Enemy: {enemyObject.name}");
                if (enemyObject.GetComponent<ActorDefinition>())
                {
                    enemyObject.GetComponent<ActorDefinition>().UpdatedDifficulty();
                }
            }
            SaveGame();
            _timeCounter = 0;
            //Debug.Log($"Map Counter {MapCounter} Map Rank {MapRank}");
        }
        rebirthValues = rebirth.RebirthValues();
        //CheckHowToSaveEquipment();
    }


    #endregion Unity Processing

    #region Update Methods

    public static void UpdateMonsterKill(int id)
    {
        // Check ID of incoming actor
        switch (id)
        {
            // Player death
            case 0:
                _playerDeaths++;
                //Debug.Log($"Player has died : {PlayerDeaths} times");
                break;

            // NORMAL KILLS
            // Rats
            case 1:
            case 2:
            case 3:
            case 4:
                _ratKills++;
                // Update Total
                if (RatKills > TotalRatKills)
                {
                    _totalRatKills = RatKills;
                }
                break;

            // Wolves
            case 101:
            case 102:
            case 103:
            case 104:
                _wolfKills++;
                // Update Total
                if (WolfKills > TotalWolfKills)
                {
                    _totalWolfKills = WolfKills;
                }
                break;

            // Zombies
            case 201:
            case 202:
            case 203:
            case 204:
            case 205:
            case 206:
                _zombieKills++;
                // Update Total
                if (ZombieKills > TotalZombieKills)
                {
                    _totalZombieKills = ZombieKills;
                }
                break;

            // Ghouls
            case 301:
                _ghoulKills++;
                // Update Total
                if (GhoulKills > TotalGhoulKills)
                {
                    _totalGhoulKills = GhoulKills;
                }
                break;

            // Skeletons
            case 401:
            case 402:
                _skeletonKills++;
                // Update Total
                if (SkeletonKills > TotalSkeletonKills)
                {
                    _totalSkeletonKills = SkeletonKills;
                }
                break;

            // Brutes
            case 501:
            case 502:
            case 503:
            case 504:
                _bruteKills++;
                // Update Total
                if (BruteKills > TotalBruteKills)
                {
                    _totalBruteKills = BruteKills;
                }
                break;

            // 
            case 601:
                break;

            // BOSS KILLS
            case 1000:
                _skeletonKills++;
                // Update Total
                if (SkeletonKills > TotalSkeletonKills)
                {
                    _totalSkeletonKills = SkeletonKills;
                }
                break;
        }


        //Debug.Log($"Current Monster Counter: {CurrentMonsterCounter}");
        //Debug.Log($"Current Map Counter: {MapCounter}");
        //Debug.Log($"Current Map Rank: {MapRank}");
        //Debug.Log($"Current Monster Rank: {MonsterRank}");
        //Debug.Log($"Current World Rank: {WorldRank}");

        if (id != 0f)
        {
            _currentMonsterCounter++;
            //_currentMonsterCounter += 10000;
            //_totalMonsterCounter += 10000;
            _totalMonsterCounter++;
        }
        else
        {
            if (TotalMonsterCounter > HighestTotalMonsterCount)
            {
                _highestTotalMonsterCounter = TotalMonsterCounter;
            }
            if (WorldRank > HighestWorldRank)
            {
                _highestWorldRank = WorldRank;
            }
            _currentMonsterCounter = 0;
            _totalMonsterCounter = 0;
            _playerLowRebirths++;
        }

        if (id > 999f)
        {
            _mapCounter++;
            UpdateMapRanks(0f);
        }

        SaveGame();
        UpdateDifficulty();
    }

    private static void UpdateDifficulty()
    {
        #region Monster Rank

        // Current Monster Kills
        if (CurrentMonsterCounter <= 100)
        {
            _monsterRank = 1;
        }
        if (CurrentMonsterCounter >= 100 && CurrentMonsterCounter <= 250)
        {
            _monsterRank = 2;
        }
        if (CurrentMonsterCounter >= 250 && CurrentMonsterCounter <= 500)
        {
            _monsterRank = 3;
        }
        if (CurrentMonsterCounter >= 500 && CurrentMonsterCounter <= 1000)
        {
            _monsterRank = 4;
        }
        if (CurrentMonsterCounter >= 1000 && CurrentMonsterCounter <= 2500)
        {
            _monsterRank = 5;
        }
        if (CurrentMonsterCounter >= 2500 && CurrentMonsterCounter <= 5000)
        {
            _monsterRank = 6;
        }
        if (CurrentMonsterCounter >= 5000 && CurrentMonsterCounter <= 10000)
        {
            _monsterRank = 7;
        }
        if (CurrentMonsterCounter >= 10000 && CurrentMonsterCounter <= 25000)
        {
            _monsterRank = 8;
        }
        if (CurrentMonsterCounter >= 25000 && CurrentMonsterCounter <= 50000)
        {
            _monsterRank = 9;
        }
        if (CurrentMonsterCounter >= 50000 && CurrentMonsterCounter <= 100000)
        {
            _monsterRank = 10;
        }
        if (CurrentMonsterCounter >= 100000 && CurrentMonsterCounter <= 250000)
        {
            _monsterRank = 11;
        }
        if (CurrentMonsterCounter >= 250000 && CurrentMonsterCounter <= 500000)
        {
            _monsterRank = 12;
        }
        if (CurrentMonsterCounter >= 500000 && CurrentMonsterCounter <= 1000000)
        {
            _monsterRank = 13;
        }
        if (CurrentMonsterCounter >= 1000000 && CurrentMonsterCounter <= 2500000)
        {
            _monsterRank = 14;
        }
        if (CurrentMonsterCounter >= 2500000 && CurrentMonsterCounter <= 5000000)
        {
            _monsterRank = 15;
        }
        if (CurrentMonsterCounter >= 5000000 && CurrentMonsterCounter <= 1000000)
        {
            _monsterRank = 16;
        }
        if (CurrentMonsterCounter >= 10000000 && CurrentMonsterCounter <= 100000000)
        {
            _monsterRank = 17;
        }
        if (CurrentMonsterCounter >= 100000000 && CurrentMonsterCounter <= 500000000)
        {
            _monsterRank = 18;
        }
        if (CurrentMonsterCounter >= 50000000 && CurrentMonsterCounter <= 2147483647)
        {
            _monsterRank = 19;
        }
        if (CurrentMonsterCounter >= 2147483647)
        {
            _monsterRank = 20;
        }

        #endregion Monster Rank

        // Does not reset
        #region World Rank

        if (TotalMonsterCounter < 1000)
        {
            _worldRank = 1;
        }
        if (TotalMonsterCounter > 1000 && TotalMonsterCounter < 2500)
        {
            _worldRank = 2;
        }
        if (TotalMonsterCounter > 2500 && TotalMonsterCounter < 5000)
        {
            _worldRank = 3;
        }
        if (TotalMonsterCounter > 5000 && TotalMonsterCounter < 10000)
        {
            _worldRank = 4;
        }
        if (TotalMonsterCounter > 10000 && TotalMonsterCounter < 25000)
        {
            _worldRank = 5;
        }
        if (TotalMonsterCounter > 25000 && TotalMonsterCounter < 50000)
        {
            _worldRank = 6;
        }
        if (TotalMonsterCounter > 50000 && TotalMonsterCounter < 100000)
        {
            _worldRank = 7;
        }
        if (TotalMonsterCounter > 100000 && TotalMonsterCounter < 250000)
        {
            _worldRank = 8;
        }
        if (TotalMonsterCounter > 250000 && TotalMonsterCounter < 500000)
        {
            _worldRank = 9;
        }
        if (TotalMonsterCounter > 500000 && TotalMonsterCounter < 1000000)
        {
            _worldRank = 10 + PlayerRebirths;
        }
        if (TotalMonsterCounter > 1000000 && TotalMonsterCounter < 2500000)
        {
            _worldRank = 11 + PlayerRebirths;
        }
        if (TotalMonsterCounter > 2500000 && TotalMonsterCounter < 5000000)
        {
            _worldRank = 12 + PlayerRebirths;
        }
        if (TotalMonsterCounter > 5000000 && TotalMonsterCounter < 10000000)
        {
            _worldRank = 13 + PlayerRebirths;
        }
        if (TotalMonsterCounter > 10000000 && TotalMonsterCounter < 25000000)
        {
            _worldRank = 14 + PlayerRebirths;
        }
        if (TotalMonsterCounter > 25000000 && TotalMonsterCounter < 50000000)
        {
            _worldRank = 15 + PlayerRebirths;
        }
        if (TotalMonsterCounter > 50000000 && TotalMonsterCounter < 10000000)
        {
            _worldRank = 16 + PlayerRebirths;
        }
        if (TotalMonsterCounter > 100000000 && TotalMonsterCounter < 1000000000)
        {
            _worldRank = 17 + PlayerRebirths;
        }
        if (TotalMonsterCounter > 1000000000 && TotalMonsterCounter < 5000000000)
        {
            _worldRank = 18 + PlayerRebirths;
        }
        if (TotalMonsterCounter > 500000000 && TotalMonsterCounter < 21474836470)
        {
            _worldRank = 19 + PlayerRebirths;
        }
        if (TotalMonsterCounter >= 21474836470)
        {
            // If player has manually rebirthed more than 25 times, they are in for a treat...
            _worldRank = PlayerRebirths >= 25f ? 20f * PlayerRebirths : 20f + PlayerRebirths;
        }

        #endregion World Rank

        /* TO DO */
        /* Modify Map Rank based on World Rank and Monster Rank and Time Played In Map */
        /* SERIOUS BALANCING REQUIRED! */
        #region Map Rank


        switch (WorldRank)
        {
            case 1:
                _mapRank = (WorldRank * MonsterRank) * MapCounter;
                break;
            case 2:
                _mapRank = ((WorldRank * MonsterRank) * 2) * MapCounter;
                break;
            case 3:
                _mapRank = ((WorldRank * MonsterRank) * 3) * MapCounter;
                break;
            case 4:
                _mapRank = ((WorldRank * MonsterRank) * 4) * MapCounter;
                break;
            case 5:
                _mapRank = ((WorldRank * MonsterRank) * 5) * MapCounter;
                break;
            case 6:
                _mapRank = ((WorldRank * MonsterRank) * 10) * MapCounter;
                break;
            case 7:
                _mapRank = ((WorldRank * MonsterRank) * 25) * MapCounter;
                break;
            case 8:
                _mapRank = ((WorldRank * MonsterRank) * 50) * MapCounter;
                break;
            case 9:
                _mapRank = ((WorldRank * MonsterRank) * 75) * MapCounter;
                break;
            case 10:
                _mapRank = ((WorldRank * MonsterRank) * 100) * MapCounter;
                break;
            case 11:
                _mapRank = ((WorldRank * MonsterRank) * 150) * MapCounter;
                break;
            case 12:
                _mapRank = ((WorldRank * MonsterRank) * 250) * MapCounter;
                break;
            case 13:
                _mapRank = ((WorldRank * MonsterRank) * 500) * MapCounter;
                break;
            case 14:
                _mapRank = ((WorldRank * MonsterRank) * 750) * MapCounter;
                break;
            case 15:
                _mapRank = ((WorldRank * MonsterRank) * 1000) * MapCounter;
                break;
            case 16:
                _mapRank = ((WorldRank * MonsterRank) * 1500) * MapCounter;
                break;
            case 17:
                _mapRank = ((WorldRank * MonsterRank) * 3000) * MapCounter;
                break;
            case 18:
                _mapRank = ((WorldRank * MonsterRank) * 6000) * MapCounter;
                break;
            case 19:
                _mapRank = ((WorldRank * MonsterRank) * 12000) * MapCounter;
                break;
            case 20:
                _mapRank = ((WorldRank * MonsterRank) * 24000) * MapCounter;
                break;
        }
        //Debug.Log($"Map Counter: {MapCounter}");
        #endregion Map Rank
    }

    public static void UpdateLowRebirths()
    {
        _playerLowRebirths++;

        ResetKillCounters();
        ResetRanks();
    }

    #endregion Update Methods

    #region Rebirthing

    public static void Rebirth(float[] values, bool rebirthing)
    {
        if (rebirthing)
        {

            //Debug.Log($"Strength being sent from GameManager values[0]: {values[0]}");
            playerObject.GetComponent<ActorDefinition>().Rebirth(values);
            _playerRebirths++;
            ResetKillCounters();
            ResetRanks();
        } else
        {
            rebirthValues = values;
        }
    }

    // Resets Current kill counters
    private static void ResetKillCounters()
    {
        _ratKills = 0;
        _wolfKills = 0;
        _zombieKills = 0;
        _ghoulKills = 0;
        _skeletonKills = 0;
        _bruteKills = 0;
        _currentMonsterCounter = 0;
    }

    private static void ResetRanks()
    {
        _mapCounter = 1f;
        UpdateDifficulty();
    }

    #endregion Rebirthing

    public static void CloseGame()
    {
        Application.Quit();
    }

    #region Speed Manipulation

    public static void SpeedUpGame()
    {
        if (IsNormalSpeed)
        {
            foreach (GameObject actor in GameObject.FindObjectOfType<MapSwitcher>().enemyObjects_Fire)
            {
                actor.GetComponent<ActorDefinition>().actor.SpeedUpActor();

            }
            foreach (GameObject actor in GameObject.FindObjectOfType<MapSwitcher>().enemyObjects_Earth)
            {
                actor.GetComponent<ActorDefinition>().actor.SpeedUpActor();

            }
            foreach (GameObject actor in GameObject.FindObjectOfType<MapSwitcher>().enemyObjects_Wind)
            {
                actor.GetComponent<ActorDefinition>().actor.SpeedUpActor();

            }
            foreach (GameObject actor in GameObject.FindObjectOfType<MapSwitcher>().enemyObjects_Water)
            {
                actor.GetComponent<ActorDefinition>().actor.SpeedUpActor();

            }
            foreach (GameObject actor in GameObject.FindObjectOfType<MapSwitcher>().enemyObjects_Fire_Advanced)
            {
                actor.GetComponent<ActorDefinition>().actor.SpeedUpActor();

            }
            foreach (GameObject actor in GameObject.FindObjectOfType<MapSwitcher>().enemyObjects_Earth_Advanced)
            {
                actor.GetComponent<ActorDefinition>().actor.SpeedUpActor();

            }
            foreach (GameObject actor in GameObject.FindObjectOfType<MapSwitcher>().enemyObjects_Wind_Advanced)
            {
                actor.GetComponent<ActorDefinition>().actor.SpeedUpActor();

            }
            foreach (GameObject actor in GameObject.FindObjectOfType<MapSwitcher>().enemyObjects_Water_Advanced)
            {
                actor.GetComponent<ActorDefinition>().actor.SpeedUpActor();

            }
            foreach (GameObject actor in GameObject.FindObjectOfType<MapSwitcher>().enemyObjects_Fire_Boss)
            {
                actor.GetComponent<ActorDefinition>().actor.SpeedUpActor();

            }
            foreach (GameObject actor in GameObject.FindObjectOfType<MapSwitcher>().enemyObjects_Earth_Boss)
            {
                actor.GetComponent<ActorDefinition>().actor.SpeedUpActor();

            }
            foreach (GameObject actor in GameObject.FindObjectOfType<MapSwitcher>().enemyObjects_Wind_Boss)
            {
                actor.GetComponent<ActorDefinition>().actor.SpeedUpActor();

            }
            foreach (GameObject actor in GameObject.FindObjectOfType<MapSwitcher>().enemyObjects_Water_Boss)
            {
                actor.GetComponent<ActorDefinition>().actor.SpeedUpActor();

            }

            playerObject.GetComponent<ActorDefinition>().actor.SpeedUpActor();

            _isNormalSpeed = false;
        }
    }

    public static void PauseGame()
    {
        _isPaused = true;
        playerObject.GetComponent<ActorDefinition>().PauseActor();
        if (enemyObject != null)
        {
            enemyObject.GetComponent<ActorDefinition>().PauseActor();
        }
    }

    public static void UnpauseGame()
    {
        _isPaused = false;
        playerObject.GetComponent<ActorDefinition>().UnpauseActor();
        if (enemyObject != null)
        {
            enemyObject.GetComponent<ActorDefinition>().UnpauseActor();
        }
    }

    public static void SlowDownGame()
    {
        if (!IsNormalSpeed)
        {
            foreach (GameObject actor in GameObject.FindObjectOfType<MapSwitcher>().enemyObjects_Fire)
            {
                actor.GetComponent<ActorDefinition>().actor.SlowDownActor();

            }
            foreach (GameObject actor in GameObject.FindObjectOfType<MapSwitcher>().enemyObjects_Earth)
            {
                actor.GetComponent<ActorDefinition>().actor.SlowDownActor();

            }
            foreach (GameObject actor in GameObject.FindObjectOfType<MapSwitcher>().enemyObjects_Wind)
            {
                actor.GetComponent<ActorDefinition>().actor.SlowDownActor();

            }
            foreach (GameObject actor in GameObject.FindObjectOfType<MapSwitcher>().enemyObjects_Water)
            {
                actor.GetComponent<ActorDefinition>().actor.SlowDownActor();

            }
            foreach (GameObject actor in GameObject.FindObjectOfType<MapSwitcher>().enemyObjects_Fire_Advanced)
            {
                actor.GetComponent<ActorDefinition>().actor.SlowDownActor();

            }
            foreach (GameObject actor in GameObject.FindObjectOfType<MapSwitcher>().enemyObjects_Earth_Advanced)
            {
                actor.GetComponent<ActorDefinition>().actor.SlowDownActor();

            }
            foreach (GameObject actor in GameObject.FindObjectOfType<MapSwitcher>().enemyObjects_Wind_Advanced)
            {
                actor.GetComponent<ActorDefinition>().actor.SlowDownActor();

            }
            foreach (GameObject actor in GameObject.FindObjectOfType<MapSwitcher>().enemyObjects_Water_Advanced)
            {
                actor.GetComponent<ActorDefinition>().actor.SlowDownActor();

            }
            foreach (GameObject actor in GameObject.FindObjectOfType<MapSwitcher>().enemyObjects_Fire_Boss)
            {
                actor.GetComponent<ActorDefinition>().actor.SlowDownActor();

            }
            foreach (GameObject actor in GameObject.FindObjectOfType<MapSwitcher>().enemyObjects_Earth_Boss)
            {
                actor.GetComponent<ActorDefinition>().actor.SlowDownActor();

            }
            foreach (GameObject actor in GameObject.FindObjectOfType<MapSwitcher>().enemyObjects_Wind_Boss)
            {
                actor.GetComponent<ActorDefinition>().actor.SlowDownActor();

            }
            foreach (GameObject actor in GameObject.FindObjectOfType<MapSwitcher>().enemyObjects_Water_Boss)
            {
                actor.GetComponent<ActorDefinition>().actor.SlowDownActor();

            }

            playerObject.GetComponent<ActorDefinition>().actor.SlowDownActor();

            _isNormalSpeed = true;
        }
    }

    #endregion Speed Manipulation

    #region Game States

    public bool PlayerActive
    {
        get { return playerActive; }
    }

    public bool GameOver
    {
        get { return gameOver; }
    }

    public bool GameStarted
    {
        get { return gameStarted; }
    }

    #endregion Game States
}
