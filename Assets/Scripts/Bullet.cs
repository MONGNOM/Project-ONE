using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    public float damage;
    // 총알은 오브젝트 풀링으로 관리 해야할듯

    [SerializeField]
    private float bulletSpeed;

    public BoxCollider2D box;
    HpMonster monster;
    public Skill skill;

    private void Awake()
    {
        monster = FindAnyObjectByType<HpMonster>();
        skill = FindObjectOfType<Skill>();
        box = GetComponent<BoxCollider2D>();   
    }
    void Start()
    {
        damage = 0.004f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * bulletSpeed  * Time.deltaTime);       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<HpMonster>())
        {
           
            if (skill.pointup)
            {
                monster.mpImage.fillAmount -= 0.02f;
            }
            else
            {
                monster.mpImage.fillAmount -= 0.01f;
            }
            Destroy(gameObject);
        }
    }
}
