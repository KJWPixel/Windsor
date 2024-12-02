using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    [Header("¹öÆ°")]
    [SerializeField] Button MenuBtn;
    [SerializeField] Button CancelBtn;
    [SerializeField] Button OptionBtn;
    [SerializeField] Button SaveBtn;
    [SerializeField] Button TitleBtn;
    [SerializeField] Button ExitBtn;
    [SerializeField] Button ExitReconfirmBtn;
    [SerializeField] Button ExitCancelBtn;

    [Header("UI Ã¢")]
    [SerializeField] GameObject MenuWindow;
    [SerializeField] GameObject ExitWindow;
    private bool MenuWindowOn = false;
    private bool ExitWindowOn = false;


    
    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        init();
    }

    private void init()
    {
        MenuWindow.SetActive(false);
        ExitWindow.SetActive(false);
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
