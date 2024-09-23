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

    public Image image;
    public Sprite sprite;

    TouchtoScreen touchtoScreen;
    public void Scroll()
    {
        if (block.transform.position.y <= -12)
            block.transform.position = new Vector3(block.transform.position.x, 12, block.transform.position.z);
    

      if (block2.transform.position.y <= -24)
            block2.transform.position = new Vector3(block2.transform.position.x, 0, block2.transform.position.z);

        if (touchtoScreen.Point >= 10)
            image.sprite = sprite;


        block.transform.position += Vector3.down * scrollPower;
        block2.transform.position += Vector3.down * scrollPower;
    }

    void Start()
    {
        touchtoScreen = FindAnyObjectByType<TouchtoScreen>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
