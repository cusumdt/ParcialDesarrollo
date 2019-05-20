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
    private float randomX;
    private float randomZ;
    private bool generateWall=true;
    // Start is called before the first frame update
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
                    if(randomX == Walls[j].transform.position.x && randomZ == Walls[j].transform.position.z 
                    || randomX == 1.5f && randomZ == 1.5f 
                    || randomX == 1.5f && randomZ == 2.5f
                    || randomX == 0.5f && randomZ == 1.5f 
                    || randomX == 0.5f && randomZ == 0.5f  )
                    {
                        j=10;
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
                    || randomX != 1.5f && randomZ != 2.5f
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

    }
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
