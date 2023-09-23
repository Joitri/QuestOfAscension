using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace IdleGame {
    public class Rebirth : MonoBehaviour
    {
        public float[] numbers;

        private void Awake()
        {
            numbers = new float[8];
        }

        private void Update()
        {
            float[] values = new float[8];
            numbers = RebirthValues(values[0], values[1], values[2], values[3], values[4], values[5], values[6], values[7]);
        }
        public float[] RebirthValues()
        {
            float[] values = new float[8];
            values = RebirthValues(values[0], values[1], values[2], values[3], values[4], values[5], values[6], values[7]);
            return values;
        }

        public static void RebirthActor(bool rebirth)
        {
            float[] values = new float[8];
            values = RebirthValues(values[0], values[1], values[2], values[3], values[4], values[5], values[6], values[7]);

            Debug.Log($"Strength being sent from values[0]: {values[0]}");
            if (rebirth)
                GameManager.Rebirth(values, true);
            else
                GameManager.Rebirth(values, false);
        }

        private static float[] RebirthValues(float str, float intell, float con, float dex, float agi, float wis, float cha, float luk)
        {
            float[] values = new float[8];

            if (GameManager.playerObject.GetComponent<ActorDefinition>().actor.CurrentExperience > 100000f) // 100,000
            {
                str += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseStrength / 100000);
                intell += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseIntelligence / 100000);
                con += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseConstitution / 100000);
                dex += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseDexterity / 100000);
                agi += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseAgility / 100000);
                wis += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseWisdom / 100000);
                cha += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseCharisma / 100000);
                luk += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseLuck / 100000);
            }

            Debug.Log($"Strength being sent from rebirth First Check: {str}");

            if (GameManager.playerObject.GetComponent<ActorDefinition>().actor.CurrentExperience > 1000000f) // 1,000,000
            {
                str += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseStrength / 10000);
                intell += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseIntelligence / 10000);
                con += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseConstitution / 10000);
                dex += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseDexterity / 10000);
                agi += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseAgility / 10000);
                wis += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseWisdom / 10000);
                cha += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseCharisma / 10000);
                luk += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseLuck / 10000);
            }

            Debug.Log($"Strength being sent from rebirth Second Check: {str}");
            if (GameManager.playerObject.GetComponent<ActorDefinition>().actor.CurrentExperience > 1000000000f) // 1,000,000,000
            {
                str += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseStrength / 1000);
                intell += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseIntelligence / 1000);
                con += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseConstitution / 1000);
                dex += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseDexterity / 1000);
                agi += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseAgility / 1000);
                wis += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseWisdom / 1000);
                cha += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseCharisma / 1000);
                luk += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseLuck / 1000);
            }

            Debug.Log($"Strength being sent from rebirth Third Check: {str}");
            if (GameManager.playerObject.GetComponent<ActorDefinition>().actor.CurrentExperience > 1000000000000f) // 1,000,000,000,000
            {
                str += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseStrength / 100);
                intell += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseIntelligence / 100);
                con += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseConstitution / 100);
                dex += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseDexterity / 100);
                agi += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseAgility / 100);
                wis += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseWisdom / 100);
                cha += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseCharisma / 100);
                luk += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseLuck / 100);
            }

            Debug.Log($"Strength being sent from rebirth Fourth Check: {str}");
            if (GameManager.playerObject.GetComponent<ActorDefinition>().actor.CurrentExperience > 1000000000000000f) // 1,000,000,000,000,000
            {
                str += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseStrength / 10);
                intell += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseIntelligence / 10);
                con += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseConstitution / 10);
                dex += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseDexterity / 10);
                agi += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseAgility / 10);
                wis += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseWisdom / 10);
                cha += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseCharisma / 10);
                luk += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseLuck / 10);
            }

            Debug.Log($"Strength being sent from rebirth Fifth Check: {str}");
            if (GameManager.playerObject.GetComponent<ActorDefinition>().actor.CurrentExperience > 1000000000000000000f) // 1,000,000,000,000,000,000
            {
                str += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseStrength / 1);
                intell += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseIntelligence / 1);
                con += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseConstitution / 1);
                dex += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseDexterity / 1);
                agi += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseAgility / 1);
                wis += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseWisdom / 1);
                cha += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseCharisma / 1);
                luk += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseLuck / 1);
            }

            Debug.Log($"Strength being sent from rebirth Sixth Check: {str}");
            if (GameManager.playerObject.GetComponent<ActorDefinition>().actor.CurrentExperience > 1000000000000000000000f) // 1,000,000,000,000,000,000,000
            {
                str += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseStrength * 1.05f);
                intell += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseIntelligence * 1.05f);
                con += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseConstitution * 1.05f);
                dex += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseDexterity * 1.05f);
                agi += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseAgility * 1.05f);
                wis += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseWisdom * 1.05f);
                cha += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseCharisma * 1.05f);
                luk += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseLuck * 1.05f);
            }

            Debug.Log($"Strength being sent from rebirth Seventh Check: {str}");
            if (GameManager.playerObject.GetComponent<ActorDefinition>().actor.CurrentExperience > 1000000000000000000000000f) // 1,000,000,000,000,000,000,000,000
            {
                str += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseStrength * 1.1f);
                intell += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseIntelligence * 1.1f);
                con += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseConstitution * 1.1f);
                dex += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseDexterity * 1.1f);
                agi += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseAgility * 1.1f);
                wis += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseWisdom * 1.1f);
                cha += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseCharisma * 1.1f);
                luk += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseLuck * 1.1f);
            }

            Debug.Log($"Strength being sent from rebirth Eighth Check: {str}");
            if (GameManager.playerObject.GetComponent<ActorDefinition>().actor.CurrentExperience > 1000000000000000000000000000f) // 1,000,000,000,000,000,000,000,000,000
            {
                str += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseStrength * 1.15f);
                intell += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseIntelligence * 1.15f);
                con += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseConstitution * 1.15f);
                dex += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseDexterity * 1.15f);
                agi += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseAgility * 1.15f);
                wis += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseWisdom * 1.15f);
                cha += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseCharisma * 1.15f);
                luk += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseLuck * 1.15f);
            }

            Debug.Log($"Strength being sent from rebirth Ninth Check: {str}");
            if (GameManager.playerObject.GetComponent<ActorDefinition>().actor.CurrentExperience > 1000000000000000000000000000000f) // 1,000,000,000,000,000,000,000,000,000,000
            {
                str += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseStrength * 1.2f);
                intell += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseIntelligence * 1.2f);
                con += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseConstitution * 1.2f);
                dex += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseDexterity * 1.2f);
                agi += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseAgility * 1.2f);
                wis += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseWisdom * 1.2f);
                cha += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseCharisma * 1.2f);
                luk += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseLuck * 1.2f);
            }

            Debug.Log($"Strength being sent from rebirth Tenth Check: {str}");
            if (GameManager.playerObject.GetComponent<ActorDefinition>().actor.CurrentExperience > 1000000000000000000000000000000000f) // 1,000,000,000,000,000,000,000,000,000,000,000
            {
                str += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseStrength * 1.25f);
                intell += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseIntelligence * 1.25f);
                con += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseConstitution * 1.25f);
                dex += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseDexterity * 1.25f);
                agi += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseAgility * 1.25f);
                wis += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseWisdom * 1.25f);
                cha += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseCharisma * 1.25f);
                luk += (float)Mathf.Round(GameManager.playerObject.GetComponent<ActorDefinition>().actor.BaseLuck * 1.25f);
            }

            Debug.Log($"Strength being sent from rebirth Eleventh Check: {str}");

            values[0] = str;
            values[1] = intell;
            values[2] = wis;
            values[3] = con;
            values[4] = dex;
            values[5] = agi;
            values[6] = luk;
            values[7] = cha;

            return values;
        }
    }
}