using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HpMonster : MonoBehaviour
{
    // ���ʹ� ���ݸ� �ް� ��� ���� �ð����� ���� ���Ѵٸ� Ÿ���� �ѹ濡 �������� ����
    // hp�� �Ѿ� �������� �����ؼ� �������� �޴½̱׷� ����

    public Image hpImage;

    private float monsterHp; // ������ �°� �������ִ°� ������

    public float MonsterHp { get { return monsterHp; } private set { monsterHp = value; changeHp?.Invoke(monsterHp); } }

    public delegate void ChangeMonsterHp(float hp);
    
    ChangeMonsterHp changeHp;


    private float attackTime = 1;
    private float attackDamage = 1; // Ÿ�� ü�¸��o 



    public void HpString(float hp)
    {
        Debug.Log("HpString");
        hpImage.fillAmount = hp;
    }

    IEnumerator MoveHpMonster()
    {
        yield return new WaitForSeconds(attackTime);
        // attackImage;    
        // �� �Լ��� ������ ���ǹ��ɰ� ���� ����ϸ� hp �� ������ �������� ����� ������� �ڵ� ��Ż��
    }

    private void TakeHit(float damage)
    {
        MonsterHp -= damage;
        Debug.Log("TakeHit");
    }

    // Start is called before the first frame update
    void Start()
    {
        changeHp += HpString;
        monsterHp = 1;
       hpImage.fillAmount = monsterHp;
       StartCoroutine(MoveHpMonster());
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Bullet>())
        {
            Bullet bullet = collision.GetComponent<Bullet>();
            TakeHit(0.1f);
            Debug.Log("OnTriggerEnter2D");
            
        }
    }



}
