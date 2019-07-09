using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideQuitButton : MonoBehaviour
{

    public int quitNum;

    public float remain;

    public void AddQuitNum(){
        quitNum++;
        remain = 1.5f;
    }

    void Update()
    {
        if(quitNum > 15){
            Application.Quit();
        }

        if(remain <= 0){
            quitNum = 0;
        }

        if(remain > 0)
            remain -= Time.deltaTime;
    }
}
