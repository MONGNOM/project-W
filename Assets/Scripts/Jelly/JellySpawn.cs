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
    public GameObject jellyPrefab; //  �̺κ��� ����Ʈ�� ���� �ϰų� �ƴϸ� �׳� ���� �����͸� �� ����ְ� ������ȭ ��Ų�� ����Ʈ�ϳ��� �� ��� ���� ??

    void Start()
    {
        Instantiate(jellyList[0]);
    }

    public void SpawnJelly()
    {
        if (DataManager.instance.JellyCount >= DataManager.instance.JellyMaxCount)
        {
            Debug.Log("�α����� �����մϴ�");   
            return;
        }
        DataManager.instance.jellyCountUp();
        Instantiate(jellyList[UIManager.instance.Page]);
    }
}
