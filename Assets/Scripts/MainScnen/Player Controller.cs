using Platformer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Header("�÷��̾� ����")]
    [SerializeField] int PlayerLevel = 1;
    [Header("�÷��̾� ü��")]
    [SerializeField] float PlayerMaxHP = 10;
    [SerializeField] float PlayerCurHP = 10;
    [SerializeField] float PlayerMaxMP = 10;
    [SerializeField] float PlayerCurMP = 10;

    [Header("�÷��̾� �̵�")]
    [SerializeField] float MoveSpeed = 0;

    private Camera cam;
    private Rigidbody2D Rigidbody;
    private Collider2D Collider;
    private Animator Anim;
    private Vector3 MoveDir;
    GameManager gameManager; //���� ����
    

    private void OnTriggerEnter2D(Collider2D collider)
    {
        //�±װ� ��Ż�̰� ���̾ TutoPotar�̸� True
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
        //������ ������ �����ϰ� ������ Ŭ�����Է�, public ������ ����
        gameManager = FindObjectOfType<GameManager>();
    }

    
    void Update()
    {
        Anims();
        PlayerMove();
    }

    private void Anims()
    {  
       //Horizontal, Vertical ���� ���� Run�ִϸ��̼� ����
       Anim.SetInteger("Horizontal", (int)MoveDir.x);
       Anim.SetInteger("Vertical", (int)MoveDir.y);
    }

    private void PlayerMove()
    {
        //MoveDir.x = Input.GetAxisRaw("Horizontal") * MoveSpeed;
        //MoveDir.y = Input.GetAxisRaw("Vertical") * MoveSpeed;

        //����Ű�� ���� ������
        MoveDir = (new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));
        //�÷��̾��� ���⿡ ���� �ٶ󺸴� ��������Ʈ ����
        if(MoveDir.x < 0f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if(MoveDir.x > 0f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        // ����Ű�� ���� ������ + �ӵ� + Time.deltaTime
        transform.position += MoveDir * MoveSpeed * Time.deltaTime;
        Rigidbody.velocity = MoveDir;//MoveDir;
    }


}
