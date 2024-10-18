using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverPage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    public void GameExit()
    {
        Application.Quit();
    }

    IEnumerator PageOn()
    {
        // monster updata에 어택부분 처리를 다른곳에서 해줘야함 
        yield return new WaitForSeconds(2);
        gameObject.SetActive(true);
    }




}
