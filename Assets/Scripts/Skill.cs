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
        Debug.Log("����Ʈ��");
    }

    public void SkillShield()
    {
        Debug.Log("����");
    }

    public void SkillMpBlock()
    {
        Debug.Log("Mp����");
    }



    IEnumerator PointUp()
    {
        pointup = true;
        Debug.Log("����Ʈ����");
        yield return new WaitForSeconds(15);
        pointup = false;
        Debug.Log("����Ʈ��");

    }
}
