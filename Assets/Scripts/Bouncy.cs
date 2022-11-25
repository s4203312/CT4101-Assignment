using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncy : MonoBehaviour
{
    PhysicMaterial mat;
    private float t;

    //Making the bounciness of the ball lerp between 0 and 1
    void Update()
    {
        t = Time.deltaTime;
        mat = gameObject.GetComponent<SphereCollider>().GetComponent<PhysicMaterial>();
        mat.bounciness = Mathf.Lerp(0, 1, t);
    }
}
