using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject block;

    [SerializeField]
    GameObject block2;

    [SerializeField]
    public int scrollPower;

    public Image image1;
    public Image image2;
    public Image image3;

    public Sprite sprite;
    TouchtoScreen touchtoScreen;
    SpriteRenderer spriteRenderer;

    public List<GameObject> blockList;
    public List<Color> colors = new List<Color>();
   
    public bool gameOver;
    public void Scroll()
    {
        if (block.transform.position.y <= -12)
            block.transform.position = new Vector3(block.transform.position.x, 12, block.transform.position.z);
    

      if (block2.transform.position.y <= -24)
            block2.transform.position = new Vector3(block2.transform.position.x, 0, block2.transform.position.z);

     

        block.transform.position += Vector3.down * scrollPower;
        block2.transform.position += Vector3.down * scrollPower;

        for (int i = 0; i < blockList.Count; i++)
        {
            spriteRenderer = blockList[i].transform.GetComponent<SpriteRenderer>();
            int rand = Random.Range(0, 3);
            spriteRenderer.color = colors[rand];
            Debug.Log(rand);
        }
        
    }

    IEnumerator BackGround()
    {
        while (gameOver)
        {
            yield return new WaitForSeconds(2);
            image1.color = new Color(image1.color.r,image1.color.g,image1.color.b,0.5f);
            image2.color = new Color(image2.color.r, image2.color.g, image2.color.b, 0.5f);
            image3.color = new Color(image3.color.r, image3.color.g, image3.color.b, 0.5f);
            yield return new WaitForSeconds(0.3f);
            image1.color = new Color(image1.color.r, image1.color.g, image1.color.b,0);
            image2.color = new Color(image2.color.r, image2.color.g, image2.color.b,0);
            image3.color = new Color(image3.color.r, image3.color.g, image3.color.b,0);
        }
    }


    void Start()
    {
        gameOver = true;
        touchtoScreen = FindAnyObjectByType<TouchtoScreen>();
        colors.Add(Color.red);
        colors.Add(Color.blue);
        colors.Add(Color.green);
        StartCoroutine(BackGround());
    }



    // Update is called once per frame
    void Update()
    {
    }
}
