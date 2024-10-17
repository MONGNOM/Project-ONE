using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HpMonster : MonoBehaviour
{
    // ���ʹ� ���ݸ� �ް� ��� ���� �ð����� ���� ���Ѵٸ� Ÿ���� �ѹ濡 �������� ����
    // hp�� �Ѿ� �������� �����ؼ� �������� �޴½̱׷� ����
    public Image idle;
    public Sprite attack;
    public Image hpImage;
    public Image mpImage;
    public UnityEvent pageon;

    private float monsterHp; // ������ �°� �������ִ°� ������

    public float MonsterHp { get { return monsterHp; } private set { monsterHp = value; changeHp?.Invoke(monsterHp);  } }

    public delegate void ChangeMonsterHp(float hp);
    
    ChangeMonsterHp changeHp;


    private float attackTime = 1;
    private float attackDamage = 1; // Ÿ�� ü�¸��o 

    public void Attack()
    {
        idle.sprite = attack;
        Time.timeScale = 0;
        pageon?.Invoke();
    }

    public void HpString(float hp)
    {
        hpImage.fillAmount = hp;
    }

    IEnumerator MoveHpMonster()
    {
        while (mpImage.fillAmount <= 1)
        {
            yield return new WaitForSeconds(attackTime);
            mpImage.fillAmount += 0.01f;
        }
        // attackImage;    
        // �� �Լ��� ������ ���ǹ��ɰ� ���� ����ϸ� hp �� ������ �������� ����� ������� �ڵ� ��Ż��
    }

    private void TakeHit(float damage)
    {
        MonsterHp -= damage;
    }

    // Start is called before the first frame update
    void Start()
    {
        changeHp += HpString;
        monsterHp = 1;
       hpImage.fillAmount = monsterHp;
       StartCoroutine(MoveHpMonster());
    }

    private void Update()
    {
        if (mpImage.fillAmount >= 1) 
        { Attack(); }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Bullet>())
        {
            Bullet bullet = collision.GetComponent<Bullet>();
            TakeHit(bullet.damage);
            
        }
    }



}
