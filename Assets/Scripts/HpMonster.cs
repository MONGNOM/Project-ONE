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
    public GameOverPage overPage;

    private float monsterHp; // ������ �°� �������ִ°� ������

    public float MonsterHp { get { return monsterHp; } private set { monsterHp = value; changeHp?.Invoke(monsterHp);  } }

    public delegate void ChangeMonsterHp(float hp);
    
    ChangeMonsterHp changeHp;


    private float attackTime = 1;
    private float attackDamage = 1; // Ÿ�� ü�¸��o 


    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        overPage = FindObjectOfType<GameOverPage>();
        changeHp += HpString;
        monsterHp = 0;
       hpImage.fillAmount = monsterHp;
       StartCoroutine(MoveHpMonster());
    }

    private void Update()
    {
        
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
        idle.sprite = attack;
        Time.timeScale = 0;
        overPage.PageOnStart();
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
            mpImage.fillAmount += 0.1f;
            Debug.Log(mpImage.fillAmount);
            Debug.Log("���̹� ä��");
        }

        Attack();
        Debug.Log("����");
        // attackImage;    
        // �� �Լ��� ������ ���ǹ��ɰ� ���� ����ϸ� hp �� ������ �������� ����� ������� �ڵ� ��Ż��
    }

    private void TakeHit(float damage)
    {
        MonsterHp -= damage;
    }



}
