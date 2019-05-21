using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceBomb : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabBomb;
    public GameObject bomb;
    [SerializeField]

    void Awake()
    {
        bomb =  Instantiate(prefabBomb, new Vector3(GetComponent<PlayerMovement>().relativeX+0.5f, 1f, GetComponent<PlayerMovement>().relativeZ+0.5f), Quaternion.identity);
    }

    void Start()
    {
        bomb.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            if(!bomb.activeSelf)
            {
                bomb.SetActive(true);
                bomb.transform.position = new Vector3(GetComponent<PlayerMovement>().relativeX+0.5f, 1f, GetComponent<PlayerMovement>().relativeZ+0.5f);
                
            }
  
        }
    }
}
