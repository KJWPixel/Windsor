using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Enemy Class 다른 Enemy와 상속할 '부모클래스'
    //private 내부 클래스에서만 접근 가능한 접근제한자
    //protected 외부에서는 접근이 불가능하지만 상속한 클래스에서는 접근할 수 있는 접근제한자

    #region 프로텍티드 protected 
    [Header("적 체력")]
    [SerializeField] protected float MaxHp;
    [SerializeField] protected float CurHp;
    [Header("적 이동속도")]
    [SerializeField] protected float EnemySpeed;
    [Header("적 공격력")]
    [SerializeField] public float EnemtAtkPower;
    [Header("적 점수")]
    [SerializeField] protected float score;
    #endregion

    [SerializeField] private bool AtkCheck = false;//AtkCheck가 true일때만 Bullet 발사 
    [SerializeField] GameObject EnemyBullet;//Enemy Bullet
    [SerializeField] Transform EnemyShotTrs;//Enemy Bullet
    [SerializeField] Transform PrefabObject;//Enemy Bullet

    [SerializeField] float invincibiltyTime;
    [SerializeField] float invincibiltyTimer;

    //Enemy 기능 Check
    private bool isDied = false;
    private bool enemyinvincibiltyCheck = false;

    Vector3 MoveDir;
    Rigidbody2D rigid;
    Collider2D collider;
    SpriteRenderer spriteRenderer;
    Animation anim;


    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")//플레이어와 접촉하였을 시 플레이어Hit(매개변수) 함수로 Hp 감소
        {
            PlayerControll player = other.GetComponent<PlayerControll>();
            player.Hit(EnemtAtkPower);
        }
    }
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animation>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void createBullet()
    {
        if(AtkCheck == true)
        {
            GameObject go = Instantiate(EnemyBullet, EnemyShotTrs.position, Quaternion.identity, PrefabObject);
            Bullet goSc = go.GetComponent<Bullet>();
            //goSc.isShootEnemy = true;
        }
    }

    public void Hit(float _damage)//총알에 맞을 시 동작하게 
    {
        if(isDied == true)//Enemy isDied가 True면 리턴
        {
            return;
        }

        CurHp -= _damage;
        //enemyinvincibiltyCheck = true;

        if (CurHp <= 0)
        {
            isDied = true;
            Destroy(gameObject);
        }
    }

    private void invincibiltyCheck()//Hit되었을 시 Color.a 값을 변경시켜줄 함수
    {
        Color color = spriteRenderer.color;
        if (enemyinvincibiltyCheck == true)
        {
            color.a = 0.5f;
            invincibiltyTimer += Time.deltaTime;
        }
        
        if(invincibiltyTimer > invincibiltyTime)//지정시간을 넘을 시 color.a 1, 시간 초기화 및 false
        {
            color.a = 1f;
            invincibiltyTimer = 0;
            enemyinvincibiltyCheck = false;
        }
        spriteRenderer.color = color;
    }
}
