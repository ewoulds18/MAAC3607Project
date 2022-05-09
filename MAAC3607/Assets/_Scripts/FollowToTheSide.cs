using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowToTheSide : MonoBehaviour{
    public Transform target;
    public Vector3 offset;

    // Update is called once per frame
    void FixedUpdate(){
        transform.rotation = Quaternion.Euler(0,target.transform.eulerAngles.y,0);
        Matrix4x4 m = Matrix4x4.TRS(target.transform.position,transform.rotation, target.transform.localScale);
        transform.position = m.MultiplyPoint(offset);

        transform.eulerAngles = new Vector3(0, target.eulerAngles.y, 0);
    }
}
