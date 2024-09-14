using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.EventSystems;

public class SellJelly : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool possibleSell;
    
    void Start()
    {
        possibleSell = false;
    }



    public void OnPointerExit(PointerEventData eventData)
    {
        possibleSell = false;   
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        possibleSell = true;
    }
}
