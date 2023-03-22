using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamereMove : MonoBehaviour
{

    void Update()
    {
        if (GameManager.instance.isLive == false)
        {
            return;
        }

        Vector3 dir = Vector3.Normalize(GameManager.instance.player.transform.position - transform.position);

        transform.Translate(Vector3.MoveTowards(new Vector3( dir.x, dir.y), GameManager.instance.player.transform.position,Time.deltaTime));
    }
}
