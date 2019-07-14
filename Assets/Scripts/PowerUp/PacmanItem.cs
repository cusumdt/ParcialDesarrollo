using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanItem : MonoBehaviour
{
    private GameObject pacman;
    void Awake()
    {
        pacman = GameObject.Find("PacmanController");
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            pacman.GetComponent<Pacman>().SetPowerOn(true);
            this.gameObject.SetActive(false);
        }
    }
}
