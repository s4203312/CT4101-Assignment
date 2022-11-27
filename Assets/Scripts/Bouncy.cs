using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncy : MonoBehaviour
{
    Collider col;
    [SerializeField] private float bounce;
    private float t;

    private IEnumerator Lerp() {
        float time = 0f;
        while (time < 1f) {
            t = EasesClass.Powers.Quadratic.InOut(time, 3);
            time += Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }

    //Making the bounciness of the ball lerp between 0.5 and 1
    void Update()
    {
        col = gameObject.GetComponent<SphereCollider>();
        col.material.bounciness = bounce;
        bounce = Mathf.Lerp(0.5f, 1, t);
        bounce = col.material.bounciness;
    }
}
