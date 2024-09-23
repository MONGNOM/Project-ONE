using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchtoScreen : MonoBehaviour, IPointerDownHandler
{
    Player player;
    Map map;

    private void Start()
    {
        map = FindAnyObjectByType<Map>();
        player = FindAnyObjectByType<Player>();    
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        map.Scroll();
        //player.Jump();
        // Player.Jump();
        Debug.Log("Player Jume");
    }
}
