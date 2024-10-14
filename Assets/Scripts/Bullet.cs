using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    public float damage;
    // �Ѿ��� ������Ʈ Ǯ������ ���� �ؾ��ҵ�

    [SerializeField]
    private float bulletSpeed;

    public BoxCollider2D box;

    private void Awake()
    {
        box = GetComponent<BoxCollider2D>();   
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * bulletSpeed  * Time.deltaTime);       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ó���� �̹����� �̹����� ��� �浹 �������� üũ�غôµ� �ؿ� �ݶ��̴��� �߰��ϰ� �ߴ��� ���������� 
        if (collision.gameObject.GetComponent<HpMonster>())
        {
            Destroy(gameObject);
        }
    }
}