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
        // 스킬 사용 상태
        yield return new WaitForSeconds(15);
        // 스킬 끝난 상태
    }
}
