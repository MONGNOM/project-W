using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.VisionOS;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{

    public static UIManager instance;


    [SerializeField] private TextMeshProUGUI lockpage;
    [SerializeField] private TextMeshProUGUI unLockpage;   
    [SerializeField] private TextMeshProUGUI unlockJellyName;
    [SerializeField] private TextMeshProUGUI jellyJelatin;
    [SerializeField] private TextMeshProUGUI jellyGold;
    [SerializeField] private JellyOpenSystem unLockPopup;
    [SerializeField] private JellyOpenSystem lockPopup;
    [SerializeField] private Image jellyImage;
    [SerializeField] private Image unLockjellyImage;
    [SerializeField] private Gold gold;
    [SerializeField] private Jelatin jelatin;
    

    public bool checkPopup; // 언락 체크 


    // 팝업 함수로 빼어 쓰는게 맞을것 같기도
    private int page;

    // updata문에서 계속 체크하기엔 메모리 낭비가 우려되어 딜리게이트 방식을 채용하여 Page가 바뀔때만 변경 및 필요 함수를 엮어주어 코드 최적화 
    public int Page { get { return page; }   set { page = value; OnChangeUI?.Invoke(Page); }  } 
    public delegate void OnChangePage(int page);
    public event OnChangePage OnChangeUI;

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



    void Start()
    {
        jelatin = FindAnyObjectByType<Jelatin>();
       gold = FindAnyObjectByType<Gold>();
       ChangeName(Page);
       ChangeUnlcokJelatin(Page);
       ChangeUnlcokGold(Page); 
       OnChangeUI += PageText;
       OnChangeUI += ChangeImage;
       OnChangeUI += ChangeName;
       OnChangeUI += ChangeUnlcokJelatin;
       OnChangeUI += ChangeUnlcokGold;
       lockpage.text = "#" + Page.ToString(); 
       unLockpage.text = "#" + Page.ToString();
    }

    public void UpPage()
    {


        if (Page >= DataManager.instance.JellyDatas.Count - 1) { }
        // Page = 0;
        else
        {
            Page++;
            CheckUnLock();
        }
    }

    public void DownPage()
    {

        if (Page <= 0) { }
        //Page = DataManager.instance.JellyDatas.Count - 1;
        else
        {
            Page--;
            CheckUnLock();

        }
    }


    void ChangeUnlcokGold(int page)
    {
        jellyGold.text = DataManager.instance.JellyDatas[page].Price.ToString();
    }

    void ChangeUnlcokJelatin(int page)
    {
        jellyJelatin.text = DataManager.instance.JellyDatas[page].Jelatin.ToString();
       
    }


    void ChangeName(int page)
    {
        unlockJellyName.text = DataManager.instance.JellyDatas[page].JellyName;
    }

    void ChangeImage(int page)
    {
        jellyImage.sprite = DataManager.instance.JellyDatas[page].JellyImage;
        unLockjellyImage.sprite = DataManager.instance.JellyDatas[page].JellyImage;
    }


    void PageText(int page)
    {
        lockpage.text = "#" + page.ToString(); 
        unLockpage.text = "#" + page.ToString();
    }


    public void Popup()
    {
        checkPopup = !checkPopup;
    }


    public void ButtonCheckUnLock()
    {
        Debug.Log("CheckUnLock");
        // 하나라도 true상태의 슬라임 팝업에 진입시 위로 진행 되는중;
        // 하지만 난 bool값에 따라 팝업이 나뉘어 진행되어야함
        if (jelatin.GetJelatin < DataManager.instance.JellyDatas[page].Jelatin)
        {
            jelatin.NeedJelatin();
            return;
        }



        if (DataManager.instance.JellyDatas[page].UnLockJelly)
        {
            // unlockopen
            Debug.Log("unlockopen");
            lockPopup.gameObject.SetActive(false);
            unLockPopup.gameObject.SetActive(true);

        }
        else
        {
            // lockopen
            Debug.Log("lockopen");
            lockPopup.gameObject.SetActive(true);
            unLockPopup.gameObject.SetActive(false);
        }
    }




    public void CheckUnLock()
    {
        Debug.Log("CheckUnLock");
        // 하나라도 true상태의 슬라임 팝업에 진입시 위로 진행 되는중;
        // 하지만 난 bool값에 따라 팝업이 나뉘어 진행되어야함
        //if (jelatin.GetJelatin < DataManager.instance.JellyDatas[Page].Jelatin)
        //{
        //    jelatin.NeedJelatin();
        //    return;
        //}



        if (DataManager.instance.JellyDatas[page].UnLockJelly)
        {
            // unlockopen
            Debug.Log("unlockopen");
            lockPopup.gameObject.SetActive(false);
            unLockPopup.gameObject.SetActive(true);

        }
        else
        {
            // lockopen
            Debug.Log("lockopen");
            lockPopup.gameObject.SetActive(true);
            unLockPopup.gameObject.SetActive(false);
        }
    }

    public void JellyPopUpOpen()
    {

        // open  lockopen unlockopen  close lockclose unlockclose 
        // open

        if (checkPopup)
            CheckUnLock();
        else
        {
            if (lockPopup.gameObject || unLockPopup.gameObject)
            {
                Debug.Log("close");
                lockPopup.gameObject.SetActive(false);
                unLockPopup.gameObject.SetActive(false);
            }
        }

    }
}
