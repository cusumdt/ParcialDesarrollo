using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceExplosion : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabExplosion;
    private GameObject explosion;

    public bool onExplosion = false;
    void Awake()
    {   
        explosion = Instantiate(prefabExplosion, new Vector3(this.transform.position.x, 1f,this.transform.position.z) , Quaternion.identity);
        explosion.SetActive(false);
    }
    void Start()
    {
        
    }
    void Update()
    {
        StartCoroutine("TimeBomb");
        if(onExplosion)
        {
            
            explosion.SetActive(true);
            onExplosion=false;
            Debug.Log("Explote");
            this.gameObject.SetActive(false);
        }
       
    }
    public void SetExplosion()
    {
        onExplosion = true;
    }
    
    IEnumerator TimeBomb()
    {
        
        yield return new WaitForSeconds(3f);
        onExplosion = true;

    }


}
