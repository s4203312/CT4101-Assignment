using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Interaction : MonoBehaviour {
    [SerializeField] private CanvasGroup panel;
    private TextMeshProUGUI objectText;
    private void Start() {
        if (panel != null) {
            objectText = panel.gameObject.GetComponentInChildren<TextMeshProUGUI>();
        }
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)) {
            Debug.DrawLine(ray.origin, hit.point, Color.red);
            if (hit.transform.TryGetComponent( out MoveObject mo)){
                mo.StartLerp();
                StartCoroutine(RevealPanel());
                //objectText.text = "Name: " + hit.transform.name + "\nEasing = " + mo.e + "\nReturns? = " + (mo.b == true ? "True" : "False");     //mo.e and mo.b are place holders for the info on ease and return
            }
        }
        else
        {
            StartCoroutine(HidePanel());
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
