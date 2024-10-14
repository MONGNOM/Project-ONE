using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    public float damage;
    // 총알은 오브젝트 풀링으로 관리 해야할듯

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
        // 처음에 이미지랑 이미지로 어떻게 충돌 구별할지 체크해봤는데 밑에 콜라이더를 추가하고 했더니 가능해졌따 
        if (collision.gameObject.GetComponent<HpMonster>())
        {
            Destroy(gameObject);
        }
    }
}
