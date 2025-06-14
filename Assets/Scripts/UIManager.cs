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
    
    AudioSource endScreenSfx;
    private int index = 0;

    private void Start()
    {
        endScreenSfx = GetComponent<AudioSource>();
    }

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
        endStars[index].sprite = starOn;
        stars[index++].sprite = starOn;
    }

    public void OpenNextLevelScreen()
    {
        endScreenSfx.Play();
        endLevelScreen.SetActive(true);
    }

    public void OpenNextLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
}