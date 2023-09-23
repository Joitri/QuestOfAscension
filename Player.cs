using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private List<Sprite> walkSprites;
    private int currentWalkFrame;

    [SerializeField]
    private List<Sprite> attackSprites;
    private int currentAttackFrame;

    [SerializeField]
    private List<Sprite> damagedSprites;
    private int currentDamagedFrame;

    private int currentFrame = 0;
    private int currentFrameCount = 0;
    public STATE state = STATE.WALK;
    public enum STATE { WALK, ATTACK, DAMAGED };

    // Start is called before the first frame update
    void Awake()
    {
        //GetComponentInChildren<SpriteRenderer>().sprite = walkSprites[currentFrame];
        state = STATE.WALK;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case STATE.WALK:
                Walk();
                break;
            case STATE.ATTACK:
                Attack();
                break;
            case STATE.DAMAGED:
                Damaged();
                break;
            default:
                break;
        }
    }
    private void Walk()
    {
        currentFrameCount++;
        if (currentFrameCount >= 15)
        {
            if (currentWalkFrame < walkSprites.Count - 1)
            {
                currentWalkFrame++;
            }
            else
            {
                currentWalkFrame = 0;
            }

            //Debug.Log(currentWalkFrame.ToString());
            GetComponentInChildren<SpriteRenderer>().sprite = walkSprites[currentWalkFrame];
            currentFrameCount = 0;
        }
    }

    private void Attack()
    {

    }

    private void Damaged()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
            this.state = STATE.ATTACK;

        Debug.Log("Entered " + other.name);
    }
}
