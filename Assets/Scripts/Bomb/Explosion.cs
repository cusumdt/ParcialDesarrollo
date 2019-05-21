using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    void Update()
    {
        StartCoroutine("TimeExplosion");   
    }
    IEnumerator TimeExplosion()
    {
        yield return new WaitForSeconds(0.2f);
        Debug.Log("Se apago el fuego");
        this.gameObject.SetActive(false);
    }
}
