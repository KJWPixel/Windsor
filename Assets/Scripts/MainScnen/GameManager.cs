using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //�̱��� �ν���Ʈ ����
    public static GameManager instance;

    [Header("��Ż üũ")]
    public bool Epi1Potar = false;
    public bool Epi2Potar = false;
    public bool Epi3Potar = false;

    private void Awake()
    {
        //�ʱ�ȭ
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
            //�±װ� ��Ż�̸� ���ӿ�����Ʈ �̸��� Ʃ�丮�� ��Ż�̸� ���Ӿ� ����
            SceneManager.LoadScene(2);
        }
    }
}
