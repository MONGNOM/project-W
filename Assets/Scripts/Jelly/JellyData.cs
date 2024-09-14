using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "JellyData",menuName = "Make Jelly Data", order = int.MaxValue)]

public class JellyData : ScriptableObject
{
    // jelly 스크립트와 여기에 있는거 연결 시켜야함
    [SerializeField]
    private bool unlockJelly = false;
    public bool UnLockJelly { get { return unlockJelly; } set { unlockJelly = value; } }
    [SerializeField]
    private Jelly jellyPrefab;
    public Jelly JellyPrefab { get { return jellyPrefab; } }

    [SerializeField]
    private Sprite jellyImage;
    public Sprite JellyImage { get { return jellyImage; } }

    [SerializeField]
    private string jellyName;
    public string JellyName { get { return jellyName; } }

    [SerializeField]
    private int price;
    public int Price { get { return price; } }

    [SerializeField]
    private float exp;

    public float Exp { get { return exp; } }

    [SerializeField]
    private float maxExp;
    public float MaxExp { get { return maxExp; } }

    [SerializeField]
    private int jelatin;
    public int Jelatin { get { return jelatin; } }


    [SerializeField]
    private int gold;
    public int Gold { get { return gold; } }
}
