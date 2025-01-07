using Platformer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{
    [Header("�÷��̾� ����")]
    [SerializeField] int PlayerLevel = 1;
    [SerializeField] float Exp = 0;

    [Header("�÷��̾� ü��")]
    [SerializeField] public float MaxHp;
    [SerializeField] public float CurHp;
    [SerializeField] public float MaxMP;
    [SerializeField] public float CurMp;

    [Header("�÷��̾� �̵��ӵ�")]
    [SerializeField] float MoveSpeed;

    [Header("�÷��̾� ���ݷ�")]
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
        //�±װ� ��Ż�̰� ���̾ TutoPotar�̸� True
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

        //FindObjectOfType<>(); ������ ������ �����ϰ� ������ Ŭ�����Է�, public ������ ����
        //sceneManager = FindObjectOfType<SceneManager>();
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
