using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{

    Map map;
    private void Awake()
    {
        map = FindAnyObjectByType<Map>();
    }
    public void SkillPointUp()
    {
        map.Point += 1;
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
        // ��ų ��� ����
        yield return new WaitForSeconds(15);
        // ��ų ���� ����
    }
}
