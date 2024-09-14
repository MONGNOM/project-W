using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuildingSystem : MonoBehaviour
{
    public TextMeshProUGUI popGUI;
    public TextMeshProUGUI plusGUI;

    public TextMeshProUGUI popNameGUI;
    public TextMeshProUGUI plusNameGUI;


    public int populationGold;
    public int touchGold;
    public int exp = 10;
    public int maxexp = 250;

    public Jelatin jelatin;
    
    void Start()
    {
        Debug.Log("��������ī��Ʈ: "+DataManager.instance.JellyCount);
        Debug.Log("��������Maxī��Ʈ: "+DataManager.instance.JellyMaxCount);
        popGUI.text = populationGold.ToString();
        plusGUI.text = touchGold.ToString();
        jelatin = FindAnyObjectByType<Jelatin>();
        popNameGUI.text = "(1/5)"; //  ��ȯ�� �� / �ִ�ġ
        plusNameGUI.text = "("+exp+"/"+ maxexp+")"; // Ŭ���ȼ�? / �ִ�ġ
    }


    public void UpgradeTouch()
    {
        if (jelatin.GetJelatin < touchGold)
        {
            jelatin.NeedJelatin();
            return;
        }

        if (exp >= maxexp)
        {
            plusGUI.text = "Max Level";
            return;
        }
            


        jelatin.DownJelatin(touchGold);         // �������� �Լ�                   
        exp *= 5;                               // ��ġ�� ����ƾ ���ϱ� ����  �ؾ��Ұ� �ϳ��������� �߉� + �Ѱ�ġ �����
        touchGold *= 5;                         // �ݾ� ����
        plusGUI.text = touchGold.ToString();
        plusNameGUI.text = "("+exp+"/"+maxexp+")";
    }

    public void UpgradePopulation()
    {
        if (jelatin.GetJelatin < populationGold)
        {
            jelatin.NeedJelatin();
            return;
        }

        if (DataManager.instance.JellyMaxCount >= 10)
        {
            popGUI.text = "Max Level";
            return;
        }
        

        DataManager.instance.MaxJellyCount();   // ��ġ�� �α��� ����  �ؾ��Ұ� + ���� �α��� ���� + �Ѱ�ġ �����
        jelatin.DownJelatin(populationGold);    // �������� �Լ�
        populationGold *= 5;                    // �ݾ� ����
        popGUI.text = populationGold.ToString();
        popNameGUI.text = "("+DataManager.instance.JellyCount+"/"+DataManager.instance.JellyMaxCount+")";
    }

 
}
