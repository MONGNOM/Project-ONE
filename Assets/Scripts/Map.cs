using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Map : MonoBehaviour
{
    // Start is called before the first frame update

    public Image towerImage;
    public GameObject bullet;
    public GameObject bulletCanvas;


    private int point;
    public int Point { get { return point; } set { point = value; textPointDeleatgae?.Invoke(point); } }

    public int blockpoint = 0;

    [SerializeField]
    GameObject block;

    [SerializeField]
    GameObject block2;

    public int scrollPower;

    public float blockscrollPower;

    public GameObject backGroundImage;

    public Image image1;
    public Image image2;
    public Image image3;
    public Image fillImage;
    

    public Sprite sprite;
    TouchtoScreen touchtoScreen;
    SpriteRenderer spriteRenderer;

    public List<GameObject> blockList;
    public List<Color> colors = new List<Color>();
    public TextMeshProUGUI textpoint;
    public Image skillbar;
    public Slider hpFillImage;


    public delegate void TextMeshProUGUIDelegate(int textpoint);
    TextMeshProUGUIDelegate textPointDeleatgae;

   
    public bool gameOver;

    public void MakeBullet()
    { 
        Instantiate(bullet, bulletCanvas.transform);
    }

    public void UseSkil()
    {

        if (skillbar.fillAmount < 1)
            return;

        skillbar.fillAmount = 0;
        Debug.Log("스킬을 사용함");
    }


    public void PointUp(int pt)
    {
        Point += pt;
        TextPoint(Point);
    }



    public void Scroll()
    {
        StartCoroutine(BackGround());

        
        if (!(skillbar.fillAmount >= 1))
            skillbar.fillAmount += 0.02f;

        if (block.transform.position.y <= -12)
            block.transform.position = new Vector3(block.transform.position.x, 12, block.transform.position.z);
    

      if (block2.transform.position.y <= -24)
            block2.transform.position = new Vector3(block2.transform.position.x, 0, block2.transform.position.z);

        block.transform.position += Vector3.down * scrollPower;
        block2.transform.position += Vector3.down * scrollPower;
        backGroundImage.transform.position += Vector3.down * blockscrollPower;

        //textPointDeleatgae += TextPoint; 2칸부터 표시가되어 주석처리

    }

    private void TextPoint(int point)
    {
        textpoint.text = point.ToString();
    }

    IEnumerator BackGround()
    {
            yield return new WaitForSeconds(0.3f);
            image1.color = new Color(image1.color.r,image1.color.g,image1.color.b,   0.5f);
            image2.color = new Color(image2.color.r, image2.color.g, image2.color.b, 0.5f);
            image3.color = new Color(image3.color.r, image3.color.g, image3.color.b, 0.5f);
            yield return new WaitForSeconds(0.3f);
            image1.color = new Color(image1.color.r, image1.color.g, image1.color.b,0);
            image2.color = new Color(image2.color.r, image2.color.g, image2.color.b,0);
            image3.color = new Color(image3.color.r, image3.color.g, image3.color.b,0);
    }


    void Start()
    {
        
        gameOver = true;
        skillbar.fillAmount = 0;
        touchtoScreen = FindAnyObjectByType<TouchtoScreen>();
        colors.Add(Color.red);
        colors.Add(Color.blue);
        colors.Add(Color.green);
        StartCoroutine(BackGround());
        //StartCoroutine(HpDown()); // hp

        for (int i = 0; i < blockList.Count; i++)
        {
            int rand = UnityEngine.Random.Range(0, 3);
            spriteRenderer = blockList[i].transform.GetComponent<SpriteRenderer>();
            spriteRenderer.color = colors[rand];
            Debug.Log(rand);
        }
    }



   
}
