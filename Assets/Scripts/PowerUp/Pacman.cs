using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pacman : MonoBehaviour
{
    public bool powerOn;

    public float duration;

    public float time;
    public GameObject[] enemy;
    public bool transformation;

    void Awake()
    {
        powerOn=false;
        transformation = true;    
    }

    // Update is called once per frame
    void Update()
    {
        if(powerOn)
        {
            if(transformation)
            {
                for (int i = 0; i < enemy.Length; i++)
                {
                    enemy[i].gameObject.tag = "EdibleEnemy";
                }
                transformation = false;
            }
            time += 1 * Time.deltaTime;
            if(time >= duration)
            {
                time = 0;
                powerOn = !powerOn;
                transformation = true;
                for (int i = 0; i < enemy.Length; i++)
                {
                    enemy[i].gameObject.tag = "Enemy";
                }
            }
        }
    }
    public void SetPowerOn(bool _powerOn)
    {
        powerOn = _powerOn;
    }
    public bool GetPowerOn()
    {
        return powerOn;
    }

}
