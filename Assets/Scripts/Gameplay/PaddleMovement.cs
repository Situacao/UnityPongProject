using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour {

    [SerializeField]
    private float movSpeed;

    [SerializeField]
    private string InputAxis;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        ManageInput();
	}

    void ManageInput()
    {
        float movDir = Input.GetAxis(InputAxis);
        if (movDir != 0f)
        {
            Vector3 newPos = transform.position + Vector3.up * movSpeed * movDir * Time.deltaTime;
            transform.position = new Vector3(newPos.x, Mathf.Clamp(newPos.y, -20f, 20f), newPos.z);
        }
    }
}
