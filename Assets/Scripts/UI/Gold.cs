using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Gold : MonoBehaviour
{
    private int gold;
    public int HaveGold { get { return gold; } private set { value = gold; Changegold?.Invoke(HaveGold); }  }

    public delegate void ChangeGold(int gold);
    public event ChangeGold Changegold;
    public JellySpawn jellySpawn;

    public TextMeshProUGUI textMeshProUGUI;
    // Start is called before the first frame update

    private void Awake()
    {
        gold = 0;
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
        jellySpawn = FindAnyObjectByType<JellySpawn>();
    }
    void Start()
    {
        textMeshProUGUI.text = HaveGold.ToString();
        Changegold += ChangeHaveGold;
    }

    public void BuyJelly()
    {
        if (gold < DataManager.instance.JellyDatas[UIManager.instance.Page].Price)
        {
            NeedGold();
            return;
        }

        gold -= DataManager.instance.JellyDatas[UIManager.instance.Page].Price;
        textMeshProUGUI.text = HaveGold.ToString();
        jellySpawn.SpawnJelly();
    }

    public void NeedGold()
    {
        Debug.Log("골드가 부족합니다.");
    }

    public void ChangeHaveGold(int textgold)
    {
        gold += textgold;
        textMeshProUGUI.text = HaveGold.ToString();
    }

}
