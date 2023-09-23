using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace IdleGame.Combat
{
    public abstract class Statistics : Actor
    {
        // Pool stats
        [SerializeField]
        private float maxHealth = 100;
        private float currentHealth;

        [SerializeField]
        private float maxMana = 100;
        private float currentMana;

        // Defense stats
        [SerializeField]
        private float physicalDefense = 10;
        [SerializeField]
        private float magicDefense = 10;

        // Base stats
        [SerializeField]
        private float strength = 1;
        [SerializeField]
        private float intelligence = 1;
        [SerializeField]
        private float wisdom = 1;
        [SerializeField]
        private float constitution = 1;
        [SerializeField]
        private float dexterity = 1;
        [SerializeField]
        private float agility = 1;
        [SerializeField]
        private float charisma = 1;
        [SerializeField]
        private float luck = 1;


        // Secondary stats
        private float attackSpeed;
        private float castSpeed;

        private float criticalRate;
        private float criticalDefense;
        private float criticalResist;

        void Start()
        {
            UpdateSecondaryStats();
        }

        private void UpdateSecondaryStats()
        {
            this.attackSpeed = (agility / (strength + constitution));
            this.castSpeed = (dexterity / (intelligence + wisdom));

            this.criticalRate = (luck / 100);
            this.criticalDefense = ((luck + constitution) / 1000);
            this.criticalResist = ((luck + wisdom) / 1000);
        }

        public float GetMaxHealth()
        {
            return maxHealth;
        }

        public void SetMaxHealth(float value)
        {
            this.maxHealth = value;
        }
        public float GetCurrentHealth()
        {
            return currentHealth;
        }

        public void SetCurrentHealth(float value)
        {
            this.currentHealth = value;
        }
        public float GetMaxMana()
        {
            return maxMana;
        }

        public void SetMaxMana(float value)
        {
            this.maxMana = value;
        }
        public float GetCurrentMana()
        {
            return currentMana;
        }

        public void SetCurrentMana(float value)
        {
            this.currentMana = value;
        }
        public float GetPhysicalDefense()
        {
            return physicalDefense;
        }

        public void SetPhysicalDefense(float value)
        {
            this.physicalDefense = value;
        }
        public float GetMagicDefense()
        {
            return magicDefense;
        }

        public void SetMagicDefense(float value)
        {
            this.magicDefense = value;
        }
        public float GetStrength()
        {
            return strength;
        }

        public void SetStrength(float value)
        {
            this.strength = value;
        }
        public float GetIntelligence()
        {
            return intelligence;
        }

        public void SetIntelligence(float value)
        {
            this.intelligence = value;
        }
        public float GetWisdom()
        {
            return wisdom;
        }

        public void SetWisdom(float value)
        {
            this.wisdom = value;
        }
        public float GetConstitution()
        {
            return constitution;
        }

        public void SetConstitution(float value)
        {
            this.constitution = value;
        }
        public float GetDexterity()
        {
            return dexterity;
        }

        public void SetDexterity(float value)
        {
            this.dexterity = value;
        }
        public float GetAgility()
        {
            return agility;
        }

        public void SetAgility(float value)
        {
            this.agility = value;
        }
        public float GetCharisma()
        {
            return charisma;
        }

        public void SetCharisma(float value)
        {
            this.charisma = value;
        }
        public float GetLuck()
        {
            return luck;
        }

        public void SetLuck(float value)
        {
            this.luck = value;
        }
    }
}