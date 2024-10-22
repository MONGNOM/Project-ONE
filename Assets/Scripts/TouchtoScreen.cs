using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TouchtoScreen : MonoBehaviour, IPointerDownHandler
{
  
    Image image;
    Player player;
    Map map;
    HpMonster monster;

    private void Start()
    {
        player = FindAnyObjectByType<Player>();
        map = FindAnyObjectByType<Map>();
        monster = FindAnyObjectByType<HpMonster>();
        image = GetComponent<Image>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {

        if (map.blockpoint == map.blockList.Count-1)
            map.blockpoint = 0;


        SpriteRenderer spriteRenderer = map.blockList[map.blockpoint].GetComponent<SpriteRenderer>();
        if (true)//spriteRenderer.color.r == image.color.r && spriteRenderer.color.g == image.color.g && spriteRenderer.color.b == image.color.b)
        {
            map.blockpoint++;
            map.PointUp(1);
            map.Scroll();
            player.Jump();
            player.transform.position = map.blockList[map.blockpoint].transform.position;
            map.MakeBullet();
            monster.mpImage.fillAmount -= 0.01f;
        }
        else
        {
            monster.mpImage.fillAmount += 0.1f;
        }
    }
}
