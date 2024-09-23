using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchtoScreen : MonoBehaviour, IPointerDownHandler
{
    private int point;

    public int Point { get { return point; } private set { point = value; } }
    
    Map map;

    private void Start()
    {
        map = FindAnyObjectByType<Map>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        point++;
        map.Scroll();
    }
}
