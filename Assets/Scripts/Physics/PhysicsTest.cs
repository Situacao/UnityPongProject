using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsTest : MonoBehaviour {

    private Rigidbody rigid;

	void Start () {

        rigid = GetComponent<Rigidbody>();
        rigid.mass = 2f;
        print(rigid.mass);

	}
	
	void Update () {

        ManageInput();

    }

    void ManageInput(){
        if (Input.GetKey(KeyCode.Space))
        {
            //rigid.AddForce(Vector3.right * 5000f * Time.deltaTime);
            rigid.AddExplosionForce(50f, transform.position, 10f);
        }
    }
}
