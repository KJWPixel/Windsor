using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Enemy Class �ٸ� Enemy�� ����� '�θ�Ŭ����'
    //private ���� Ŭ���������� ���� ������ ����������
    //protected �ܺο����� ������ �Ұ��������� ����� Ŭ���������� ������ �� �ִ� ����������

    #region ������Ƽ�� protected 
    [Header("�� ü��")]
    [SerializeField] protected float MaxHp;
    [SerializeField] protected float CurHp;
    [Header("�� �̵��ӵ�")]
    [SerializeField] protected float EnemySpeed;
    [Header("�� ���ݷ�")]
    [SerializeField] protected float EnemtAtkPower;
    [Header("�� ����")]
    [SerializeField] protected float score;
    #endregion

    #region ��������Ʈ private
    Sprite defaultSprite;
    [SerializeField] private Sprite hitSprite;

    private bool isDied = false;
    #endregion

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "player")
        {

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Hit(float _damage)
    {

    }
}
