using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HpMonster : MonoBehaviour
{
    // ���ʹ� ���ݸ� �ް� ��� ���� �ð����� ���� ���Ѵٸ� Ÿ���� �ѹ濡 �������� ����
    // hp�� �Ѿ� �������� �����ؼ� �������� �޴½̱׷� ����

    private float monsterHp = 1000; // ������ �°� �������ִ°� ������
    private float attackTime = 1;
    private float attackDamage = 1; // Ÿ�� ü�¸��o 



    IEnumerator MoveHpMonster()
    {
        // monsterhp;    
        // �� �Լ��� ������ ���ǹ��ɰ� ���� ����ϸ� hp �� ������ �������� ����� ������� �ڵ� ��Ż��
        yield return new WaitForSeconds(attackTime);
    }

    private void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MoveHpMonster());
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("666");

        if (collision.gameObject.GetComponent<Bullet>())
        { }
            
    }


}
