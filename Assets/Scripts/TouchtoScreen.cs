using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchtoScreen : MonoBehaviour, IPointerDownHandler
{
    private int point;

    public int Point { get { return point; } private set { point = value; } }
    Player player;
    Map map;

    private void Start()
    {
        player = FindAnyObjectByType<Player>();
        map = FindAnyObjectByType<Map>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        point++;
        map.Scroll();
        player.Jump();
        map.gameOver = true;
    }
}
