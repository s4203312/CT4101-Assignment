using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MoveObject : MonoBehaviour
{
    [SerializeField] private float growth = 1f;
    private float t;
    
    [SerializeField] private Slider slider;
    [SerializeField] private CanvasGroup panel;

    public string which_lerp;
    public bool is_lerping;

    [SerializeField] TMP_Dropdown dropdown;

    public void StartLerp(){
        slider.gameObject.SetActive(true);
        StartCoroutine(Lerp());
    }

    private void Start() {
        if (panel != null) {
            slider = panel.gameObject.GetComponentInChildren<Slider>();
            slider.gameObject.SetActive(false);
        }
    }

    private IEnumerator Lerp(){
        float time = 0f;
        while (time < 1f)
        {
            if (dropdown == null)
            {
                yield return null;
            }
            if (dropdown.value == 0)
            {
                t = EasesClass.Powers.Quadratic.InOut(time);
                which_lerp = "EasesClass.Powers.Quadratic.InOut";
            }
            else if (dropdown.value == 1)
            {
                t = EasesClass.Trigonometric.Sin.Out(time);
                which_lerp = "EasesClass.Trigonometric.Sin.Out";
            }
            else if (dropdown.value == 2)
            {
                t = EasesClass.Exponential.In(time);
                which_lerp = "EasesClass.Exponential.In";
            }
            else if (dropdown.value == 3)
            {
                t = EasesClass.Elastic.Out(time);
                which_lerp = "EasesClass.Elastic.Out";
            }
            else if (dropdown.value == 4)
            {
                t = EasesClass.Bounce.InOut(time);
                which_lerp = "EasesClass.Bounce.InOut";
            }
        time += Time.deltaTime;
        yield return new WaitForSeconds(Time.deltaTime);
        }
    }
    
    void Update(){
        transform.localScale = Vector3.one * Mathf.Lerp(1, growth, t);
        float rotation = Mathf.InverseLerp(0, 1, t) * 360f;
        transform.localEulerAngles = new Vector3(rotation,0f, 0f);
        
        slider.value = Mathf.InverseLerp(0, 1, t);
        is_lerping = true;
    }
}