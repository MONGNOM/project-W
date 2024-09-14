using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class Jelly : MonoBehaviour
{


    [SerializeField]
    private string characterName; 

    public JellyData data;
    Animator animator;
    SpriteRenderer spriteRenderer;

    public float moveSpeedx;
    public float moveSpeedy;
    public float exp;
    public float currentexp;
    public int level;

    public List<Vector3> point = new List<Vector3>();
    public Vector3 right;
    public Vector3 center;
    public Vector3 left;

    public BuildingSystem system;

    public RuntimeAnimatorController[] levcontroller;

    public GameObject leftTop;
    public GameObject rightBottom;
    public SellJelly selljelly;
    public Gold gold;
    public Jelatin jelatin;

    public int jellyExp;

    int pointRandom;

    bool backHome;

    private void Awake()
    {
        leftTop = GameObject.Find("LeftTop");
        rightBottom = GameObject.Find("RightBottom");

        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // 데이터매니저에서 데이터 불러오는 함수 만들고 start에서 실행

    // Start is called before the first frame update
    public void Start()
    {
        jellyExp = 10;
        system = FindAnyObjectByType<BuildingSystem>();
        selljelly = FindAnyObjectByType<SellJelly>();
        gold = FindAnyObjectByType<Gold>();
        jelatin = FindAnyObjectByType<Jelatin>();
        data = DataManager.instance.GetJellyData(characterName);
        StartCoroutine("JellyMove");
        StartCoroutine("JellyExpUp");
        point.Add(right);
        point.Add(center);
        point.Add(left);
        exp = 0;
        currentexp = data.MaxExp;
        level = 1;
        data.UnLockJelly = false;
    }

    private void Update()
    {
        if (transform.position.x < leftTop.transform.position.x || transform.position.y > leftTop.transform.position.y || transform.position.x > rightBottom.transform.position.x || transform.position.y < rightBottom.transform.position.y)
        {
            pointRandom = Random.Range(0, 2);
            backHome = true;

            Vector3 pos = new Vector3((transform.position.x - point[pointRandom].x), (transform.position.y - point[pointRandom].y), (transform.position.z - point[pointRandom].z)).normalized;

            float x = pos.x;
            float y = pos.y;
            
            transform.position = Vector3.MoveTowards(transform.position, point[pointRandom], 0.01f);
        }
        else
        {
            if (animator.GetBool("isWalk"))
            {
                transform.Translate(new Vector3(moveSpeedx, moveSpeedy, moveSpeedy) * Time.deltaTime);
                backHome = false;

            }
            
        }

        if (level == 1 && exp >= currentexp)
        {
            LevelUp();
            ChangeAC(animator, 2);
        }
        else if (level == 2 && exp >= currentexp)
        {
            LevelUp();
            ChangeAC(animator, 3);
        }
    }

    void LevelUp()
    {
        currentexp *= 1.5f;
        level++;
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z) * 1.5f;
        exp = 0;
    }

    IEnumerator JellyExpUp()
    {
        while (true)
        {
            jelatin.PlusJelatin(data.Exp);
            exp += data.Exp;
            yield return new WaitForSeconds(1);
        }
    }

    IEnumerator JellyMove()
    {
        //해금할때 젤라틴 골드 차감 및 bool값을 통해 해금 됐을때 팝업 변경 해줘야함
        while (true)
        {
          
            yield return new WaitForSeconds(3.5f);
            moveSpeedx = Random.Range(-0.8f, 0.8f);
            moveSpeedy = Random.Range(-0.8f, 0.8f);
            if (moveSpeedx < 0)
                spriteRenderer.flipX = true;
            else
                spriteRenderer.flipX = false;

            animator.SetBool("isWalk", true);
            yield return new WaitForSeconds(2.5f);
            animator.SetBool("isWalk", false);
        }
    }

    public void ChangeAC(Animator animator, int level)
    {
        animator.runtimeAnimatorController = levcontroller[level - 1];
    }

    

    private void OnMouseDown()
    {
        jelatin.PlusJelatin(system.exp);
        exp += 10;
        animator.SetTrigger("doTouch");
        animator.SetBool("isWalk", false);
    }

    private void OnMouseDrag()
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        gameObject.transform.position = pos;
    }

    private void OnMouseUp()
    {
        if (selljelly.possibleSell) 
        {
            Destroy(gameObject);
            DataManager.instance.jellyCountDown();
            gold.ChangeHaveGold(data.Gold);
        }
    }


}
