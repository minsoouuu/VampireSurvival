using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class MapController : MonoBehaviour
{

    float playerXpos;
    float playerYpos;
    void Start()
    {

    }
    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Area"))
        {
            return;
        }
        Vector3 playerPos = GameManager.instance.player.transform.position;
        Vector3 myPos = transform.position;
        float diffX = Mathf.Abs(playerPos.x - myPos.x);
        float diffY = Mathf.Abs(playerPos.y - myPos.y);

        float dirX = GameManager.instance.player.x < 0 ? -1 : 1;
        float dirY = GameManager.instance.player.y < 0 ? -1 : 1;

        switch (transform.tag)
        {
            case "Ground":
                if (diffX > diffY)
                {
                    transform.Translate(Vector3.right * dirX * 40);
                }
                else if (diffX < diffY)
                {
                    transform.Translate(Vector3.up * dirY * 40);
                }
                    break;
        }

    }
}
