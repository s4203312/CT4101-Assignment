using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    private Vector3 cam_pos;
    [SerializeField] private float cam_speed;
    [SerializeField] private Camera cam;

    void Start() {
        cam_pos = gameObject.transform.position;
    }
    void Update() {
        if (Input.GetKey(KeyCode.LeftShift)) {
            cam_speed = 6;
        }
        else {
            cam_speed = 3;
        }
        
        //Code for camera movement
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) {
            cam_pos = cam_pos + (Vector3.left * cam_speed * Time.deltaTime);
            gameObject.transform.position = cam_pos;
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) {
            cam_pos = cam_pos + (Vector3.right * cam_speed * Time.deltaTime);
            gameObject.transform.position = cam_pos;
        }
        else if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) {
            cam_pos = cam_pos + (Vector3.forward * cam_speed * Time.deltaTime);
            gameObject.transform.position = cam_pos;
        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) {
            cam_pos = cam_pos + (Vector3.back * cam_speed * Time.deltaTime);
            gameObject.transform.position = cam_pos;
        }
        
        if (Input.GetKey(KeyCode.Mouse1)) {
            //This mouse movement code was copied from the internet to help with userbillity
            //https://answers.unity.com/questions/149022/how-to-make-camera-move-with-the-mouse-cursors.html
            float mouseX = (Input.mousePosition.x / Screen.width) - 0.5f;
            float mouseY = (Input.mousePosition.y / Screen.height) - 0.5f;
            transform.localRotation = Quaternion.Euler(new Vector4(-1f * (mouseY * 180f), mouseX * 360f, transform.localRotation.z));
            //*
        }
        transform.position = cam_pos;
    }

    public void ShakeCamera() {
        StartCoroutine(CamShake());
    }
    private IEnumerator CamShake() {
        float time = 0;
        while (time <= 2f) {
            cam_pos = cam_pos + new Vector3(EasesClass.Bounce.InOut(time), 0, 0);
            time += Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
}
