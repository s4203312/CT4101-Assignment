using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Interaction : MonoBehaviour {
    //Variables
    [SerializeField] private CanvasGroup panel;
    private TextMeshProUGUI objectText;

    private string the_lerp;
    private bool lerping;
    public Camera cam;

    private void Start() {
        if (panel != null) {
            objectText = panel.gameObject.GetComponentInChildren<TextMeshProUGUI>();        //Finding the textbox
        }
    }

    //Performing a ray cast
    void Update() {
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {
                Debug.DrawLine(ray.origin, hit.point, Color.red);
                if (hit.transform.CompareTag("MoveObject")) {                           //Only interacting with moveobject
                    if (hit.transform.TryGetComponent(out MoveObject moveobject)) {
                        moveobject.StartLerp();                                         //Starting the lerp
                        StartCoroutine(RevealPanel());
                        the_lerp = hit.transform.GetComponentInParent<MoveObject>().which_lerp; //Finding out which lerp is happening 
                        lerping = hit.transform.GetComponentInParent<MoveObject>().is_lerping;  //Finding wether it is currently lerping
                        //Creating a text box with information about the lerp
                        objectText.text = "Name: " + hit.transform.name + "\nEasing: " + the_lerp + "\nReturns: " + (lerping == true ? "True" : "False");
                    }
                }
            }
        }
    }

    private IEnumerator RevealPanel() {     //Lerping the panel into existence
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

