using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildPopup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    public void PopupOpen()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }

}