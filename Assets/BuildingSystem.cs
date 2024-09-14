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
        Debug.Log("빌드젤리카운트: "+DataManager.instance.JellyCount);
        Debug.Log("빌드젤리Max카운트: "+DataManager.instance.JellyMaxCount);
        popGUI.text = populationGold.ToString();
        plusGUI.text = touchGold.ToString();
        jelatin = FindAnyObjectByType<Jelatin>();
        popNameGUI.text = "(1/5)"; //  소환된 수 / 최대치
        plusNameGUI.text = "("+exp+"/"+ maxexp+")"; // 클릭된수? / 최대치
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
            


        jelatin.DownJelatin(touchGold);         // 젤리차감 함수                   
        exp *= 5;                               // 터치시 젤라틴 더하기 증가  해야할것 하나의젤리만 잘됌 + 한계치 만들기
        touchGold *= 5;                         // 금액 증가
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
        

        DataManager.instance.MaxJellyCount();   // 터치시 인구수 증가  해야할것 + 젤리 인구수 제한 + 한계치 만들기
        jelatin.DownJelatin(populationGold);    // 젤리차감 함수
        populationGold *= 5;                    // 금액 증가
        popGUI.text = populationGold.ToString();
        popNameGUI.text = "("+DataManager.instance.JellyCount+"/"+DataManager.instance.JellyMaxCount+")";
    }

 
}
