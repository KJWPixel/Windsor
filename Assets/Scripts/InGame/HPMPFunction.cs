using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   

public class HPMPFunction : MonoBehaviour
{
    [SerializeField] Image imgHp;//HpMask 
    [SerializeField] Image imgEffect;//HpEffectMask

    [SerializeField, Range(0.1f, 10f)] float effectTime = 1;
    GameManager gameManager;

    bool isEnded = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetHp(float _maxHp, float _curHp)//0~1
    {
        imgHp.fillAmount = _curHp / _maxHp;
    }
}
