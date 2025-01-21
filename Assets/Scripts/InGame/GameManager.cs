using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;//ó���� null ä������� 

    [Header("�����")]
    [SerializeField] List<GameObject> listEnemy; //���⸦ List�� ����
    //GameObject fabExplosion;//���� �����͸� ������ �ִ� ������ private�� �����ϰ�
    [SerializeField] GameObject fabBoss;

    [Header("�� ���� ����")]
    [SerializeField] bool isSpawn = false;//������ �����ϰų� ���ϴ� ������ ������ üũ�Ͽ� ���

    bool isSpawnBoss = false;//���� ���� ������ üũ 
    //true�� ������ ������ ����� ������ �ʰ� �� �뵵

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
        //Script Common�� ����� ���� �ڵ忡 Tool�� �����Ͽ� ���۽�Ű�� ���
        //if (Tool.isStartingMainScene == false)
        //{
        //    UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        //}

        //1���� �����ؾ���
        if (Instance == null)
        {
            Instance = this;
        }
        else//�ν��Ͻ��� �̹� �����Ѵٸ� ���� ����������
        {
            //Destroy(this);//�̷��� ������Ʈ�� ������
            Destroy(gameObject);//������Ʈ�� �������鼭 ��ũ��Ʈ�� ���� ������
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
        //��� hp���� �˷������
        //HPMPfunction.SetHp(_maxHp, _curHp);
    }


}
