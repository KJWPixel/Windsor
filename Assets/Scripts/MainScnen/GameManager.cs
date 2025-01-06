using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //���ӸŴ��� �̱��� �ν���Ʈ ����
    //���ӸŴ����� �ν��Ͻ��� ��� ��������(static ���������� ���� ��������)
    //�� ���� ������ ���ӸŴ��� �ν��Ͻ��� �� instance�� ��� �༮�� �����ϰ� �� ���̴�.
    //������ ���� private
    private static GameManager instance = null;

    [Header("��Ż üũ")]
    public bool Ep1Potar = false;
    public bool Ep2Potar = false;
    public bool Ep3Potar = false;

    private void Awake()
    {
        if(null == instance)
        {
            //�� Ŭ���� �ν��Ͻ��� �������� �� �������� instance�� ���ӸŴ��� �ν��Ͻ��� ������� �ʴٸ�, �ڽ��� �־��ش�.
            instance = this;

            //�� ��ȯ�� �Ǵ��� �ı����� �ʰ� �ȴ�.
            //gameObject�����ε� �� ��ũ����Ʈ�� ������Ʈ�μ� �پ��ִ� Hierarchy���� ���ӿ�����Ʈ��� ��������,
            //�򰥸� ���̸� ���� this�� �ٿ��ֱ⵵ �Ѵ�.
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            //���� ���� �̵��� �Ǿ��µ� �� ������ Hierarchy�� GameMgr�� ������ ���� �ִ�.
            //�׷� ��쿣 ���� �������� ����ϴ� �ν��Ͻ��� ��ӻ�����ִ� ��찡 ���� �� ����.
            //�׷��� �̹� ���������� instance�� �ν��Ͻ��� �����Ѵٸ� �ڽ�(���ο� �� GameMgr)�� �������ش�.
            Destroy(this.gameObject);
        }
    }

    //���� �Ŵ��� �ν��Ͻ��� ������ �� �ִ� ������Ƽ, static�̹Ƿ� �ٸ� Ŭ�������� ���� ȣ���� �� �ִ�.
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

    private void PotarActiv()//�÷��̾ ��Ż�� ��Ҵٸ� ����
    {
        if(Ep1Potar == true)
        {
            //�±װ� ��Ż�̸� ���ӿ�����Ʈ �̸��� Ʃ�丮�� ��Ż�̸� ���Ӿ� ����
            SceneManager.LoadScene(2);
        }
    }
}
