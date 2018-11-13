using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCol : MonoBehaviour {

    private CameraShake camShake;

    [SerializeField]
    private AudioSource colAudio;

    private void Awake()
    {
        camShake = GameObject.Find("Main Camera").GetComponent<CameraShake>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        print("TIQUINHO SOARES");
        colAudio.Play();
        StartCoroutine(camShake.CameraShakeMethod(0.5f, 8f));
    }
}
