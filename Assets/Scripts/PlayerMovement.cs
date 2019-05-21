using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   
    //Const private
    private const int module = 2;
    private const float addRelative= 0.5f;

    //SerializeField Private
    [SerializeField]
    private float speed;
    [SerializeField]
    private bool transformOn = false;
    [SerializeField]
    private bool transformOnVertical = false;
    [SerializeField]
    private bool activeX = false;
    [SerializeField]
    private bool activeZ = false;
    [SerializeField]
    private bool movementOn = true;
    //Public
    public int relativeX;
    public int relativeZ;
    //Normal private
    private Vector3 selectTransform;
    private Vector3 startPosition= new Vector3(0.5f,1f,0.5f);
    private float translationZ;
    private float translationX;
    private GameObject stats;
    private bool resetPosition=true;
    void Awake()
    {
        this.transform.position = startPosition;
        stats = GameObject.Find("GameManager");
    }

    void Update()
    {
        relativeZ=(int)this.transform.position.z;
        relativeX=(int)this.transform.position.x;
        MovementPlayer();
        lifeCase();
    }
   void lifeCase()
   {
       switch(stats.GetComponent<GameManager>().GetLife())
       {
           case 1:
           if(resetPosition)
           {
                this.transform.position = startPosition;
                resetPosition=false;
           }
            
           break;
           case 0:
          default:
                resetPosition = true;
            break;

       }
   }
    void MovementPlayer()
    {
        if(movementOn)
        {
            if(relativeZ % module !=0)
            {
                translationX = (Input.GetAxis("Horizontal")* speed) * Time.deltaTime;
                this.transform.position = new Vector3(
                                                        this.transform.position.x + translationX * Time.deltaTime,
                                                        this.transform.position.y,
                                                        this.transform.position.z
                                                     );
                if(this.transform.position.x >=relativeX + addRelative)
                    {
                        if(relativeX % module != 0)
                        {
                            if(Input.GetKeyDown("w") || Input.GetKeyDown("up") )
                            {
                                movementOn=false;
                                translationX = 0f;
                                translationZ = 0f;
                                transformOnVertical = true;
                                activeX=true;
                                selectTransform = new Vector3(relativeX + 1f + addRelative, this.transform.position.y,relativeZ + 1.5f);

                            }
                            if(Input.GetKeyDown("s") || Input.GetKeyDown("down") )
                            {
                                movementOn=false;
                                translationX = 0f;
                                translationZ = 0f;
                                transformOnVertical = true;
                                activeX=true;
                                selectTransform = new Vector3(relativeX + 1f + addRelative, this.transform.position.y,relativeZ - 0.5f);

                            }
                        }
                    }
                    if(this.transform.position.x < relativeX + 0.4f)
                    {
                         if(relativeX % module != 0)
                         {
                             if(Input.GetKeyDown("w") || Input.GetKeyDown("up") )
                             {
                                movementOn=false;
                                translationX = 0f;
                                translationZ = 0f;
                                transformOnVertical = true;
                                activeX=true;
                                selectTransform = new Vector3(relativeX - 0.5f, this.transform.position.y,relativeZ + 1.5f);

                            }
                             if(Input.GetKeyDown("s") || Input.GetKeyDown("down") )
                            {
                                movementOn=false;
                                translationX = 0f;
                                translationZ = 0f;
                                transformOnVertical = true;
                                activeX=true;
                                selectTransform = new Vector3(relativeX - 0.5f, this.transform.position.y,relativeZ - 0.5f);

                            }
                        }
                    }                                         
            }

            if(relativeX % module == 0)
            {
               
                translationZ = (Input.GetAxis("Vertical") * speed) * Time.deltaTime;
                this.transform.position = new Vector3(
                                                        this.transform.position.x,
                                                        this.transform.position.y,
                                                        this.transform.position.z + translationZ * Time.deltaTime
                                                     );
                if(relativeZ % module == 0)
                {
                    if(this.transform.position.z >=relativeZ + addRelative)
                    {
                        if(Input.GetKeyDown("d") || Input.GetKeyDown("right") && this.transform.position.x <9.5f)
                        {
                            movementOn=false;
                            translationX = 0f;
                            translationZ = 0f;
                            transformOn = true;
                            activeZ=true;
                            selectTransform = new Vector3(relativeX + 1f + addRelative, this.transform.position.y,relativeZ + 1.5f);
    
                        }
                        if(Input.GetKeyDown("a") || Input.GetKeyDown("left") && this.transform.position.x > 0.5f)
                        {
                            movementOn=false;
                            translationX = 0f;
                            translationZ = 0f;
                            transformOn = true;
                            activeZ=true;
                            selectTransform = new Vector3(relativeX - 1f + addRelative, this.transform.position.y,relativeZ + 1.5f);
    
                        }
                    }
                    if(this.transform.position.z < relativeZ + 0.4f)
                    {
                         if(Input.GetKeyDown("d") || Input.GetKeyDown("right")  && this.transform.position.x <9.5f)
                         {
                            movementOn=false;
                            translationX = 0f;
                            translationZ = 0f;
                            transformOn = true;
                            activeZ=true;
                            selectTransform = new Vector3(relativeX + 1f + addRelative, this.transform.position.y,relativeZ - 0.5f);
                            
                        }
                         if(Input.GetKeyDown("a") || Input.GetKeyDown("left") && this.transform.position.x > -0.5f )
                         {
                            movementOn=false;
                            translationX = 0f;
                            translationZ = 0f;
                            transformOn = true;
                            activeZ=true;
                            selectTransform = new Vector3(relativeX - 1f + addRelative, this.transform.position.y,relativeZ - 0.5f);
                            
                        }
                        
                    }
                }
                else
                {
                           if(Input.GetKeyDown("d") || Input.GetKeyDown("right")  && this.transform.position.x <9.5f)
                         {
                            movementOn=false;
                            translationX = 0f;
                            translationZ = 0f;
                            transformOn = true;
                            activeZ=true;
                            selectTransform = new Vector3(relativeX + 1f + addRelative, this.transform.position.y , relativeZ + 0.5f); 
                        }
                           if(Input.GetKeyDown("a") || Input.GetKeyDown("left")  && this.transform.position.x >0.5f)
                         {
                            movementOn=false;
                            translationX = 0f;
                            translationZ = 0f;
                            transformOn = true;
                            activeZ=true;
                            selectTransform = new Vector3(relativeX - 1f + addRelative, this.transform.position.y , relativeZ + 0.5f); 
                        }
                }
            }
        }
        if(transformOn)
        {
            if(activeZ)
            {
                if(this.transform.position != selectTransform)
                {
                    if(this.transform.position.z < selectTransform.z)
                    {
                        this.transform.position = new Vector3(
                                                                this.transform.position.x,
                                                                this.transform.position.y,
                                                                this.transform.position.z + 2 * Time.deltaTime
                                                             );                 
                    }
                    else
                    {
                        this.transform.position = new Vector3(
                                                                relativeX + 0.5f,
                                                                this.transform.position.y,
                                                                selectTransform.z
                                                             );    
                        activeX = true;
                        activeZ = false;
                    }
                }
            }
            if(activeX)
            {

                if(this.transform.position.x < selectTransform.x)
                {
                    this.transform.position = new Vector3(
                                                            this.transform.position.x + 2 * Time.deltaTime,
                                                            this.transform.position.y,
                                                            this.transform.position.z
                                                         );    
                }
                else
                {
                    this.transform.position = new Vector3(
                                                            selectTransform.x,
                                                            this.transform.position.y,
                                                            selectTransform.z
                                                         );  
                    transformOn=false;
                    movementOn = true;
                    activeX=false;
                }
               
            }
        }
       
        if(transformOnVertical)
        {
               if(activeX)
            {

                if(this.transform.position.x < selectTransform.x)
                {
                    this.transform.position = new Vector3(
                                                            this.transform.position.x + 2 * Time.deltaTime,
                                                            this.transform.position.y,
                                                            this.transform.position.z
                                                         );    
                }
                else
                {
                    this.transform.position = new Vector3(
                                                            selectTransform.x,
                                                            this.transform.position.y,
                                                            relativeZ + 0.5f
                                                         );  
                    activeZ = true;
                    activeX = false;
                }
               
            }
            if(activeZ)
            {
                if(this.transform.position != selectTransform)
                {
                    if(this.transform.position.z < selectTransform.z)
                    {
                        this.transform.position = new Vector3(
                                                                this.transform.position.x,
                                                                this.transform.position.y,
                                                                this.transform.position.z + 2 * Time.deltaTime
                                                             );                 
                    }
                    else
                    {
                        this.transform.position = new Vector3(
                                                                selectTransform.x,
                                                                this.transform.position.y,
                                                                selectTransform.z
                                                             );    
                        transformOnVertical=false;
                        movementOn = true;
                        activeZ=false;
                    }
                }
            }
         
        }
    }
}
