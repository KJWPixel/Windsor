using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Enemy Class 다른 Enemy와 상속할 '부모클래스'
    //private 내부 클래스에서만 접근 가능한 접근제한자
    //protected 외부에서는 접근이 불가능하지만 상속한 클래스에서는 접근할 수 있는 접근제한자

    #region 프로텍티드 protected 
    [Header("적 체력")]
    [SerializeField] protected float MaxHp;
    [SerializeField] protected float CurHp;
    [Header("적 이동속도")]
    [SerializeField] protected float EnemySpeed;
    [Header("적 공격력")]
    [SerializeField] protected float EnemtAtkPower;
    [Header("적 점수")]
    [SerializeField] protected float score;
    #endregion

    #region 프리베이트 private
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
