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
        Debug.Log("����ƾ�� �����մϴ�.");
    }

    public void UnLockJelly()
    {
        if (jelatin < DataManager.instance.JellyDatas[UIManager.instance.Page].Jelatin)
        {
            NeedJelatin();
            return;
        }

        // ����˾� ���ֱ� �߰� �� ��� ������ �˾� ���� ����
        DownJelatin(DataManager.instance.JellyDatas[UIManager.instance.Page].Jelatin);
        
        jelatinUI.text = GetJelatin.ToString();
    }

    public void PlusJelatin(float exp)
    {
        jelatin += exp;
        jelatinUI.text = GetJelatin.ToString();
    }

   
}

