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
        // Singleton ���� ����
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // DataManager�� �� ��ȯ �ÿ��� �����ϰ� ���� ���
        }
        else
        {
            Destroy(gameObject);  // ���� �ν��Ͻ��� ���� ��� �ߺ��� �ν��Ͻ��� ����
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


        // ��ũ���ͺ� ������Ʈ�� �����͸� �Ѱ��ִ� �Լ�
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
