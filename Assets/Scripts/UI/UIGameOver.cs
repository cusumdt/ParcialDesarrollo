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

    private int FinalScore;
    private int FinalLife;
    private GameManager GM;

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
        FinalLife = GM.GetLife();
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
