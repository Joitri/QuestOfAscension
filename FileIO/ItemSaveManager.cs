using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace IdleGame {
    public class ItemSaveManager : MonoBehaviour
    {
        [SerializeField] public ItemDatabase itemDatabase;

        private const string InventoryFileName = "Inventory";
        private const string EquipmentFileName = "Equipment";

        private void Awake()
        {
            //Debug.Log($"ItemSaveManager Just Woke Up! {System.DateTime.Now.ToBinary()}");
        }

        public void LoadInventory(Character character)
        {
            ItemContainerSaveData savedSlots = ItemSaveIO.LoadItems(InventoryFileName);
            if (savedSlots == null) {
                //Debug.Log($"I Failed To Load Inventory {savedSlots}");
                return;
            }

            character.Inventory.Clear();
            //Debug.Log($"I Am Loading Inventory {savedSlots}");


            for (int i = 0; i < savedSlots.SaveSlots.Length; i++)
            {
                ItemSlot itemSlot = character.Inventory.ItemSlots[i];
                ItemSlotSaveData savedSlot = savedSlots.SaveSlots[i];

                if (savedSlot == null)
                {
                    itemSlot.Item = null;
                    itemSlot.Amount = 0;
                } 
                else
                {
                    itemSlot.Item = itemDatabase.GetItemCopy(savedSlot.ItemID);
                    itemSlot.Amount = savedSlot.Amount;
                }
            }
        }

        public void LoadEquipment(Character character)
        {
            ItemContainerSaveData savedSlots = ItemSaveIO.LoadItems(EquipmentFileName);
            if (savedSlots == null)
            {
                //Debug.Log($"I Failed To Load Equipment {savedSlots}");
                return;
            }
            character.EquipmentPanel.Clear();
            foreach (ItemSlotSaveData savedSlot in savedSlots.SaveSlots)
            {
                if (savedSlot == null)
                {
                //Debug.Log($"I Am Loading Equipment {savedSlots}");
                    continue;
                }
                Item item = itemDatabase.GetItemCopy(savedSlot.ItemID);
                character.Inventory.AddItem(item);
                character.Equip((EquippableItem)item);
            }

            for (int i = 0; i < savedSlots.SaveSlots.Length; i++)
            {
                ItemSlot itemSlot = character.Inventory.ItemSlots[i];
                ItemSlotSaveData savedSlot = savedSlots.SaveSlots[i];

                if (savedSlot == null)
                {
                    itemSlot.Item = null;
                    itemSlot.Amount = 0;
                }
                else
                {
                    itemSlot.Item = itemDatabase.GetItemCopy(savedSlot.ItemID);
                    itemSlot.Amount = savedSlot.Amount;
                }
            }
        }
        public void SaveInventory(Character character)
        {
            SaveItems(character.Inventory.ItemSlots, InventoryFileName);
        }
        public void SaveEquipment(Character character)
        {
            SaveItems(character.EquipmentPanel.EquipmentSlots, EquipmentFileName);
        }

        private void SaveItems(IList<ItemSlot> itemSlots, string fileName)
        {
            var saveData = new ItemContainerSaveData(itemSlots.Count);

            for (int i = 0; i < saveData.SaveSlots.Length; i++)
            {
                ItemSlot itemSlot = itemSlots[i];

                if (itemSlot.Item == null)
                {
                    saveData.SaveSlots[i] = null;
                }
                
                else
                {
                    saveData.SaveSlots[i] = new ItemSlotSaveData(itemSlot.Item.ID, itemSlot.Amount);
                }
            }

            ItemSaveIO.SaveItems(saveData, fileName);
        }
    }
}