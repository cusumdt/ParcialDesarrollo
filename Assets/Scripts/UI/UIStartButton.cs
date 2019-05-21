using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIStartButton : MonoBehaviour
{
    [SerializeField]
    private Button Button;

    void Awake()
    {
        if (Button == null)
        { 
            Button = GetComponent<Button>();
        }
        Button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        if(GameManager.Instance)
        {
            GameManager.Instance.SetLife(2);
        }
        SceneManager.LoadScene("PJuego");
    }
}
