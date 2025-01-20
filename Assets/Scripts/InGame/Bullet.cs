using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    [Header("�Ѿ� �ӵ�")]
    [SerializeField] float bulletSpeed;
    [SerializeField] float bulletDestroyTime = 1f;//�Ѿ� ���� �ð�
    [SerializeField] float bulletDamage;
    public bool isShootEnemy = true;

    private void OnBecameInvisible()
    {
        Destroy(gameObject, bulletDestroyTime);
    }

    private void OnTriggerEnter2D(Collider2D collision) //collision�� ��� �ݸ���
    {
        if (collision.tag == "player")
        {
            PlayerControll player = collision.GetComponent<PlayerControll>();
            player.Hit(bulletDamage);
        }

        if(collision.tag == "Enemy")
        {
            Destroy(gameObject);
            Enemy enemy = collision.GetComponent<Enemy>();
            enemy.Hit(bulletDamage);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bulletDir();
    }

    private void bulletDir()
    {
        transform.rotation = Quaternion.Euler(0, 0, -90);//�Ѿ��� ���� �ٶ󺸰� �־ ������ ȸ��
        transform.position += transform.up * bulletSpeed * Time.deltaTime;//rotation�� ȸ���Ͽ� transform�� �״�� trasform.up
    }

    private void shootPlayer()
    {
        isShootEnemy = false;
    }
}
