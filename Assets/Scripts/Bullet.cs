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
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * bulletSpeed  * Time.deltaTime);       
    }
}
