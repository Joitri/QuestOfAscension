using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IdleGame;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] GameObject itemMover;
    Item item;
    Item[] itemDatabase;
    ActorDefinition monster;
    [SerializeField] private Character character;

    int minValue = 0;
    int maxValue;

    private void Awake()
    {
        itemDatabase = FindObjectOfType<ItemSaveManager>().itemDatabase.items;
        maxValue = itemDatabase.Length;
        item = itemDatabase[Random.Range(minValue, maxValue)];
    }

    // Update is called once per frame
    void Update()
    {
        if (monster != null)
        {
            if (monster.actor.CurrentHealth <= 0)
            {
                int number = Random.Range(minValue, maxValue);
                character.Inventory.AddItem(itemDatabase[number].GetCopy());
                GameObject gameObject = itemMover;
                gameObject.GetComponent<ItemMove>().SetItem(itemDatabase[number]);
                gameObject = Instantiate(itemMover, transform.position, transform.rotation);
                monster = null;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            monster = collision.GetComponent<ActorDefinition>();
        }
    }
}
