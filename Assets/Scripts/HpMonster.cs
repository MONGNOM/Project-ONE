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

    private BoxCollider2D box;


    IEnumerator MoveHpMonster()
    {
        // monsterhp;    
        // �� �Լ��� ������ ���ǹ��ɰ� ���� ����ϸ� hp �� ������ �������� ����� ������� �ڵ� ��Ż��
        yield return new WaitForSeconds(attackTime);
    }

    private void Awake()
    {
        box = gameObject.GetComponent<BoxCollider2D>();
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
        if (collision.gameObject.GetComponent<Bullet>())
            Debug.Log("666");
    }


}
