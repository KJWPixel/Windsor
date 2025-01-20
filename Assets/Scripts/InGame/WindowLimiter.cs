using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowLimiter : MonoBehaviour
{
    //GameManager�� Component
    [Header("ȭ�� ���")]//viewport ����
    [SerializeField] Vector2 viewPortLimitMin;
    [SerializeField] Vector2 viewPortLimitMax;

    //[Header("������ ȭ�� ���")]
    //[SerializeField] Vector2 viewPortLimitMinBoss;
    //[SerializeField] Vector2 viewPortLimitMaxBoss;

    private Vector2 worldPosLimitMin;//���� �����ʹ� �� ������ ����������
    //LimitMin������ ����
    public Vector2 WorldPosLimitMin//�� �����ʹ� ������ �������� �Լ��� �۵�
    {
        get//private LimitMin������ ���ٺҰ��Ͽ� public���� private�� ���� ���Ͻ�Ŵ 
        {
            return worldPosLimitMin;
        }
    }

    private Vector2 worldPosLimitMax;
    public Vector2 WorldPosLimitMax => worldPosLimitMax;//���� ������ ��� ���ĸ��� �ٲ�

    Camera cam;
    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        gameManager = GameManager.Instance;
        initWorldPos();//worldPos�ʱ�ȭ
    }

    private void initWorldPos()//���ӽ��۽� ������Ʈ�� ȭ�� ��� �������� ���� ���������� �ʱ�ȭ �մϴ�.
    {
        worldPosLimitMin = cam.ViewportToWorldPoint(viewPortLimitMin);
        worldPosLimitMax = cam.ViewportToWorldPoint(viewPortLimitMax);
    }

    public Vector3 checkMovePosition(Vector3 _pos ) //bool _isBoss = false
    {
        Vector3 viewPortPos = cam.WorldToViewportPoint(_pos);

        if(viewPortPos.x < viewPortLimitMin.x)
        {
            viewPortPos.x = viewPortLimitMin.x;
        }
        else if (viewPortPos.x < viewPortLimitMax.x)
        {
            viewPortPos.x = viewPortLimitMax.x;
        }

        if (viewPortPos.y < viewPortLimitMin.y)
        {
            viewPortPos.y = viewPortLimitMin.y;
        }
        else if (viewPortPos.y > viewPortLimitMax.y)
        {
            viewPortPos.y = viewPortLimitMax.y;
        }

        return cam.ViewportToWorldPoint(viewPortPos);
    }

    //public bool checkMovePosition(Vector3 _pos)
    //{
    //    Vector3 viewPortPos = cam.WorldToViewportPoint(_pos);

    //    return false;
    //}


    // Update is called once per frame
    void Update()
    {
        
    }
}
