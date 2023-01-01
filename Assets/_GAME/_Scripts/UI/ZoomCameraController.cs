using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoomCameraController : MonoBehaviour {

    [SerializeField] private Camera cam;
    private Vector3 dragOrigin;

    public float zoomSize;
    public float zoomSpeed;


    void Update() {
        PanCamera();

        if (Input.mouseScrollDelta.y > 0f) 
            ZoomIn();
        else if (Input.mouseScrollDelta.y < 0f) 
            ZoomOut();
    }

    private void PanCamera() {  
        if (Input.GetMouseButtonDown(0))
            dragOrigin = cam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButton(0)) {
            Vector3 difference = dragOrigin - cam.ScreenToWorldPoint(Input.mousePosition);
            print("origin " + dragOrigin + " newPosition " + cam.ScreenToWorldPoint(Input.mousePosition) + " =difference" + difference);
            cam.transform.position += difference; 
        }        
    }

    void ZoomIn() {
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, 5f, zoomSpeed * Time.deltaTime);
    }


    void ZoomOut() {
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, zoomSize, zoomSpeed * Time.deltaTime);
    }

}