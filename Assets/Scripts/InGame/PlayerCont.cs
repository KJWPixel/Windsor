using System.Collections;
using System.Collections.Generic;
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

        //����Ű�� ���� ������
        MoveDir = (new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));

        // ����Ű�� ���� ������ + �ӵ� + Time.deltaTime
        transform.position += MoveDir * MoveSpeed * Time.deltaTime;
        rigid.velocity = MoveDir;//MoveDir;
    }

    private void NormalAtk()//ZŰ�� ������ �븻��
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            
        }
    }

    private void PowerAtk()//XŰ�� ������ 2�ʰ� ���� �� �Ŀ���
    {
        if (Input.GetKeyDown(KeyCode.X))
        {

        }
    }
}
