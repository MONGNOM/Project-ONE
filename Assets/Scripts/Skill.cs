using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    HpMonster monster;
    public bool pointup;
    public bool shield;



    private void Awake()
    {
        monster = FindAnyObjectByType<HpMonster>();
    }
    public void SkillPointUp()
    {
        StartCoroutine(PointUp());
        Debug.Log("포인트업");
    }

    public void SkillShield()
    {
        shield = true;
        Debug.Log("쉴드");
    }

    public void SkillMpBlock()
    {
        StartCoroutine(BlockMp());
        Debug.Log("Mp막기");
    }



    IEnumerator PointUp()
    {
        pointup = true;
        yield return new WaitForSeconds(10);
        pointup = false;
    }

  


    IEnumerator BlockMp()
    {
        monster.mp = 0;
        yield return new WaitForSeconds(5);
        monster.mp = 0.1f;

    }


}
