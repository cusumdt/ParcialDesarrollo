using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateWall : MonoBehaviour
{
    [SerializeField]
    private GameObject destructibleWall;
    [SerializeField]
    private int cantWall;
    [SerializeField]
    private GameObject[] Walls;
    [SerializeField]
    private GameObject platform;
    private GameObject instancePlatform;
    private float randomX;
    private float randomZ;
    private bool generateWall=true;
    [SerializeField]
    private int cantWallDefeat = 0;
    void Awake()
    {

        Walls = new GameObject[cantWall];
        for(int i = 0; i< cantWall;i++)
        {
            randomX = Random.Range(0,9)+0.5f;
            randomZ = Random.Range(0,9)+0.5f;
            for(int j = 0; j<i; j++)
            {
                if(Walls[j]!= null)
                {
                    bool blockPosition = 
                    (
                        randomX == Walls[j].transform.position.x && randomZ == Walls[j].transform.position.z 
                        || randomX == 1.5f && randomZ == 1.5f 
                        || randomX == 0.5f && randomZ == 2.5f
                        || randomX == 0.5f && randomZ == 1.5f 
                        || randomX == 0.5f && randomZ == 0.5f
                        || randomX == 0.5f && randomZ == 3.5f
                    );
                    if(blockPosition)
                    {
                        j=cantWall+1;
                        i--;
                        generateWall = false;
                    }
                    else
                    {
                        generateWall = true;
                    }
                }
            }
            if(generateWall)
            {
                if((int)randomZ % 2 != 0)
                {
                    if(randomX != 1.5f && randomZ != 1.5f 
                    || randomX != 0.5f && randomZ != 2.5f
                    || randomX != 0.5f && randomZ != 1.5f 
                    || randomX != 0.5f && randomZ != 0.5f)
                    {
                        Walls[i] = Instantiate(destructibleWall, new Vector3(randomX, 1f, randomZ), Quaternion.identity);
                    }
                }
                else
                {
                    i--;
                }
            }
        
        }
        randomX = Random.Range(0,cantWall);
        instancePlatform=Instantiate(platform, new Vector3 (Walls[(int)randomX].transform.position.x,0.5f,Walls[(int)randomX].transform.position.z),Quaternion.identity);

    }
    void Update()
    {
       cantWallDefeat = 0;
        for(int i = 0 ; i <cantWall; i++)
        {
            if(!Walls[i].gameObject.activeSelf)
            {
                cantWallDefeat++;
            }
        }
        if(cantWallDefeat == cantWall)
        {
            instancePlatform.GetComponent<Platform>().active=true;
        }
    }
}
