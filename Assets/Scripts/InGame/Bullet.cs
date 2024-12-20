using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    [Header("총알 속도")]
    [SerializeField] float bulletSpeed;
    [SerializeField] float bulletDestroyTime = 1f;//총알 삭제 시간
    public bool isShootEnemy = true;

    private void OnBecameInvisible()
    {
        Destroy(gameObject, bulletDestroyTime);
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
        transform.rotation = Quaternion.Euler(0, 0, -90);//총알이 앞을 바라보고 있어서 옆으로 회전
        transform.position += transform.up * bulletSpeed * Time.deltaTime;//rotation을 회전하여 transform도 그대로 trasform.up
    }

    private void shootPlayer()
    {
        isShootEnemy = false;
    }
}
