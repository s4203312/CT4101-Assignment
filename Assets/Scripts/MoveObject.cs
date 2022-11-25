using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MoveObject : MonoBehaviour {
    //Variables
    private float t;
    private float growth = 10f;

    [SerializeField] private Slider slider;
    [SerializeField] private CanvasGroup panel;

    public string which_lerp;
    public bool is_lerping;

    [SerializeField] TMP_Dropdown dropdown;

    public Vector3 old_pos;

    //Starting the lerp function
    public void StartLerp() {
        slider.gameObject.SetActive(true);
        StartCoroutine(Lerp());
    }
    //Reseting the position of cube
    public void ResetLerp() {
        Debug.Log("Moved");
        transform.position = old_pos;
    }

    private void Start() {
        if (panel != null) {
            slider = panel.gameObject.GetComponentInChildren<Slider>();
            slider.gameObject.SetActive(false);
        }
        old_pos = transform.position;
    }

    //Creating a dropdown for the lerps
    private IEnumerator Lerp() {
        float time = 0f;
        while (time < 1f) {
            if (dropdown == null) {
                yield return null;
            }
            if (dropdown.value == 0) {
                t = EasesClass.Powers.Quadratic.InOut(time, 3);
                which_lerp = "EasesClass.Powers.Quadratic.InOut";
            }
            else if (dropdown.value == 1) {
                t = EasesClass.Trigonometric.Sin.Out(time);
                which_lerp = "EasesClass.Trigonometric.Sin.Out";
            }
            else if (dropdown.value == 2) {
                t = EasesClass.Exponential.In(time);
                which_lerp = "EasesClass.Exponential.In";
            }
            else if (dropdown.value == 3) {
                t = EasesClass.Elastic.Out(time);
                which_lerp = "EasesClass.Elastic.Out";
            }
            else if (dropdown.value == 4) {
                t = EasesClass.Bounce.InOut(time);
                which_lerp = "EasesClass.Bounce.InOut";
            }
            time += Time.deltaTime;
            growth = 23f;
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
    //Performing the lerps
    void Update() {
        float position = Mathf.Lerp(0, growth, t);
        transform.position = new Vector3(position, transform.position.y, transform.position.z);

        slider.value = Mathf.InverseLerp(0, 1, t);
        is_lerping = true;
    }
}