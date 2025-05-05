using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public Image[] stars;
    public Image[] endStars;
    public Sprite starOn;
    public GameObject endLevelScreen;
    
    private int index = 0;

    private void Awake()
    {
        if(instance == null) instance = this;
        else gameObject.SetActive(false);
        
        endLevelScreen.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void AddStar()
    {
        stars[index++].sprite = starOn;
        endStars[index].sprite = starOn;
    }

    public void OpenNextLevelScreen()
    {
        endLevelScreen.SetActive(true);
    }

    public void OpenNextLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
}