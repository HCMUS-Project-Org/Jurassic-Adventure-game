using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    
    public float FollowSpeed = 2f;
    public float yOffset = 1f;
    public Transform target;


    // Cập nhật được gọi một lần trên mỗi khung hình
    void Update () {
        Vector3 newPos = new Vector3 (target.position.x, target.position.y + yOffset, transform.position.z);
        transform.position = Vector3.Slerp (transform.position, newPos, FollowSpeed * Time.deltaTime);
    }
}