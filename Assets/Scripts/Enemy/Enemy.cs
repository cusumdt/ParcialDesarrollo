using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    private const int ghostPoint = 400;
  public enum EnemyState
    {
        Idle,
        Move,
        Last,
    }

    [SerializeField] 
    private EnemyState state;

    public float speed = 100;

    public enum Direccion
    {
        Up,
        Down,
        Left,
        Right,
    }
    public Direccion direccion;
    private float t;
    
    private GameObject stats;
    void Awake()
    {
        stats = GameObject.Find("GameManager");
    }
    private void Update()
    {
        t += Time.deltaTime;
        switch (state)
        {
            case EnemyState.Idle:
                if (t > 2)
                {
                    NextState();
                }
                break;
            case EnemyState.Move:
            switch(direccion)
            {
                case Direccion.Up:
                    this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + speed * Time.deltaTime);
                break;
                case Direccion.Down:
                    this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - speed * Time.deltaTime);
                break;
                case Direccion.Left:
                    this.transform.position = new Vector3(this.transform.position.x - speed * Time.deltaTime, this.transform.position.y, this.transform.position.z );
                break;
                case Direccion.Right:
                    this.transform.position = new Vector3(this.transform.position.x + speed * Time.deltaTime, this.transform.position.y, this.transform.position.z );
                break;
            }
            break;
        }
    }

    void OnCollisionEnter(Collision collision)
     {
         if(collision.gameObject.CompareTag("GeneralWall")
         ||collision.gameObject.CompareTag("Bomb")
         ||collision.gameObject.CompareTag("DestructibleWall")
         ||collision.gameObject.CompareTag("Enemy")
         ||collision.gameObject.CompareTag("EdibleEnemy"))
         {
             switch (direccion)
             {
                 case Direccion.Up:
                    direccion = Direccion.Down;
                 break;
                 case Direccion.Down:
                    direccion = Direccion.Up;
                 break;
                 case Direccion.Left:
                     direccion = Direccion.Right;
                 break;
                 case Direccion.Right:
                     direccion = Direccion.Left;
                 break;
             }
         }
         
         if(collision.gameObject.CompareTag("Player"))
         {
             if(this.gameObject.tag == "Enemy")
             {
                stats.GetComponent<GameManager>().SubtractLife(1);
             }else
             {
                stats.GetComponent<GameManager>().AddScore( ghostPoint );
                this.gameObject.SetActive(false);
             }
         }

     }
    private void NextState()
    {
        t = 0;
        int intState = (int) state;
        intState++;
        intState = intState%((int) EnemyState.Last);
        SetState((EnemyState) intState);
    }

    private void SetState(EnemyState es)
    {
        state = es;
    }
}
