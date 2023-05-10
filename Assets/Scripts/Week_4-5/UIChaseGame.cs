using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIChaseGame : MonoBehaviour
{
    public static UIChaseGame Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;

    }

    [SerializeField] GameObject gameWonScreen;
    [SerializeField] GameObject gameLostScreen;


    public void GameWon()
    {

        gameWonScreen.SetActive(true);
    }


    public void GameLost()
    {
        gameLostScreen.SetActive(true);

    }


    public void Restart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
