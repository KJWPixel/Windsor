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
    [Header("플레이어 체력")]
    [SerializeField] float MaxHp;
    [SerializeField] float CurHp;
    [SerializeField] float MaxMP;
    [SerializeField] float CurMp;
    float beforeHp;

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

    [Header("플레이어 화면 제한")]//Range를 이용하여 수치를 제한함
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

    private void OnValidate()//인스펙터에서 어떤값이 변동이 생기면 호출
    {
        if (Application.isPlaying == false)//유니티에디터가 PlayMode인지 판단
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

    private void InitPlayer()//게임을 처음 시작하면 초기화할 변수
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

    private void PlayerMove()//Player Move동작 
    {
        //MoveDir.x = Input.GetAxisRaw("Horizontal") * MoveSpeed;
        //MoveDir.y = Input.GetAxisRaw("Vertical") * MoveSpeed;

        //방향키에 따른 움직임
        MoveDir = (new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));

        // 방향키에 따른 움직임 + 속도 + Time.deltaTime
        transform.position += MoveDir * MoveSpeed * Time.deltaTime;
        rigid.velocity = MoveDir;//MoveDir;
    }

    private void checkPlayerPos()//플레이어의 화면 이동 제한
    {
        //Vector3 월드공간을 뷰포트로 변경 => 화면상 좌하단(0,0) 우상단(1,1)로 변경됨  
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if(pos.x < viewPortLimitMinX) pos.x = viewPortLimitMinX;//직렬화로 인스펙터에서 수정가능
        if(pos.x > viewPortLimitMaxX) pos.x = viewPortLimitMaxX;
        if(pos.y < viewPortLimitMinY) pos.y = viewPortLimitMinY;
        if(pos.y > viewPortLimitMaxY) pos.y = viewPortLimitMaxY;

        transform.position = Camera.main.ViewportToWorldPoint(pos);
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
            Debug.Log("파워 어택 차지");
            fireTimer += Time.deltaTime;
            
            if (fireTimer > firePowerRateTime)
            {
                Debug.Log("파워 어택");
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
        if(CurHp > 0)//플레이어의 Hp가 0초과면 Hit 
        {
            Debug.Log("플레이어 Hit");
            CurHp -= _damage;
        }
        else if (CurHp <= 0)//플레이어의 Hp가 0이하면 Destroy 플레이어
        {
            Debug.Log("플레이어 Die");
            Destroy(gameObject);
        }
        

        
    }


}
