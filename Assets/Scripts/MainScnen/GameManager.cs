using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //게임매니저 싱글톤 인스턴트 선언
    //게임매니저의 인스턴스를 담는 전역변수(static 변수이지만 쉽게 전역변수)
    //이 게임 내에서 게임매니저 인스턴스는 이 instance에 담긴 녀석만 존재하게 할 것이다.
    //보안을 위해 private
    private static GameManager instance = null;

    [Header("포탈 체크")]
    public bool Ep1Potar = false;
    public bool Ep2Potar = false;
    public bool Ep3Potar = false;

    private void Awake()
    {
        if(null == instance)
        {
            //이 클래스 인스턴스가 생성했을 때 전역변수 instance에 게임매니저 인스턴스가 담겨있지 않다면, 자신을 넣어준다.
            instance = this;

            //씬 전환이 되더라도 파괴되지 않게 된다.
            //gameObject만으로도 이 스크립ㅌ트가 컴포넌트로서 붙어있는 Hierarchy상의 게임오브젝트라는 뜻이지만,
            //헷갈림 바이를 위해 this를 붙여주기도 한다.
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            //만약 씬이 이동이 되었는데 그 씬에도 Hierarchy에 GameMgr가 존재할 수도 있다.
            //그럴 경우엔 이전 씬ㄴ에서 사용하던 인스턴스를 계속사용해주는 경우가 많은 것 같다.
            //그래서 이미 전역변수인 instance에 인스턴스가 존재한다면 자신(새로운 씬 GameMgr)을 삭제해준다.
            Destroy(this.gameObject);
        }
    }

    //게임 매니저 인스턴스에 접근할 수 있는 프로퍼티, static이므로 다른 클래스에서 맘껏 호출할 수 있다.
    public static GameManager Instance
    {
        get
        {
            if(null ==  Instance)
            {
                return null;
            }
            return Instance;
        }
    }

    public void InitGame()
    {

    }
    public void PauseGame()
    {

    }
    public void ContinueGame()
    {

    }
    public void RestartGame()
    {

    }
    public void StopGame()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PotarActiv();
    }

    private void PotarActiv()//플레이어가 포탈에 닿았다면 동작
    {
        if(Ep1Potar == true)
        {
            //태그가 포탈이며 게임오브젝트 이름이 튜토리얼 포탈이면 게임씬 변경
            SceneManager.LoadScene(2);
        }
    }
}
