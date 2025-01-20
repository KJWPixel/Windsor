using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowLimiter : MonoBehaviour
{
    //GameManager에 Component
    [Header("화면 경계")]//viewport 기준
    [SerializeField] Vector2 viewPortLimitMin;
    [SerializeField] Vector2 viewPortLimitMax;

    //[Header("보스용 화면 경계")]
    //[SerializeField] Vector2 viewPortLimitMinBoss;
    //[SerializeField] Vector2 viewPortLimitMaxBoss;

    private Vector2 worldPosLimitMin;//실제 데이터는 이 변수가 가지고있음
    //LimitMin변수를 갖음
    public Vector2 WorldPosLimitMin//이 데이터는 변수로 보이지만 함수로 작동
    {
        get//private LimitMin값으로 접근불가하여 public에서 private로 값을 리턴시킴 
        {
            return worldPosLimitMin;
        }
    }

    private Vector2 worldPosLimitMax;
    public Vector2 WorldPosLimitMax => worldPosLimitMax;//위와 동일한 결과 형식만을 바꿈

    Camera cam;
    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        gameManager = GameManager.Instance;
        initWorldPos();//worldPos초기화
    }

    private void initWorldPos()//게임시작시 뷰포인트의 화면 경계 변수들을 월드 포지션으로 초기화 합니다.
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
