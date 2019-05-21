using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
     public static GameManager instance = null;
    [SerializeField]
     private int life;
     [SerializeField]
    private int score;

     void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(gameObject);    
            }
            DontDestroyOnLoad(gameObject);
        }
    public void SetLife( int cant )
    {
        life = cant;
    }
    public void SubtractLife( int cant )
    {
        life -= cant;
    }
    public int GetLife()
    {
        return life;
    }
    public void AddScore( int cant )
    {
        score += cant;
    }
    public int GetScore()
    {
        return score;
    }
    
    // Update is called once per frame
    void Update()
    {
        if(life <= 0)
        {
            SceneManager.LoadScene("PFinal");
            life = 2;
        }
    }
    public static GameManager Instance
    {
        get { return instance; }
    }

}
