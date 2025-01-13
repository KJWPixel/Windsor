using Platformer;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Threading;
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
    [SerializeField] bool NoramlAtkCheck;
    [SerializeField] bool PowerAtkCheck;

    [Header("총알")]
    [SerializeField] GameObject FabBullet;//프리펩 원본 오브젝트 사용
    [SerializeField] GameObject FabPowerBullet;
    [SerializeField] Transform PrefabObject;//프리펩 오브젝트 생성 시 위치
    [SerializeField] Transform ShootTrs;//공격 포지션
    [SerializeField] float fireRateTime = 0f;//이시간이 지나면 총알이 발사됨
    [SerializeField] float firePowerRateTime = 0f;
    float fireTimer = 0;//fireRateTime 시간을 측정하기 위한 변수


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

        //방향키에 따른 움직임
        MoveDir = (new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));

        // 방향키에 따른 움직임 + 속도 + Time.deltaTime
        transform.position += MoveDir * MoveSpeed * Time.deltaTime;
        rigid.velocity = MoveDir;//MoveDir;
    }

    private void normalAtk()//Z키를 누르면 노말샷
    {
        if (Input.GetKey(KeyCode.Z) == true)
        {
            fireTimer += Time.deltaTime;
            if (fireTimer > fireRateTime)
            {
                Debug.Log("노말 어택");
                createBullet();
                fireTimer = 0;
            }
        }
    }

    private void powerAtk()//X키를 누르면 2초간 차지 후 파워샷, MP10 감소
    {
        if (Input.GetKey(KeyCode.X) == true && CurMp >= 30)
        {
            fireTimer += Time.deltaTime;
            
            if (fireTimer > firePowerRateTime)
            {
                Debug.Log("파워 어택 차지");
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
        Debug.Log("플레이어 Hit");
        CurHp -= _damage;
    }


}
