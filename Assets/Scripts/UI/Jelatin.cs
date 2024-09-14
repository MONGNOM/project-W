using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Jelatin : MonoBehaviour
{
    private float jelatin;
    public float GetJelatin { get { return jelatin; } private set { value = jelatin; OnChangeJelatin?.Invoke(jelatin); }  }

    public TextMeshProUGUI jelatinUI;

    public delegate void JelatinChange(float exp);
    public event JelatinChange OnChangeJelatin;

    private void Awake()
    {
        jelatinUI = GetComponent<TextMeshProUGUI>();
    }
    // Start is called before the first frame update
    void Start()
    {
        OnChangeJelatin += PlusJelatin;
        jelatinUI.text = GetJelatin.ToString();
    }


    public void DownJelatin(int needjelatin)
    {
        jelatin -= needjelatin;
    }

    public void NeedJelatin()
    {
        Debug.Log("젤라틴이 부족합니다.");
    }

    public void UnLockJelly()
    {
        if (jelatin < DataManager.instance.JellyDatas[UIManager.instance.Page].Jelatin)
        {
            NeedJelatin();
            return;
        }

        // 언락팝업 꺼주기 추가 및 언락 해제시 팝업 상태 유지
        DownJelatin(DataManager.instance.JellyDatas[UIManager.instance.Page].Jelatin);
        
        jelatinUI.text = GetJelatin.ToString();
    }

    public void PlusJelatin(float exp)
    {
        jelatin += exp;
        jelatinUI.text = GetJelatin.ToString();
    }

   
}

