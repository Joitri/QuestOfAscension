using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IdleGame
{
    [System.Serializable()]
    public class SaveGameData
    {
        #region Player

        public System.DateTime lastSave;
        public float experiencePerHour;
        // Player Data
        //Actor player;
        //EquipmentPanel equipmentPanel;
        //EquipmentSlot[] equipmentSlots;
        //Item[] items;
        //Item[] equippedItems;
        //// Stored values passed from the Actor to be loaded on load
        public float level;
        public float health;
        public float mana;
        public float healthRegen;
        public float manaRegen;
        public float str;
        public float intell;
        public float con;
        public float dex;
        public float agi;
        public float wis;
        public float cha;
        public float luk;
        public float curExp;
        public float reqExp;
        public float gold;

        public float bonusStr;
        public float bonusInt;
        public float bonusWis;
        public float bonusCon;
        public float bonusAgi;
        public float bonusDex;
        public float bonusCha;
        public float bonusLuk;

        // Do we need the frames? or can we do just the scriptable object of actor which contains the frames....?
        //public List<Sprite> walkSprites;
        //public List<Sprite> onehandAtkSprites;
        //public List<Sprite> twohandAtkSprites;
        //public List<Sprite> deathSprites;

        #endregion Player

        #region Rank

        /*
         * KEY : c = current, t = total, h = highest
         *       p = player, m = map, w = world
         */

        // Ranking Data
        public float wRank;
        public float mRank;
        public float hWorldRank;
        public float hMonsterRank;
        public float hFireRank;
        public float hEarthRank;
        public float hWindRank;
        public float hWaterRank;

        #endregion Rank

        #region Counters

        /*
         * KEY : c = current, t = total, h = highest
         *       p = player, m = map, w = world
         */

        // Kill Counters
        public float pDeaths;
        public float pLowRebirths;
        public float pRebirths;

        public float cMonsterCounter;
        public float tMonsterCounter;

        public float cRat;
        public float tRat;

        public float cWolf;
        public float tWolf;

        public float cZombie;
        public float tZombie;

        public float cGhoul;
        public float tGhoul;

        public float cSkeleton;
        public float tSkeleton;

        public float tBrute;
        public float cBrute;

        #endregion Counters


        public SaveGameData(GameObject gameObject)
        {
            #region Player Data

            // DateTime
            lastSave = GameManager.lastSaveTime;
            experiencePerHour = GameManager.experiencePerHour;

            // Save dummy variables for load
            level = GameManager.playerObject.GetComponent<ActorDefinition>().actor.Level;
            health = GameManager.playerObject.GetComponent<ActorDefinition>().actor.MaxHealth;
            mana = GameManager.playerObject.GetComponent<ActorDefinition>().actor.MaxMana;
            healthRegen = GameManager.playerObject.GetComponent<ActorDefinition>().actor.RegenHealth;
            manaRegen = GameManager.playerObject.GetComponent<ActorDefinition>().actor.RegenMana;
            str = GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseStrength;
            intell = GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseIntelligence;
            con = GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseConstitution;
            dex = GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseDexterity;
            agi = GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseAgility;
            wis = GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseWisdom;
            cha = GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseCharisma;
            luk = GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseLuck;
            curExp = GameManager.playerObject.GetComponent<ActorDefinition>().actor.CurrentExperience;
            reqExp = GameManager.playerObject.GetComponent<ActorDefinition>().actor.RequiredExperience;
            gold = GameManager.playerObject.GetComponent<ActorDefinition>().actor.Gold;


            // Values for rewarding stats once returned
            bonusStr = GameManager.playerObject.GetComponent<ActorDefinition>().actor.BonusStrength;
            bonusInt = GameManager.playerObject.GetComponent<ActorDefinition>().actor.BonusIntelligence;
            bonusWis = GameManager.playerObject.GetComponent<ActorDefinition>().actor.BonusWisdom;
            bonusCon = GameManager.playerObject.GetComponent<ActorDefinition>().actor.BonusConstitution;
            bonusAgi = GameManager.playerObject.GetComponent<ActorDefinition>().actor.BonusAgility;
            bonusDex = GameManager.playerObject.GetComponent<ActorDefinition>().actor.BonusDexterity;
            bonusCha = GameManager.playerObject.GetComponent<ActorDefinition>().actor.BonusCharisma;
            bonusLuk = GameManager.playerObject.GetComponent<ActorDefinition>().actor.BonusLuck;

            //int i = 0;
            //items = new Item[GameManager.inventory.GetComponentsInChildren<ItemSlot>().Length];
            //foreach (ItemSlot itemSlot in GameManager.inventory.GetComponents<ItemSlot>())
            //{
            //    if (itemSlot.Item == null)
            //    {
            //        items[i] = null;
            //    }
            //    else
            //    {
            //        //items[i] = itemSlot.Item;
            //        Debug.Log($"Item Slot: {itemSlot} Item : {itemSlot.Item}");
            //    }
            //    i++;
            //}

            //i = 0;
            //equippedItems = new Item[GameManager.equipPanel.GetComponentsInChildren<ItemSlot>().Length];
            //foreach (EquipmentSlot itemSlot in GameManager.equipPanel.GetComponentsInChildren<EquipmentSlot>())
            //{
            //    if (itemSlot.Item == null)
            //    {
            //        equippedItems[i] = null;
            //    }
            //    else
            //    {
            //        //equippedItems[i] = itemSlot.Item;
            //        Debug.Log($"Item Slot: {itemSlot} Item : {itemSlot.Item}");
            //    }
            //    i++;
            //}

            // Inventory
            // Store sprites 
            //foreach (Sprite v in gameObject.GetComponent<ActorDefinition>().actor.WalkSprites)
            //{
            //    walkSprites.Add(v);
            //}
            //foreach (Sprite v in gameObject.GetComponent<ActorDefinition>().actor.OneHandSprites)
            //{
            //    onehandAtkSprites.Add(v);
            //}
            //foreach (Sprite v in gameObject.GetComponent<ActorDefinition>().actor.TwoHandSprites)
            //{
            //    twohandAtkSprites.Add(v);
            //}
            //foreach (Sprite v in gameObject.GetComponent<ActorDefinition>().actor.DeathSprites)
            //{
            //    deathSprites.Add(v);
            //}

            #endregion Player Data

            #region Global Data

            #region Ranks

            wRank = GameManager.WorldRank;
            mRank = GameManager.MonsterRank;
            hWorldRank = GameManager.HighestWorldRank;
            hMonsterRank = GameManager.HighestMonsterRank;
            hFireRank = GameManager.HighestFireMapRank;
            hEarthRank = GameManager.HighestEarthMapRank;
            hWindRank = GameManager.HighestWindMapRank;
            hWaterRank = GameManager.HighestWaterMapRank;

            #endregion Ranks

            #region Counters

            pDeaths = GameManager.PlayerDeaths;
            pLowRebirths = GameManager.PlayerLowRebirths;
            pRebirths = GameManager.PlayerRebirths;

            cMonsterCounter = GameManager.CurrentMonsterCounter;
            tMonsterCounter = GameManager.HighestTotalMonsterCount;

            cRat = GameManager.RatKills;
            tRat = GameManager.TotalRatKills;

            cWolf = GameManager.WolfKills;
            tWolf = GameManager.TotalWolfKills;

            cZombie = GameManager.ZombieKills;
            tZombie = GameManager.TotalZombieKills;

            cGhoul = GameManager.GhoulKills;
            tGhoul = GameManager.TotalGhoulKills;

            cSkeleton = GameManager.SkeletonKills;
            tSkeleton = GameManager.TotalSkeletonKills;

            cBrute = GameManager.BruteKills;
            tBrute = GameManager.TotalBruteKills;

            #endregion Counters

            #endregion Global Data
        }
    }
}