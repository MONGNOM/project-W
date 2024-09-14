using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JellyOpenSystem : MonoBehaviour
{
   
    public JellyOpenSystem unlockOpen;
    public Jelatin jelatin;
    // Start is called before the first frame update
    void Start()
    {
        jelatin = FindAnyObjectByType<Jelatin>();
        gameObject.SetActive(false);
    }


    public void Unlock()
    {

        if (jelatin.GetJelatin < DataManager.instance.JellyDatas[UIManager.instance.Page].Jelatin)
        {
            jelatin.NeedJelatin();
            return;
        }

        DataManager.instance.JellyDatas[UIManager.instance.Page].UnLockJelly = true;
    }

    public void Open()
    {
        //if (!unlockOpen.isActiveAndEnabled)
        //{
        //    Debug.Log("1");
        //    gameObject.SetActive(!gameObject.activeSelf);
        //}
        //else
        //    gameObject.SetActive(false);


    }
}
