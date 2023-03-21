using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamereMove : MonoBehaviour
{
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isLive == false)
        {
            return;
        }
        transform.Translate(Vector3.MoveTowards(transform.position,GameManager.instance.player.transform.position, Time.deltaTime * 3f));
    }
}
