using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerCont : MonoBehaviour
{
    [Header("플레이어 체력")]
    [SerializeField] float MaxHp;
    [SerializeField] float CurHp;
    [SerializeField] float MaxMP;
    [SerializeField] float CurMp;

    [Header("플레이어 이동속도")]
    [SerializeField] float MoveSpeed;

    [Header("플레이어 공격력")]
    [SerializeField] float NormalShot;
    [SerializeField] float PowerShot;

    [Header("총알")]
    [SerializeField] GameObject FabBullet;//프리펩 원본 오브젝트 사용
    [SerializeField] GameObject FabPowerBullet;
    [SerializeField] Transform PrefabObject;//프리펩 오브젝트 생성 시 위치
    [SerializeField] Transform ShootTrs;//공격 포지션
    [SerializeField] float fireRateTime = 0.5f;//이시간이 지나면 총알이 발사됨
    float fireTimer = 0;//fireRateTime 시간을 측정하기 위한 변수


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

        //방향키에 따른 움직임
        MoveDir = (new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));

        // 방향키에 따른 움직임 + 속도 + Time.deltaTime
        transform.position += MoveDir * MoveSpeed * Time.deltaTime;
        rigid.velocity = MoveDir;//MoveDir;
    }

    private void normalAtk()//Z키를 누르면 노말샷
    {
        if(Input.GetKey(KeyCode.Z) == true)
        {
            createBullet();
            fireTimer += Time.deltaTime;//시간 측정, 1초가 지나면 1이 될수있도록 소수점들이 fireTimer에 쌓임
            if (fireTimer > fireRateTime)
            {
                createBullet();
            }
            fireTimer = 0;
        }
    }

    private void powerAtk()//X키를 누르면 2초간 차지 후 파워샷
    {
        if (Input.GetKeyDown(KeyCode.X) == true)
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
