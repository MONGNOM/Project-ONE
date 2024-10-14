using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HpMonster : MonoBehaviour
{
    // 몬스터는 공격만 받고 어느 일정 시간동안 깨지 못한다면 타워를 한방에 깨버리는 판정
    // hp에 총알 데미지를 대입해서 데미지를 받는싱그로 진행

    private float monsterHp = 1000; // 점수에 맞게 설정해주는게 맞을듯
    private float attackTime = 1;
    private float attackDamage = 1; // 타워 체력마늨 



    IEnumerator MoveHpMonster()
    {
        // monsterhp;    
        // ㄴ 함수로 빼내서 조건문걸고 조건 통과하면 hp 및 데미지 변경으로 해줘야 쓸모없는 코드 안탈듯
        yield return new WaitForSeconds(attackTime);
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MoveHpMonster());
    }

  

}
