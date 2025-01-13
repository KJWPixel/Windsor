using Platformer;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Threading;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerCont : MonoBehaviour
{
    [Header("�÷��̾� ü��")]
    [SerializeField] float MaxHp;
    [SerializeField] float CurHp;
    [SerializeField] float MaxMP;
    [SerializeField] float CurMp;

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


    Vector3 MoveDir;
    Rigidbody2D rigid;
    Collider2D collider;
    Animator Anim;

   

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        normalAtk();
        powerAtk();
        
    }

    private void PlayerMove()
    {
        //MoveDir.x = Input.GetAxisRaw("Horizontal") * MoveSpeed;
        //MoveDir.y = Input.GetAxisRaw("Vertical") * MoveSpeed;

        //����Ű�� ���� ������
        MoveDir = (new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));

        // ����Ű�� ���� ������ + �ӵ� + Time.deltaTime
        transform.position += MoveDir * MoveSpeed * Time.deltaTime;
        rigid.velocity = MoveDir;//MoveDir;
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
            fireTimer += Time.deltaTime;
            
            if (fireTimer > firePowerRateTime)
            {
                Debug.Log("�Ŀ� ���� ����");
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
        Debug.Log("�÷��̾� Hit");
        CurHp -= _damage;
    }


}
