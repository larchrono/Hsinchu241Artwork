using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchController : MonoBehaviour {
	public Camera touchCamera;
	public GameObject particleTouch;
	
	public AudioClip coin;

	public GameObject prefab_TouchBallMoney;
	public GameObject prefab_Build;
	

	public bool UseDebug;

	public Text textTouchCount;
	const float touchToWorldDepth = 10;

	void EmuSendTouch(){
		string emuMessage = "";
		int touchNum = Random.Range (1, 11);
		emuMessage += touchNum;
		int _x;
		int _y;
		for (int i = 0; i < touchNum; i++) {
			_x = Random.Range (0, LogicSystem.touchScreenWidth);
			_y = Random.Range (0, LogicSystem.touchScreenHeight);
			emuMessage += "," + _x + "," + _y;

			//LogicSystem.current.CreateIcon (_x,_y);
			CreateParticleTouch (_x, _y);
		}
		if(ServerGlass.current != null)
			ServerGlass.current.SocketSend (emuMessage);
	}

	// Use this for initialization
	void Start () {
		if (Application.isEditor)
        {
            UseDebug = true;
        } else {
			UseDebug = false;
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.T)) {
			//EmuSendTouch ();
		}

		if (Input.GetMouseButtonDown (0)) {
			if (UseDebug) {
				int _x = Mathf.FloorToInt (Input.mousePosition.x);
				int _y = Mathf.FloorToInt (Input.mousePosition.y);

				CreateParticleTouch (_x, _y);
			}
		}

		if (Input.touchSupported) {
			Touch[] myTouches = Input.touches;

			textTouchCount.text = "Touch Count : " + Input.touchCount;

			int touchNum = 0;
			for (int i = 0; i < Input.touchCount; i++) {
				if (myTouches [i].phase == TouchPhase.Began) {
					touchNum++;
					int _x = Mathf.FloorToInt (myTouches [i].position.x);
					int _y = Mathf.FloorToInt (myTouches [i].position.y);

					//LogicSystem.current.CreateIcon (_x,_y);
					CreateParticleTouch (_x, _y);
				}
			}
		}
	}

	void CreateParticleTouch(float x , float y){
		Vector3 pos = touchCamera.ScreenToWorldPoint(new Vector3(x, y, touchToWorldDepth));
		Destroy (Instantiate (particleTouch, pos, Quaternion.identity), 2f);

		if(MainSceneLogic.instance.CreatorBuilding.IsFalling){
			CreateBuild(pos);
		} else {
			CreateMoney(pos);
		}
	}

	void CreateMoney(Vector3 pos){
		GameObject BallMoney = Instantiate(prefab_TouchBallMoney, pos, Quaternion.identity, MainSceneLogic.instance.CollectionMoney.transform);
		MainSceneLogic.instance.mainAudioSource.PlayOneShot(coin);
	}

	void CreateBuild(Vector3 pos){
		GameObject temp = Instantiate(prefab_Build, pos, Quaternion.identity, MainSceneLogic.instance.CollectionBuilding.transform);
        temp.GetComponent<SpriteRenderer>().color = Color.HSVToRGB(Random.Range(0, 1f), 0.4f, 1);
        Destroy(temp, 10);
	}
}
