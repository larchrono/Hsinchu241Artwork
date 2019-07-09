using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteCreator : MonoBehaviour
{
    public static SpriteCreator instance;
    public List<Sprite> allSprites;


    public Material iconMat;
    public GameObject StartPoint;
    public GameObject EndPoint;
    public float MoveSpeed;

    public float timeRepeat = 2;

    int spriteId = 0;

    private void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpriteCreate());
    }

    IEnumerator SpriteCreate(){
        while(true){
            yield return new WaitForSeconds(timeRepeat);
            Sprite randomSprite = allSprites[Random.Range(0, allSprites.Count)];
            GameObject ins = new GameObject("Sp"+spriteId);
            ins.AddComponent<SpriteRenderer>().sprite = randomSprite;
            ins.GetComponent<SpriteRenderer>().material = iconMat;
            ins.AddComponent<Rigidbody2D>().gravityScale = 0;
            ins.AddComponent<PolygonCollider2D>();
            ins.AddComponent<SpriteMove>().SetupMoving(StartPoint, EndPoint);
            ins.tag = "Icon";
            ins.transform.parent = MainSceneLogic.instance.CollectionIcon.transform;

            spriteId++;
        }
    }
}
