using System.Collections;
using System.Collections.Generic;
using System.Security;
using Unity.VisualScripting;
using UnityEngine;

public class FireWork : MonoBehaviour
{
    //Variables
    private Vector3 cam_pos;
    private float t;
    private float cam_t;
    private float growth = 10f;
    public GameObject[] firework;
    [SerializeField] private GameObject particals;
    [SerializeField] private AudioClip explode;
    AudioSource speaker;

    void Start() {
        cam_pos = gameObject.transform.position;
        speaker = gameObject.GetComponent<AudioSource>();
    }
    
    //Starting firework function
    public void StartFirework() {
        StartCoroutine(Firework());
    }

    private IEnumerator Firework() {
        float time = 0f;
        while (time < 1f) {                         //Looping the t variable with the ease to create the lerp
            t = EasesClass.Powers.Quintic.In(time);
            time += Time.deltaTime;
            growth = 100f;                          //Setting the growth to be large to imitate a firework
            yield return new WaitForSeconds(Time.deltaTime);
        }
        GameObject[] firework = GameObject.FindGameObjectsWithTag("Firework");
        foreach (GameObject fire in firework) {
            Object.Destroy(fire);
            speaker.Play();                     //Playing explosion sound
            if (particals != null) {
                GameObject clone = Instantiate(particals, fire.transform.position, fire.transform.rotation);        //Creating paricals
                Destroy(clone, 1f);
                StartCoroutine(CamShake());     //Starting a camera shake
            }
        }
    }

    void Update() {
        GameObject[] firework = GameObject.FindGameObjectsWithTag("Firework");              //Performing the lerp
        foreach (GameObject fire in firework) {
            float position = Mathf.Lerp(0, growth, t);
            fire.transform.position = new Vector3(fire.transform.position.x, position, fire.transform.position.z);
        }
        //This doesnt really work as i intended it too.
        if(cam_t != 0) {                                                                    //Camera lerp for shake
            float position = Mathf.PingPong(Mathf.InverseLerp(0, 1, t),1);
            gameObject.transform.position = cam_pos + new Vector3(position, cam_pos.y, cam_pos.z);
        }
    }
    private IEnumerator CamShake() {        //Lerping the camera to shake
        float time = 0;
        while (time <= 1f) {
            cam_t = EasesClass.Bounce.InOut(time);
            time += Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
}
