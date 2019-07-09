using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBuilding : MonoBehaviour
{
    public GameObject Prefab_Build;
    public GameObject GroundGlass;

    public GameObject ConvertEffect;
    public int maxNumToCreate = 20;

    float remainTime;

    // Update is called once per frame
    void Update()
    {

        if(MainSceneLogic.instance.CollectionMoney.transform.childCount > maxNumToCreate && !IsFalling){
            foreach (Transform item in MainSceneLogic.instance.CollectionMoney.transform)
            {
                GameObject temp = Instantiate(Prefab_Build, item.transform.position, Quaternion.identity, MainSceneLogic.instance.CollectionBuilding.transform);
                temp.GetComponent<SpriteRenderer>().color = Color.HSVToRGB(Random.Range(0, 1f), 0.4f, 1);
                if(Random.Range(0,100) < 50)
                    Instantiate(ConvertEffect, item.transform.position, Quaternion.identity);
                if(Random.Range(0,100) < 5)
                    MainSceneLogic.instance.mainAudioSource.PlayOneShot(MainSceneLogic.instance.MorphSound);
                Destroy(temp, 10);
                Destroy(item.gameObject);
            }

            GroundGlass.GetComponent<BoxCollider2D>().isTrigger = true;
            remainTime = 5;
        }

        remainTime -= Time.deltaTime;

        if(remainTime < 0){
            GroundGlass.GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }

    public bool IsFalling {
        get { return GroundGlass.GetComponent<BoxCollider2D>().isTrigger; }
    }
}
