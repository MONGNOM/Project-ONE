using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    Map map;

    public bool pointup;



    private void Awake()
    {
        map = FindAnyObjectByType<Map>();
    }
    public void SkillPointUp()
    {
        StartCoroutine(PointUp());
        Debug.Log("포인트업");
    }

    public void SkillShield()
    {
        Debug.Log("쉴드");
    }

    public void SkillMpBlock()
    {
        Debug.Log("Mp막기");
    }



    IEnumerator PointUp()
    {
        pointup = true;
        Debug.Log("포인트시작");
        yield return new WaitForSeconds(15);
        pointup = false;
        Debug.Log("포인트끝");

    }
}
