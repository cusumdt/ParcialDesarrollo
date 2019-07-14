using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIGameOver : MonoBehaviour
{
    [SerializeField]
    private Text ScoreText;
    [SerializeField]
    private Text LifeText;
    [SerializeField]
    private Text HighScore;

    private int FinalScore;
    private int FinalLife;
    private GameManager GM;
    private int FinalHighScore;

    // Start is called before the first frame update
    void Awake()
    {
          if (!GameManager.Instance)
        {
            GM = new GameManager();
        }
        else
        {
            GM = GameManager.Instance;
        }
        FinalScore = GM.GetScore();
        GM.SetScore(0);
        FinalLife = GM.GetLife();
        GM.SetLife(2);
        FinalHighScore = GM.GetHighScore();

    }

    // Update is called once per frame

    private void OnEnable()
    {
        if (ScoreText)
        { 
            ScoreText.text = "Score: " + FinalScore.ToString();
        }
        if (LifeText)
        { 
            LifeText.text = "Life: " + FinalLife;
        }
        if(HighScore)
        {
            HighScore.text = "HighScore: " + FinalHighScore.ToString();
        }
    }
    void Update()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("PMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
