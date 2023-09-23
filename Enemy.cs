using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IdleGame.Combat;
public class Enemy : MonoBehaviour
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

    [SerializeField]
    private float moveSpeed = 1f;

    private int currentFrame = 0;
    private int currentFrameCount = 0;
    public STATE state;
    public enum STATE { WALK, ATTACK, DAMAGED };

    // Start is called before the first frame update
    void Awake()
    {
        GetComponentInChildren<SpriteRenderer>().sprite = walkSprites[currentFrame];
        state = STATE.WALK;
    }

    // Update is called once per frame
    void Update()
    {
        CheckState();
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

        transform.Translate(Vector2.left * (moveSpeed * Time.deltaTime), Space.World);
    }

    private void Attack()
    {

    }

    private void Damaged()
    {

    }

    private void CheckState()
    {
        //Enemy.STATE playerState = (Enemy.STATE)PlayerStateMachineCheck.player.state;
        //state = playerState;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
            this.state = STATE.ATTACK;

        Debug.Log("Entered " + other.name);
    }
}
