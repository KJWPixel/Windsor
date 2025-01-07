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

    #region ��������Ʈ private
    SpriteRenderer spriteRenderer;
    Animation anim;
    [SerializeField] private Sprite hitSprite;
    [SerializeField] float invincibiltyTime;
    [SerializeField] float invincibiltyTimer;

    private bool isDied = false;
    private bool enemyinvincibiltyCheck = false;
    
    #endregion

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "player")//�÷��̾�� �����Ͽ��� �� Hit()
        {
            PlayerCont player = collision.GetComponent<PlayerCont>();
            player.Hit(EnemtAtkPower);
        }
    }
    private void Awake()
    {
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
