using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IdleGame { 
    public class MapSpawner : MonoBehaviour
    {
        [SerializeField]
        private List<GameObject> gameObjects;
        private new GameObject gameObject;
        const int minRandomValue = 0;
        private int maxRandomValue;
        [SerializeField]
        private Vector2 spawnerPos = new Vector2(0, 0);

        private const int MAXMAPSTOSPAWN = 3;
        private const int FIXEDTIME = 10; 

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
            if (GameObject.FindWithTag("Player").GetComponent<ActorDefinition>().state == ActorDefinition.STATE.WALK)
            {

            }
            //if (!GetComponentInChildren<BackgroundController>())
            //{
            //    SpawnNewGameObject();
            //}
        }

        public void SpawnNewGameObject()
        {
            gameObject = Instantiate(gameObjects[Random.Range(minRandomValue, maxRandomValue)], transform.position, transform.rotation);
            gameObject.transform.SetParent(this.transform, true);
        }

        public void SetSpawnerPos()
        {
            this.spawnerPos += new Vector2(3, 0);
        }
    }
}
