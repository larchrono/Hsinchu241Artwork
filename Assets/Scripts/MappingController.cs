using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MappingController : MonoBehaviour
{
    public RawImage rawImage1;

    public float moveFactor = 0.1f;
    public float scaleFactor = 0.1f;

    RectTransform rt1;

    void Start()
    {
        rt1 = rawImage1.GetComponent<RectTransform>();

        float _x = PlayerPrefs.GetFloat("r1_pos_x", 0);
        float _y = PlayerPrefs.GetFloat("r1_pos_y", 0);
        float _rot_x = PlayerPrefs.GetFloat("r1_rot_x", 0);
        float _rot_z = PlayerPrefs.GetFloat("r1_rot_z", 0);
        float _s_x = PlayerPrefs.GetFloat("r1_scale_x", 1);
        float _s_y = PlayerPrefs.GetFloat("r1_scale_y", 1);

        rt1.anchoredPosition = new Vector2(_x, _y);
        rt1.rotation = Quaternion.Euler(_rot_x, 0, _rot_z);
        rt1.localScale = new Vector3(_s_x, _s_y, 1);

        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Insert)){
            moveFactor += 0.1f;
        }
        if(Input.GetKeyDown(KeyCode.Delete)){
            moveFactor -= 0.1f;
        }
        if(Input.GetKey(KeyCode.W)){
            rt1.anchoredPosition = rt1.anchoredPosition + new Vector2(0, moveFactor);
            SaveWarpParam();
        }
        if(Input.GetKey(KeyCode.S)){
            rt1.anchoredPosition = rt1.anchoredPosition + new Vector2(0, -moveFactor);
            SaveWarpParam();
        }
        if(Input.GetKey(KeyCode.A)){
            rt1.anchoredPosition = rt1.anchoredPosition + new Vector2(-moveFactor, 0);
            SaveWarpParam();
        }
        if(Input.GetKey(KeyCode.D)){
            rt1.anchoredPosition = rt1.anchoredPosition + new Vector2(moveFactor, 0);
            SaveWarpParam();
        }
        if(Input.GetKey(KeyCode.Q)){
            rt1.Rotate(new Vector3(0, 0, moveFactor),Space.Self);
            SaveWarpParam();
        }
        if(Input.GetKey(KeyCode.E)){
            rt1.Rotate(new Vector3(0, 0, -moveFactor),Space.Self);
            SaveWarpParam();
        }
        if(Input.GetKey(KeyCode.R)){
            rt1.Rotate(new Vector3(-moveFactor, 0, 0),Space.Self);
            SaveWarpParam();
        }
        if(Input.GetKey(KeyCode.T)){
            rt1.Rotate(new Vector3(moveFactor, 0, 0),Space.Self);
            SaveWarpParam();
        }
        if(Input.GetKey(KeyCode.Z)){
            rt1.localScale = rt1.localScale + new Vector3(-scaleFactor, 0, 0);
            SaveWarpParam();
        }
        if(Input.GetKey(KeyCode.X)){
            rt1.localScale = rt1.localScale + new Vector3(scaleFactor, 0, 0);
            SaveWarpParam();
        }
        if(Input.GetKey(KeyCode.C)){
            rt1.localScale = rt1.localScale + new Vector3(0, -scaleFactor, 0);
            SaveWarpParam();
        }
        if(Input.GetKey(KeyCode.V)){
            rt1.localScale = rt1.localScale + new Vector3(0, scaleFactor, 0);
            SaveWarpParam();
        }
    }

    public void SaveWarpParam(){
        PlayerPrefs.SetFloat("r1_pos_x", rt1.anchoredPosition.x);
        PlayerPrefs.SetFloat("r1_pos_y", rt1.anchoredPosition.y);
        PlayerPrefs.SetFloat("r1_rot_x", rt1.rotation.eulerAngles.x);
        PlayerPrefs.SetFloat("r1_rot_z", rt1.rotation.eulerAngles.z);
        PlayerPrefs.SetFloat("r1_scale_x", rt1.localScale.x);
        PlayerPrefs.SetFloat("r1_scale_y", rt1.localScale.y);
    }
}
