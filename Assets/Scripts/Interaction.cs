using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Interaction : MonoBehaviour {
    [SerializeField] private CanvasGroup panel;
    private TextMeshProUGUI objectText;

    private string the_lerp;
    private bool lerping;
    public Camera cam;

    private void Start() {
        if (panel != null) {
            objectText = panel.gameObject.GetComponentInChildren<TextMeshProUGUI>();
        }
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {
                Debug.DrawLine(ray.origin, hit.point, Color.red);
                if (hit.transform.CompareTag("MoveObject")) {
                    if (hit.transform.TryGetComponent(out MoveObject moveobject)) {
                        moveobject.StartLerp();
                        StartCoroutine(RevealPanel());
                        the_lerp = hit.transform.GetComponentInParent<MoveObject>().which_lerp;
                        lerping = hit.transform.GetComponentInParent<MoveObject>().is_lerping;
                        objectText.text = "Name: " + hit.transform.name + "\nEasing: " + the_lerp + "\nReturns: " + (lerping == true ? "True" : "False");
                    }
                }
                else if (hit.transform.CompareTag("Firework")) {
                    if(hit.transform.TryGetComponent(out MoveObject firework)) {
                        firework.StartFirework();
                        //new WaitForSeconds(1f);
                        cam = Camera.FindObjectOfType<Camera>();
                        if (cam != null) {
                            if (cam.transform.TryGetComponent(out CameraMovement camshake)) {
                                camshake.ShakeCamera();
                            }
                        }
                    }
                }
            }
        }
    }

    private IEnumerator RevealPanel() {
        float time = 0;
        while (time <= 1) {
            panel.alpha = EasesClass.Powers.Quadratic.In(time, 1);
            time += Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }

    //Junlge audio
    //https://freesound.org/people/VABsounds/sounds/381384/
}

