using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IdleGame
{

    public class Spawner : MonoBehaviour
    {
        [SerializeField]
        public List<GameObject> gameObjects;
        private new GameObject gameObject;
        [SerializeField]
        public List<GameObject> gameObjects_Advanced;
        //private new GameObject gameObject_Advanced;
        [SerializeField]
        public List<GameObject> gameObjects_Boss;
        //private new GameObject gameObject_Boss;
        const int minRandomValue = 0;
        private int maxRandomValue;
        [SerializeField]
        private Vector2 spawnerPos = new Vector2(0, 0);

        // Awake is called before Start()
        private void Awake()
        {
            maxRandomValue = gameObjects.Count;
            gameObject = Instantiate(gameObjects[Random.Range(minRandomValue, maxRandomValue)], transform.position, transform.rotation);
            gameObject.transform.SetParent(this.transform, true);
        }

        // Update is called once per frame
        void Update()
        {
            if (!GetComponentInChildren<ActorDefinition>())
            {
                if (!GameManager.IsPaused)
                {
                    if (IsDivisibleBy25())
                    {
                        maxRandomValue = gameObjects_Boss.Count;
                        SpawnNewBossGameObject();
                        
                    }
                    else if (IsDivisibleBy10())
                    {
                        maxRandomValue = gameObjects_Advanced.Count;
                        SpawnNewAdvancedGameObject();
                    }
                    else
                    {
                        maxRandomValue = gameObjects.Count;
                        SpawnNewGameObject();
                    }
                }
            }
        }

        private bool IsDivisibleBy25()
        {
            return GameManager.MapCounter % 25 == 0;
        }
        private bool IsDivisibleBy10()
        {
            return GameManager.MapCounter % 10 == 0;
        }

        public void SpawnNewGameObject()
        {
            gameObject = Instantiate(gameObjects[Random.Range(minRandomValue, maxRandomValue)], transform.position, transform.rotation);
            gameObject.transform.SetParent(this.transform, true);
        }
        public void SpawnNewAdvancedGameObject()
        {
            gameObject = Instantiate(gameObjects_Advanced[Random.Range(minRandomValue, maxRandomValue)], transform.position, transform.rotation);
            gameObject.transform.SetParent(this.transform, true);
        }
        public void SpawnNewBossGameObject()
        {
            gameObject = Instantiate(gameObjects_Boss[Random.Range(minRandomValue, maxRandomValue)], transform.position, transform.rotation);
            gameObject.transform.SetParent(this.transform, true);
        }

        public void SetSpawnerPos()
        {
            this.spawnerPos += new Vector2(3, 0);
        }
    }
}