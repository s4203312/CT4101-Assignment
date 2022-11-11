using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveObject : MonoBehaviour
{
    [SerializeField] private float growth = 1f;
    private float t;
    [SerializeField] private Slider slider;
    
    //Public function to call lerp from a button
    public void StartLerp(){
        StartCoroutine(Lerp());
    }

    private IEnumerator Lerp(){
        float time = 0f;
        while(time < 1f){
            t = EasesClass.Powers.Quadratic.InOut(time);
            time += Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
    
    void Update(){
        transform.localScale = Vector3.one * Mathf.Lerp(1, growth, t);
        float rotation = Mathf.InverseLerp(0, 1, t) * 360f;
        transform.localEulerAngles = new Vector3(rotation,0f, 0f);
        slider.value = Mathf.InverseLerp(0, 1, t);
    }
}
