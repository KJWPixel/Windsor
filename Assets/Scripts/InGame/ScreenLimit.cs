using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenLimit : MonoBehaviour
{
    //카메라 WorldToViewportPoint를 사용하여 월드에서 뷰포트로 변경
    //카메라 좌측하단은 (0.0 , 0.0) 우측상단은 (1.0 , 1.0)이다
    [Header("화면 경계")]//viewport 기준
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
        //현재 플레이어의 월드 좌표(Player.transform.position)를 뷰포트 기준 좌표로 변경
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

        //Clamp01를 활용한 화면제한 
        //Mathf.Clamp01(값) - 입력된 값이 0~1 사이를 벗어나지 못하게 강제로 조정해 주는 함수
        //viewPos.x = Mathf.Clamp01(viewPos.x);
        //viewPos.y = Mathf.Clamp01(viewPos.y);

        //Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);
        //Player.transform.position = worldPos;
    }

}
