using Platformer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Header("플레이어 레벨")]
    [SerializeField] int PlayerLevel = 1;
    [Header("플레이어 체력")]
    [SerializeField] float PlayerMaxHP = 10;
    [SerializeField] float PlayerCurHP = 10;
    [SerializeField] float PlayerMaxMP = 10;
    [SerializeField] float PlayerCurMP = 10;

    [Header("플레이어 이동")]
    [SerializeField] float MoveSpeed = 0;

    private Camera cam;
    private Rigidbody2D Rigidbody;
    private Collider2D Collider;
    private Animator Anim;
    private Vector3 MoveDir;
    GameManager gameManager; //변수 생성
    

    private void OnTriggerEnter2D(Collider2D collider)
    {
        //태그가 포탈이고 레이어가 TutoPotar이면 True
        if (collider.tag == "Potar" && collider.gameObject.layer == LayerMask.NameToLayer("TutoPotar"))
        {
            gameManager.Epi1Potar = true;
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
        //위에서 변수를 선언하고 연결할 클래스입력, public 변수만 가능
        gameManager = FindObjectOfType<GameManager>();
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
