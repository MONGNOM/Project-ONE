using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HpMonster : MonoBehaviour
{
   
    public Image idle;
    public Sprite idleImage;
    public Sprite attack;
    public Image hpImage;
    public Image mpImage;
    public GameOverPage overPage;
    public float mp;
    public Skill skill;

    private float monsterHp;

    public float MonsterHp { get { return monsterHp; } private set { monsterHp = value; changeHp?.Invoke(monsterHp);  } }

    public delegate void ChangeMonsterHp(float hp);
    
    ChangeMonsterHp changeHp;


    private float attackTime = 1;
    private float attackDamage = 1;


    // Start is called before the first frame update
    void Start()
    {
        mp = 0.05f;
        overPage = FindObjectOfType<GameOverPage>();
        skill = FindObjectOfType<Skill>();
        changeHp += HpString;
        monsterHp = 0;
        hpImage.fillAmount = monsterHp;
        StartCoroutine(MoveHpMonster());
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Bullet>())
        {
            Bullet bullet = collision.GetComponent<Bullet>();
            TakeHit(bullet.damage);
            
        }
    }

    public void Attack()
    {
        if (skill.shield)
        {
            StartCoroutine(ImageChage());
            skill.shield = false;
            mpImage.fillAmount = 0;
            StartCoroutine(MoveHpMonster());
        }
        else
        {
            idle.sprite = attack;
            Time.timeScale = 0;
            overPage.PageOnStart();
        }
    }

    IEnumerator ImageChage()
    {
        idle.sprite = attack;
        yield return new WaitForSeconds(1);
        idle.sprite = idleImage;
    }

    public void HpString(float hp)
    {
        hpImage.fillAmount = hp;
    }

    IEnumerator MoveHpMonster()
    {
        while (mpImage.fillAmount < 1)
        {
            yield return new WaitForSeconds(attackTime);
            MpCharge(mp);
        }

        Attack();
        Debug.Log("АјАн");
       
    }

    public void MpCharge(float mp)
    {
        mpImage.fillAmount += mp;
    }

    private void TakeHit(float damage)
    {
        MonsterHp -= damage;
    }



}
