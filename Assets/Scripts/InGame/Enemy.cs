using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Enemy Class �ٸ� Enemy�� ����� '�θ�Ŭ����'
    //private ���� Ŭ���������� ���� ������ ����������
    //protected �ܺο����� ������ �Ұ��������� ����� Ŭ���������� ������ �� �ִ� ����������

    #region ������Ƽ�� protected 
    [Header("�� ü��")]
    [SerializeField] protected float MaxHp;
    [SerializeField] protected float CurHp;
    [Header("�� �̵��ӵ�")]
    [SerializeField] protected float EnemySpeed;
    [Header("�� ���ݷ�")]
    [SerializeField] public float EnemtAtkPower;
    [Header("�� ����")]
    [SerializeField] protected float score;
    #endregion

    [SerializeField] private bool AtkCheck = false;//AtkCheck�� true�϶��� Bullet �߻� 
    [SerializeField] GameObject EnemyBullet;//Enemy Bullet
    [SerializeField] Transform EnemyShotTrs;//Enemy Bullet
    [SerializeField] Transform PrefabObject;//Enemy Bullet

    [SerializeField] float invincibiltyTime;
    [SerializeField] float invincibiltyTimer;

    //Enemy ��� Check
    private bool isDied = false;
    private bool enemyinvincibiltyCheck = false;

    Vector3 MoveDir;
    Rigidbody2D rigid;
    Collider2D collider;
    SpriteRenderer spriteRenderer;
    Animation anim;


    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")//�÷��̾�� �����Ͽ��� �� �÷��̾�Hit(�Ű�����) �Լ��� Hp ����
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

    public void Hit(float _damage)//�Ѿ˿� ���� �� �����ϰ� 
    {
        if(isDied == true)//Enemy isDied�� True�� ����
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

    private void invincibiltyCheck()//Hit�Ǿ��� �� Color.a ���� ��������� �Լ�
    {
        Color color = spriteRenderer.color;
        if (enemyinvincibiltyCheck == true)
        {
            color.a = 0.5f;
            invincibiltyTimer += Time.deltaTime;
        }
        
        if(invincibiltyTimer > invincibiltyTime)//�����ð��� ���� �� color.a 1, �ð� �ʱ�ȭ �� false
        {
            color.a = 1f;
            invincibiltyTimer = 0;
            enemyinvincibiltyCheck = false;
        }
        spriteRenderer.color = color;
    }
}
