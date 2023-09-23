using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IdleGame;
using IdleGame.Combat;
public class ItemMove : MonoBehaviour
{
    Item item;
    SpriteRenderer spriteRenderer;

    // Update is called once per frame
    void Update()
    {
        PlayerStateMachineCheck.BackgroundProgression(this.gameObject);
        if (this.transform.position.x <= -5.8)
        {
            //Transform transform = GetComponent<Transform>();
            transform.position = new Vector2(11.6f, 3);
        }
    }
    public Item GetItem()
    {
        return item;
    }
    public void SetItem(Item newItem)
    {
        item = newItem;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = item.Icon;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<ItemGrabber>())
        {
            StartCoroutine(DestroySelf());
        }
    }

    private IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(.2f);
        this.item = null;
        Destroy(this.gameObject);
    }
}
