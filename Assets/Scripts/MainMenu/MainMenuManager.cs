using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] Button StartBtn;
    [SerializeField] Button ContinueBtn;
    [SerializeField] Button ExitBtn;
    [SerializeField] Button ExitReconfirmBtn;
    [SerializeField] Button ExitCancelBtn;
    [SerializeField] GameObject ExitWindow;

    private bool ExitWindowOn;

    private void Awake()
    {
        init();
        StartBtn.onClick.AddListener(GameStart);
        ContinueBtn.onClick.AddListener(Continuing);
        ExitBtn.onClick.AddListener(GameExit);
        ExitReconfirmBtn.onClick.AddListener(GameExitReconfirm);
        ExitCancelBtn.onClick.AddListener(NotGameExit);

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void init()
    {
        Application.targetFrameRate = 60;
        ExitWindow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GameStart()
    {
        //���ӽ��� ���ΰ������� �̵�
        //SceneManager.LoadScene(1);
    }

    private void Continuing()
    {

    }

    private void GameExit()
    {
        ExitWindow.SetActive(true);
    }

    private void NotGameExit()
    {
        ExitWindow.SetActive(false);
    }


    private void GameExitReconfirm()
    {
        //����Ȯ��â�� ���� ���� �� ��������
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
    }
}
