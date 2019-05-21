using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerExplosion : MonoBehaviour
{
    private GameObject stats;
    void Awake()
    {
        stats = GameObject.Find("GameManager");
    }
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("DestructibleWall"))
        {
            stats.GetComponent<GameManager>().AddScore(100);
            other.gameObject.SetActive(false);
             Debug.Log("HOLA"+ other.gameObject.name);
        }
        if(other.gameObject.CompareTag("Player"))
        {
            stats.GetComponent<GameManager>().SubtractLife(1);
        }
        if(other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            stats.GetComponent<GameManager>().AddScore(200);
        }
    }
}
