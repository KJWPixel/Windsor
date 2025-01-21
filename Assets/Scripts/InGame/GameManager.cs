using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;//처음은 null 채워줘야함 

    [Header("적기들")]
    [SerializeField] List<GameObject> listEnemy; //적기를 List로 정리
    //GameObject fabExplosion;//실제 데이터를 가지고 있는 변수는 private를 유지하고
    [SerializeField] GameObject fabBoss;

    [Header("적 생성 여부")]
    [SerializeField] bool isSpawn = false;//보스가 등장하거나 원하는 사유가 있을때 체크하여 사용

    bool isSpawnBoss = false;//보스 등장 중인지 체크 
    //true면 보스를 제외한 적기는 나오지 않게 할 용도

    //private WindowLimiter limiter;
    //public WindowLimiter _Limiter
    //{
    //    get { return limiter; }
    //    set { limiter = value; }
    //}

    //PlayerControll player;
    //public PlayerControll _Player
    //{
    //    get { return player; }
    //    set { player = value; }
    //}

    private void Awake()
    {
        //Script Common을 만들어 내부 코드에 Tool을 선언하여 동작시키는 방법
        //if (Tool.isStartingMainScene == false)
        //{
        //    UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        //}

        //1개만 존재해야함
        if (Instance == null)
        {
            Instance = this;
        }
        else//인스턴스가 이미 존재한다면 나는 지워져야함
        {
            //Destroy(this);//이러면 컴포넌트만 삭제됨
            Destroy(gameObject);//오브젝트가 지워지면서 스크립트도 같이 지워짐
        }
    }

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetHp(float _maxHp, float _curHp)
    {
        //펑션 hp에게 알려줘야함
        //HPMPfunction.SetHp(_maxHp, _curHp);
    }


}
