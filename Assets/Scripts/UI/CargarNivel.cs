using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CargarNivel : MonoBehaviour
 {
   
    public int NumeroNivel;
    public Text textoNivel = null;
    public Text textoPorcentaje= null;
    public static CargarNivel instance;
    public Scrollbar BarraDeCarga;
    [HideInInspector]
    public float carga;
    [SerializeField]
    private float velCarga;

  
       private void Awake()
    {
        instance = this;
    }

 
    public static CargarNivel Instance
    {
        get { return instance; }
    }
    public void SetNivel(int _nivel)
    {
        NumeroNivel = _nivel;
    }
    void Update () 
    {
        
        if( SceneManager.GetActiveScene().name == "PCarga")
        {
            carga = carga + (Time.deltaTime* velCarga);
            BarraDeCarga.size = carga / 100;
            textoNivel.text = "Level " + NumeroNivel;
            textoPorcentaje.text = "" + (int)carga + "%";
            if (carga >= 100)
            {   
                carga = 0;
                SceneManager.LoadScene("PJuego");
            }
        }
	}
}
