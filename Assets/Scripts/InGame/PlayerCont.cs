using System.Collections;
using System.Collections.Generic;
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

    private void NormalAtk()//Z키를 누르면 노말샷
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            
        }
    }

    private void PowerAtk()//X키를 누르면 2초간 차지 후 파워샷
    {
        if (Input.GetKeyDown(KeyCode.X))
        {

        }
    }
}
