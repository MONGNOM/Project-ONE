using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class HpMonster : MonoBehaviour
{
    // ���ʹ� ���ݸ� �ް� ��� ���� �ð����� ���� ���Ѵٸ� Ÿ���� �ѹ濡 �������� ����
    // hp�� �Ѿ� �������� �����ؼ� �������� �޴½̱׷� ����



    private float monsterHp = 1000; // ������ �°� �������ִ°� ������

    public float MonsterHp { get { return monsterHp; } private set { monsterHp = value; changeHp?.Invoke(monsterHp); } }
    public delegate void ChangeMonsterHp(float hp);
    ChangeMonsterHp changeHp;


    private float attackTime = 1;
    private float attackDamage = 1; // Ÿ�� ü�¸��o 

    [SerializeField]
    private Image hpImage;
    
    [SerializeField]
    private Image attackImage;



    IEnumerator MoveHpMonster()
    {
        // attackImage;    
        // �� �Լ��� ������ ���ǹ��ɰ� ���� ����ϸ� hp �� ������ �������� ����� ������� �ڵ� ��Ż��
        yield return new WaitForSeconds(attackTime);
    }

    private void TakeHit(float damage)
    {
        monsterHp -= damage;
    }

    // Start is called before the first frame update
    void Start()
    {
        monsterHp = 1000;
        StartCoroutine(MoveHpMonster());

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Bullet>())
        {
            Bullet bullet = collision.GetComponent<Bullet>();
            TakeHit(bullet.damage);
            Debug.Log(monsterHp);
        }

    }



}
