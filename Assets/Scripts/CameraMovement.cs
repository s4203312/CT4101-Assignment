using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    private Vector3 cam_pos;
    [SerializeField] private float cam_speed;
    [SerializeField] private Camera cam;

    void Start() {
        cam_pos = gameObject.transform.position;
    }
    void Update() {
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
    }
}
