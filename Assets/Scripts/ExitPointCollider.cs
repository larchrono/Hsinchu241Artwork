using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPointCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log(other.gameObject.tag);
        if(other.tag == "Icon"){
            Destroy(other.gameObject, 5);
        }
    }
}
