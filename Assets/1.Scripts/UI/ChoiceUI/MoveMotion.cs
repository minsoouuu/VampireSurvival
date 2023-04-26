using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoveMotion : MonoBehaviour
{
    [SerializeField] private List<Sprite> sprites;
    [SerializeField] Player player;
    [SerializeField] TMP_Text text;
    private void Start()
    {
        StartCoroutine(PlayerMotion());
    }
    IEnumerator PlayerMotion()
    {
        int spriteIndex = 0;
        while (true)
        {
            GetComponent<Image>().sprite = sprites[spriteIndex];
            spriteIndex++;
            if (spriteIndex >= sprites.Count -1)
            {
                spriteIndex = 0;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}
