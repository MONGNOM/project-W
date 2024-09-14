using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum JellyTyepe
{
    jelly1, jelly2, jelly3
}
public class JellySpawn : MonoBehaviour
{
    // Start is called before the first frame update

    public List<Jelly> jellyList;
    public List<JellyData> jellyDataList;
    public GameObject jellyPrefab; //  이부분을 리스트로 변경 하거나 아니면 그냥 젤리 데이터를 다 담아주고 프리팹화 시킨후 리스트하나에 다 담고 관리 ??

    void Start()
    {
        Instantiate(jellyList[0]);
    }

    public void SpawnJelly()
    {
        if (DataManager.instance.JellyCount >= DataManager.instance.JellyMaxCount)
        {
            Debug.Log("인구수가 부족합니다");   
            return;
        }
        DataManager.instance.jellyCountUp();
        Instantiate(jellyList[UIManager.instance.Page]);
    }
}
