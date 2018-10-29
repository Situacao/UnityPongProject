using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongManager : MonoBehaviour {

    private GameObject PongBall;

    void Awake()
    {
        PongBall = GameObject.Find("PongBall");
    }

    public IEnumerator StartBall()
    {
        PongBall.SetActive(false);
        yield return new WaitForSeconds(3f);
        PongBall.SetActive(true);
    }

}
