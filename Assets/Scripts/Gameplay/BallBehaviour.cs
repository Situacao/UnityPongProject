using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour {

    private Rigidbody2D rigid;

    void Awake ()
    {
        rigid = GetComponent<Rigidbody2D>();
	}

    private void OnEnable()
    {
        ResetBall();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.name == "")
        //if (collision.gameObject.tag == "")
        if (collision.gameObject.CompareTag("Match/Paddle"))
        {
            rigid.velocity = -rigid.velocity;
            collision.gameObject.transform.parent.GetComponent<Animator>().SetTrigger("willHit");
        }
        else if (collision.gameObject.CompareTag("Match/Goal"))
        {
            print("GOLO DO MAREGA");
            //StartCoroutine(GameObject.Find("Manager").GetComponent<PongManager>().StartBall());
            if (collision.gameObject.name == "WallRight")
            {
                GlobalVariablesManager.Instance.PointsP1++;
            }
            else
            {
                GlobalVariablesManager.Instance.PointsP2++;
            }
            print("SCORE P1: " + GlobalVariablesManager.Instance.PointsP1
                  + " P2: " + GlobalVariablesManager.Instance.PointsP2);

            PongManager auxManager = GameObject.Find("Manager").GetComponent<PongManager>();
            auxManager.ChangeState(PongManager.MatchState.ready);
            auxManager.ChangeScoreText();

        }
        else if (collision.gameObject.CompareTag("Match/Wall"))
        {
            rigid.velocity = new Vector2(rigid.velocity.x, -rigid.velocity.y);
        }
    }

    void ResetBall()
    {
        transform.position = Vector3.zero;

        Vector2 initialPush = Vector2.left * Time.deltaTime * 50000f;
        initialPush += Vector2.up * Random.Range(-1, 2) * 5000f;
        rigid.AddForce(initialPush);
    }

  


}
