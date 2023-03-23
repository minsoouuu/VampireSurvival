using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Select : MonoBehaviour
{
    [SerializeField] SelectData sd;
    public void OnChoiceCharacter(Player player)
    {
        sd.gm.player = player;
        SceneManager.LoadScene("Game");
        DontDestroyOnLoad(sd);
    }
}
