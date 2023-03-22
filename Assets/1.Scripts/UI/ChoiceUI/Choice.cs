using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Choice : MonoBehaviour
{
    
    [SerializeField] GameManager gm;
    [SerializeField] private Transform bulletParent;
    [SerializeField] private Transform playerSpawnPont;
    public void OnChoiceCharacter(Player player)
    {
        GameManager gmr = Instantiate(gm);
        gmr.player = player;
        gmr.bulletParent = this.bulletParent;
        gmr.playerSpawnPoint = this.playerSpawnPont;

        SceneManager.LoadScene("Game");
        DontDestroyOnLoad(gmr);
    }
}
