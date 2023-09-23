using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IdleGame.Combat;


public class BackgroundController : MonoBehaviour
{
    private void Awake()
    {
        PlayerStateMachineCheck.BackgroundProgression(this.gameObject);
    }

    void Update()
    {
        PlayerStateMachineCheck.BackgroundProgression(this.gameObject);
        if (this.transform.position.x <= -5.8)
        {
            //Transform transform = GetComponent<Transform>();
            transform.position = new Vector2(11.6f, 3);
        }
    }

}

