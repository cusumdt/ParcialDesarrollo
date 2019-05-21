using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Platform : MonoBehaviour
{
    public bool active = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
      if(active)
      {
        if(other.gameObject.CompareTag("Player"))
        {
             SceneManager.LoadScene("PFinal");
        }
      }
    }
}
