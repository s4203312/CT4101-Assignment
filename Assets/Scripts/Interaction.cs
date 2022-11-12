using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Interaction : MonoBehaviour {
    [SerializeField] private CanvasGroup panel;
    private TextMeshProUGUI objectText;

    private string the_lerp;
    private bool lerping;

    private void Start() {
        if (panel != null) {
            objectText = panel.gameObject.GetComponentInChildren<TextMeshProUGUI>();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {
                Debug.DrawLine(ray.origin, hit.point, Color.red);
                if (hit.transform.TryGetComponent(out MoveObject mo)) {
                    mo.StartLerp();
                    StartCoroutine(RevealPanel());
                    the_lerp = hit.transform.GetComponentInParent<MoveObject>().which_lerp;
                    lerping = hit.transform.GetComponentInParent<MoveObject>().is_lerping;
                    objectText.text = "Name: " + hit.transform.name + "\nEasing = " + the_lerp + "\nReturns? = " + (lerping == true ? "True" : "False");
                }
            }
            else {
                StartCoroutine(HidePanel());
            }
        }
    }

    private IEnumerator RevealPanel(){
        float time = 0;
        while (time <= 1)
        {
            panel.alpha = EasesClass.Powers.Quadratic.In(time);
            time += Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
    private IEnumerator HidePanel(){
        float time = 0;
        while (time <= 1)
        {
            panel.alpha = 1- EasesClass.Powers.Quadratic.Out(time);
            time += Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
}
