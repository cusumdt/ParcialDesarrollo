using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceExplosion : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabExplosion;
    [SerializeField]
    private float life;
    private GameObject explosion;
    Collider trigger;
    public bool onExplosion = false;
    
    void Awake()
    {   
        explosion = Instantiate(prefabExplosion, new Vector3(this.transform.position.x, 1f,this.transform.position.z) , Quaternion.identity);
        explosion.SetActive(false);
    }
    void Start()
    {
           trigger = GetComponent<Collider>();
    }

    void OnTriggerExit(Collider other)
    {
        trigger.isTrigger = false;
    }
    void Update()
    {
        StartCoroutine("TimeBomb");
        if(onExplosion)
        {
            
            explosion.SetActive(true);
            explosion.transform.position = new Vector3 (this.transform.position.x, 1f,this.transform.position.z);
            onExplosion=false;
            trigger.isTrigger = true;
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
        
        yield return new WaitForSeconds(life);
        onExplosion = true;

    }


}
