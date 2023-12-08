using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Butterfly : MonoBehaviour
{
    public float speed = 3f;
    public Vector3 myTransform;
    private Vector2 targetPos;


    [SerializeField]
    private float locationTime = 3f;
    private float countdown = 0f;

    private ButterflyManager butterflyManager;
    private EggCup eggCup;


    public virtual void Awake()
    {
        
        butterflyManager = GameObject.Find("butterflyManager1").GetComponent<ButterflyManager>();
        eggCup = GameObject.Find("eggCup").GetComponent<EggCup>();

    }


    public virtual void Start()
    {
        
        myTransform = new Vector3(butterflyManager.transform.position.x + Random.Range(-1.5f, 1.5f), butterflyManager.transform.position.y + Random.Range(0.5f, 2f), 0f);

    }


    void Update()
    {

        countdown += Time.deltaTime;

        // 타이머 
        if (countdown >= locationTime)
        {
            // 나비의 도착지점. 타겟
            myTransform = new Vector3(Random.Range(-8f, 6f), Random.Range(-4.5f, 4.5f), 0f);

            // 타이머 초기화
            countdown = 0;
        }

        Move();

    }

 

    void Move()
    {
        targetPos = myTransform - this.transform.position;
        

        if (targetPos.magnitude < 0.1f)
        {
            transform.position = myTransform;
        }
        else
        {
            //이동
            this.transform.Translate(targetPos.normalized * speed * Time.deltaTime, Space.World); 

            //각도
            float angle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle - 90);

        }

        
    }


}
