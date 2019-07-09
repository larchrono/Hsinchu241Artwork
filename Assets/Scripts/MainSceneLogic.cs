using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneLogic : MonoBehaviour
{
    public static MainSceneLogic instance;
    public Camera SceneCamera;
    public GameObject TouchBall_Building;

    public GameObject CollectionMoney;
    public GameObject CollectionBuilding;
    public GameObject CollectionIcon;
    

    public CreateBuilding CreatorBuilding;

    public GameObject HitEffect;
    public AudioClip HitSound;
    public AudioClip MorphSound;
    public AudioClip GroundColliSound;

    public AudioSource mainAudioSource;




    public int width;
    public int height;

    public float mouse_x;
    public float mouse_y;

    private void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        width = Display.displays[0].systemWidth;
        height = Display.displays[0].systemHeight;

        mouse_x = Input.mousePosition.x;
        mouse_y = Input.mousePosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        //Get Scene Width and Height
        width = Display.displays[0].systemWidth;
        height = Display.displays[0].systemHeight;

        //Mouse x,y 's max value is Width , Height
        mouse_x = Input.mousePosition.x;
        mouse_y = Input.mousePosition.y;
    }


    public void CreateBallBuilding(float enter_x){
        //Enter_x Range is 0~1
        Vector3 pos = SceneCamera.ScreenToWorldPoint(new Vector3(enter_x * width, height, 10));
        GameObject temp = Instantiate(TouchBall_Building, pos, Quaternion.identity);
        Destroy(temp, 5f);
    }
}
