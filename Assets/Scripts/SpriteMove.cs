using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteMove : MonoBehaviour
{
    public GameObject StartPoint;
    public GameObject EndPoint;
    
    float moveSpeed;
    
    public void SetupMoving(GameObject st, GameObject ed){
        StartPoint = st;
        EndPoint = ed;

        transform.position = st.transform.position;

    }

    private void Update() {
        if(StartPoint == null || EndPoint == null)
            return;
        
        moveSpeed = SpriteCreator.instance.MoveSpeed;

        transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
    }

    // Falling ball Collision this
    private void OnCollisionEnter2D(Collision2D other) {
        // Spawn an explosion at each point of contact
        foreach (ContactPoint2D missileHit in other.contacts)
        {
            Vector2 hitPoint = missileHit.point;
            Instantiate(MainSceneLogic.instance.HitEffect, new Vector3(hitPoint.x, hitPoint.y, 0), Quaternion.identity);
            MainSceneLogic.instance.mainAudioSource.PlayOneShot(MainSceneLogic.instance.HitSound);
        }
        Destroy(gameObject, 5);
    }
}
