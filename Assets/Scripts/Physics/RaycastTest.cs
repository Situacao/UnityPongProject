using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastTest : MonoBehaviour
{
    
    [SerializeField]
    private float distanceParashoot;
    private Rigidbody rigid;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void Update ()
    {
        Ray testRay = new Ray(transform.position, Vector3.down);
        RaycastHit hit;
        Physics.Raycast(testRay, out hit, distanceParashoot);
        Debug.DrawRay(transform.position,
                      Vector3.down * distanceParashoot,
                      new Color(0f, 0f, 1f),
                      5f
                     );

        if (hit.collider != null)
        {
            rigid.mass = 0.0005f;
            rigid.drag = 5f;
        }
    }
}
