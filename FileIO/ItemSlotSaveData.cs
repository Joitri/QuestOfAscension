using System;

namespace IdleGame
{
    [Serializable]
    public class ItemSlotSaveData
    {
        public string ItemID;
        public int Amount;

        public ItemSlotSaveData(string id, int amount)
        {
            ItemID = id;
            Amount = amount;
        }
    }

    [Serializable]
    public class ItemContainerSaveData
    {
        public ItemSlotSaveData[] SaveSlots;

        public ItemContainerSaveData(int numItems)
        {
            SaveSlots = new ItemSlotSaveData[numItems];
        }
    }
}