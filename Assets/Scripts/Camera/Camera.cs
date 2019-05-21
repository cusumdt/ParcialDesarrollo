using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    // Start is called before the first frame update
    public float distanceX;
    public float distanceZ;
    public float distanceY;
    public float rotationX;

    void Awake()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3 (player.transform.position.x /distanceX,distanceY,player.transform.position.z /distanceX);
        this.transform.rotation = new Quaternion (rotationX,0,0,1);
    }
}
