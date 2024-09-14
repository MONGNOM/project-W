using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;


    [SerializeField] private int jellyCount ;
    [SerializeField] private int jellyMaxCount;

    public int JellyMaxCount { get { return jellyMaxCount; } set { jellyMaxCount = value; } }
    public int JellyCount { get { return jellyCount; } set { jellyCount = value; } }

    [SerializeField]
    private List<JellyData> jellyDatas;

    public List<JellyData> JellyDatas { get { return jellyDatas; } private set { jellyDatas = value; } }

    private void Awake()
    {
        // Singleton 패턴 구현
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // DataManager를 씬 전환 시에도 유지하고 싶을 경우
        }
        else
        {
            Destroy(gameObject);  // 기존 인스턴스가 있을 경우 중복된 인스턴스를 제거
        }
    }
    // Start is called before the first frame update
    private void Start()
    {
        jellyCount = 1;
        jellyMaxCount = 5;
    }

    public void MaxJellyCount()
    {
        jellyMaxCount++;
    }

    public void jellyCountUp()
    {
        jellyCount++;
    }

    public void jellyCountDown()
    {
        jellyCount--;
    }

    public JellyData GetJellyData(string dataName)
    {


        // 스크립터블 오브젝트의 데이터를 넘겨주는 함수
        foreach (var data in jellyDatas)
        {
            if (data.JellyName == dataName)
            { 
                return data;
            }

        }


        return null;
    }
    
}
