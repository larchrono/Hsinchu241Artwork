using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TriggerPassToScene : MonoBehaviour
{
    public Camera TouchCamera;
    public float Left_x = -60;
    public float Right_x = -40;

    Vector3 originPos;
    void Start(){
        originPos = TouchCamera.transform.position;

        StartCoroutine(ResetCamera());
    }
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "BallMoney"){
            float out_x = Mathf.Clamp(other.gameObject.transform.position.x, Left_x, Right_x).Map(Left_x, Right_x, 0, 1);

            //Debug.Log(out_x);
            MainSceneLogic.instance.CreateBallBuilding(out_x);
            Destroy(other.gameObject, 2);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        TouchCamera.DOShakePosition(0.25f, 0.1f);
        MainSceneLogic.instance.mainAudioSource.PlayOneShot(MainSceneLogic.instance.GroundColliSound);
    }

    IEnumerator ResetCamera(){
        while(true){
            TouchCamera.transform.DOMove(originPos, 0.5f);
            yield return new WaitForSeconds(10);
        }
    }
}
