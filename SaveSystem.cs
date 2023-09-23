using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace IdleGame {
    public static class SaveSystem
    {
        private static bool isNewGame => IsNewGame();
        private static string path = GetPath();

        public static void WriteToBinaryFile<T>(string filePath, T gameObject)
        {
            //filePath = Application.persistentDataPath + "/QoA.Inventory";
            using (Stream stream = File.Open(filePath, FileMode.Create))
            {
                var binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(stream, gameObject);
            }
        }

        public static T ReadFromBinaryFile<T>(string filePath)
        {
            //filePath = Application.persistentDataPath + "/QoA.Inventory";
            using (Stream stream = File.Open(filePath, FileMode.Open))
            {
                var binaryFormatter = new BinaryFormatter();
                return (T)binaryFormatter.Deserialize(stream);
            }
        }

        public static void SaveGameData(GameObject gameObject)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Create);

            SaveGameData gameData = new SaveGameData(gameObject);

            formatter.Serialize(stream, gameData);
            stream.Close();
        }

        public static SaveGameData LoadGameData()
        {
            if (!isNewGame)
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);

                if (stream != null)
                {
                    SaveGameData data = formatter.Deserialize(stream) as SaveGameData;
                    stream.Close();
                    return data;
                }
            }
            //Debug.Log($"File not found : !!!! {path}");
            return null;
        }

        private static bool IsNewGame()
        {
            SetPath();
            if (File.Exists(path))
            {
                return false;
                //Debug.Log($"NEW GAME!!!!!!{path}");
            }
            Debug.Log($"{path}");
            return true;
        }

        public static void SetPath()
        {
            path = $"{Application.persistentDataPath}/QoA.ElifEvas4";
        }
        public static string GetPath()
        {
            return $"{Application.persistentDataPath}/QoA.ElifEvas4";
        }
    }
}