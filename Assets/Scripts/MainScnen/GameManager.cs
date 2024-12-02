using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //싱글톤 인스턴트 선언
    public static GameManager instance;

    [Header("포탈 체크")]
    public bool Epi1Potar = false;
    public bool Epi2Potar = false;
    public bool Epi3Potar = false;

    private void Awake()
    {
        //초기화
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PotarCont();
    }

    private void PotarCont()
    {
        if(Epi1Potar == true)
        {
            //태그가 포탈이며 게임오브젝트 이름이 튜토리얼 포탈이면 게임씬 변경
            SceneManager.LoadScene(2);
        }
    }
}
