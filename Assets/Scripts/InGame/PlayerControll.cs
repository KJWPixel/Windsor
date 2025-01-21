using Platformer;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Runtime.ConstrainedExecution;
using System.Threading;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerControll : MonoBehaviour
{
    [Header("�÷��̾� ü��")]
    [SerializeField] float MaxHp;
    [SerializeField] float CurHp;
    [SerializeField] float MaxMP;
    [SerializeField] float CurMp;
    float beforeHp;

    [Header("�÷��̾� �̵��ӵ�")]
    [SerializeField] float MoveSpeed;

    [Header("�÷��̾� ���ݷ�")]
    [SerializeField] float NormalShot;
    [SerializeField] float PowerShot;
    [SerializeField] bool NoramlAtkCheck;
    [SerializeField] bool PowerAtkCheck;

    [Header("�Ѿ�")]
    [SerializeField] GameObject FabBullet;//������ ���� ������Ʈ ���
    [SerializeField] GameObject FabPowerBullet;
    [SerializeField] Transform PrefabObject;//������ ������Ʈ ���� �� ��ġ
    [SerializeField] Transform ShootTrs;//���� ������
    [SerializeField] float fireRateTime = 0f;//�̽ð��� ������ �Ѿ��� �߻��
    [SerializeField] float firePowerRateTime = 0f;
    float fireTimer = 0;//fireRateTime �ð��� �����ϱ� ���� ����

    [Header("�÷��̾� ȭ�� ����")]//Range�� �̿��Ͽ� ��ġ�� ������
    [SerializeField, Range(0.0f, 1f)] float viewPortLimitMinX;
    [SerializeField, Range(0.0f, 1f)] float viewPortLimitMinY;
    [SerializeField, Range(0.0f, 1f)] float viewPortLimitMaxX;
    [SerializeField, Range(0.0f, 1f)] float viewPortLimitMaxY;

    GameManager gameManager;
    Vector3 MoveDir;
    Rigidbody2D rigid;
    Collider2D collider;
    Animator Anim;
    private WindowLimiter limiter;
    Camera cam;

    private void OnValidate()//�ν����Ϳ��� ����� ������ ����� ȣ��
    {
        if (Application.isPlaying == false)//����Ƽ�����Ͱ� PlayMode���� �Ǵ�
        {
            return;
        }

        //if (beforeHp != CurHp)
        //{
        //    beforeHp = CurHp;
        //    GameManager.Instance.SetHp(MaxHp, CurHp);
        //}
    }

    private void Awake()
    {
        
    }

    private void InitPlayer()//������ ó�� �����ϸ� �ʱ�ȭ�� ����
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
        Anim = GetComponent<Animator>();
        cam = Camera.main;
        gameManager = GameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        checkPlayerPos();
        normalAtk();
        powerAtk();
        
    }

    private void PlayerMove()//Player Move���� 
    {
        //MoveDir.x = Input.GetAxisRaw("Horizontal") * MoveSpeed;
        //MoveDir.y = Input.GetAxisRaw("Vertical") * MoveSpeed;

        //����Ű�� ���� ������
        MoveDir = (new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));

        // ����Ű�� ���� ������ + �ӵ� + Time.deltaTime
        transform.position += MoveDir * MoveSpeed * Time.deltaTime;
        rigid.velocity = MoveDir;//MoveDir;
    }

    private void checkPlayerPos()//�÷��̾��� ȭ�� �̵� ����
    {
        //Vector3 ��������� ����Ʈ�� ���� => ȭ��� ���ϴ�(0,0) ����(1,1)�� �����  
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if(pos.x < viewPortLimitMinX) pos.x = viewPortLimitMinX;//����ȭ�� �ν����Ϳ��� ��������
        if(pos.x > viewPortLimitMaxX) pos.x = viewPortLimitMaxX;
        if(pos.y < viewPortLimitMinY) pos.y = viewPortLimitMinY;
        if(pos.y > viewPortLimitMaxY) pos.y = viewPortLimitMaxY;

        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }

    private void normalAtk()//ZŰ�� ������ �븻��
    {
        if (Input.GetKey(KeyCode.Z) == true)
        {
            fireTimer += Time.deltaTime;
            if (fireTimer > fireRateTime)
            {
                Debug.Log("�븻 ����");
                createBullet();
                fireTimer = 0;
            }
        }
    }

    private void powerAtk()//XŰ�� ������ 2�ʰ� ���� �� �Ŀ���, MP10 ����
    {
        if (Input.GetKey(KeyCode.X) == true && CurMp >= 30)
        {
            Debug.Log("�Ŀ� ���� ����");
            fireTimer += Time.deltaTime;
            
            if (fireTimer > firePowerRateTime)
            {
                Debug.Log("�Ŀ� ����");
                createPowerBullet();
                CurMp += -30;
                fireTimer = 0;
            }
        }
    }

    private void createBullet()
    {
        GameObject go = Instantiate(FabBullet, ShootTrs.position, Quaternion.identity, PrefabObject);
        Bullet goSc = go.GetComponent<Bullet>();
        //goSc.isShootEnemy = true;
    }

    private void createPowerBullet()
    {
        GameObject go = Instantiate(FabPowerBullet, ShootTrs.position, Quaternion.Euler(0, 0, 90), PrefabObject);
        Bullet goSc = go.GetComponent<Bullet>();
    }

    public void Hit(float _damage)
    {
        if(CurHp > 0)//�÷��̾��� Hp�� 0�ʰ��� Hit 
        {
            Debug.Log("�÷��̾� Hit");
            CurHp -= _damage;
        }
        else if (CurHp <= 0)//�÷��̾��� Hp�� 0���ϸ� Destroy �÷��̾�
        {
            Debug.Log("�÷��̾� Die");
            Destroy(gameObject);
        }
        

        
    }


}
