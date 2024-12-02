using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenLimit : MonoBehaviour
{
    //ī�޶� WorldToViewportPoint�� ����Ͽ� ���忡�� ����Ʈ�� ����
    //ī�޶� �����ϴ��� (0.0 , 0.0) ��������� (1.0 , 1.0)�̴�
    [Header("ȭ�� ���")]//viewport ����
    [SerializeField] Vector3 viewPortLimitMax;
    [SerializeField] Vector3 viewPortLimitMin;
    

    GameObject Player;
    Camera cam;
    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.instance;
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        screenLimit(); 
    }

    private void screenLimit() 
    {
        //���� �÷��̾��� ���� ��ǥ(Player.transform.position)�� ����Ʈ ���� ��ǥ�� ����
        Vector3 viewPos = Camera.main.WorldToViewportPoint(Player.transform.position);

        if(viewPos.x < 0f)
        {
            viewPos.x = 0f;
        }
        if (viewPos.x > 1f)
        {
            viewPos.x = 1f;
        }
        if (viewPos.y < 0f)
        {
            viewPos.y = 0f;
        }
        if (viewPos.y > 1f)
        {
            viewPos.y = 1f;
        }

        Player.transform.position = Camera.main.ViewportToWorldPoint(viewPos);

        //Clamp01�� Ȱ���� ȭ������ 
        //Mathf.Clamp01(��) - �Էµ� ���� 0~1 ���̸� ����� ���ϰ� ������ ������ �ִ� �Լ�
        //viewPos.x = Mathf.Clamp01(viewPos.x);
        //viewPos.y = Mathf.Clamp01(viewPos.y);

        //Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);
        //Player.transform.position = worldPos;
    }

}
