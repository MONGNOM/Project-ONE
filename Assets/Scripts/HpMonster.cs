using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HpMonster : MonoBehaviour
{
    // 몬스터는 공격만 받고 어느 일정 시간동안 깨지 못한다면 타워를 한방에 깨버리는 판정
    // hp에 총알 데미지를 대입해서 데미지를 받는싱그로 진행

    public Image hpImage;
    public Image mpImage;

    private float monsterHp; // 점수에 맞게 설정해주는게 맞을듯

    public float MonsterHp { get { return monsterHp; } private set { monsterHp = value; changeHp?.Invoke(monsterHp); } }

    public delegate void ChangeMonsterHp(float hp);
    
    ChangeMonsterHp changeHp;


    private float attackTime = 1;
    private float attackDamage = 1; // 타워 체력마늨 



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
            Debug.Log("코루틴");
        }
        // attackImage;    
        // ㄴ 함수로 빼내서 조건문걸고 조건 통과하면 hp 및 데미지 변경으로 해줘야 쓸모없는 코드 안탈듯
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


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Bullet>())
        {
            Bullet bullet = collision.GetComponent<Bullet>();
            TakeHit(bullet.damage);
        }
    }



}
