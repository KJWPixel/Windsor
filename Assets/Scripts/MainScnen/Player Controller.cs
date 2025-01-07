using Platformer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{
    [Header("플레이어 레벨")]
    [SerializeField] int PlayerLevel = 1;
    [SerializeField] float Exp = 0;

    [Header("플레이어 체력")]
    [SerializeField] public float MaxHp;
    [SerializeField] public float CurHp;
    [SerializeField] public float MaxMP;
    [SerializeField] public float CurMp;

    [Header("플레이어 이동속도")]
    [SerializeField] float MoveSpeed;

    [Header("플레이어 공격력")]
    [SerializeField] public float NormalShot;
    [SerializeField] public float PowerShot;
    //[SerializeField] bool NoramlAtkCheck;
    //[SerializeField] bool PowerAtkCheck;

    private Camera cam;
    private Rigidbody2D Rigidbody;
    private Collider2D Collider;
    private Animator Anim;
    private Vector3 MoveDir;
    

    private void OnTriggerEnter2D(Collider2D collider)
    {
        //태그가 포탈이고 레이어가 TutoPotar이면 True
        if (collider.tag == "Potar" && collider.gameObject.layer == LayerMask.NameToLayer("Ep1Potar"))
        {
            //sceneManager.Ep1Potar = true;
        }
    }

    private void Awake()
    {

    }


    void Start()
    {
        cam = Camera.main;
        Rigidbody = GetComponent<Rigidbody2D>();
        Collider = GetComponent<Collider2D>();
        Anim = GetComponent<Animator>();

        //FindObjectOfType<>(); 위에서 변수를 선언하고 연결할 클래스입력, public 변수만 가능
        //sceneManager = FindObjectOfType<SceneManager>();
    }

    
    void Update()
    {
        Anims();
        PlayerMove();
    }

    private void Anims()
    {  
       //Horizontal, Vertical 값에 따른 Run애니메이션 제어
       Anim.SetInteger("Horizontal", (int)MoveDir.x);
       Anim.SetInteger("Vertical", (int)MoveDir.y);
    }

    private void PlayerMove()
    {
        //MoveDir.x = Input.GetAxisRaw("Horizontal") * MoveSpeed;
        //MoveDir.y = Input.GetAxisRaw("Vertical") * MoveSpeed;

        //방향키에 따른 움직임
        MoveDir = (new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));
        //플레이어의 방향에 따른 바라보는 스프라이트 제어
        if(MoveDir.x < 0f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if(MoveDir.x > 0f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        // 방향키에 따른 움직임 + 속도 + Time.deltaTime
        transform.position += MoveDir * MoveSpeed * Time.deltaTime;
        Rigidbody.velocity = MoveDir;//MoveDir;
    }


}
