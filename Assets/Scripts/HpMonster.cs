using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HpMonster : MonoBehaviour
{
    // hp monster �������� ������� �ӵ��� �޶��� 

    private float movetime = 1;

    IEnumerator MoveHpMonster()
    {
        yield return new WaitForSeconds(movetime);
    }

    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(MoveHpMonster());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
