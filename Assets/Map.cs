using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    // Start is called before the first frame update

    public void Scroll()
    {
        gameObject.transform.position = Vector3.down * 5;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
