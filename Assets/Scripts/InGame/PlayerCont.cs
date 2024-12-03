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


    private Vector3 MoveDir;
    private Rigidbody2D rigid;
    private Collider2D collider;
    private Animator Anim;

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


            //createBullet();
            //fireTimer += Time.deltaTime;//�ð� ����, 1�ʰ� ������ 1�� �ɼ��ֵ��� �Ҽ������� fireTimer�� ����
            //if (fireTimer > fireRateTime)
            //{
            //    createBullet();
            //    fireTimer = 0;
            //}

        }
    }

    private void powerAtk()//XŰ�� ������ 2�ʰ� ���� �� �Ŀ���, MP10 ����
    {
        if (Input.GetKey(KeyCode.X) == true)
        {      
            
        }
    }

    private void createBullet()
    {
        GameObject go = Instantiate(FabBullet, ShootTrs.position, Quaternion.identity, PrefabObject);
        Bullet goSc = go.GetComponent<Bullet>();
        //goSc.isShootEnemy = true;
    }


}
