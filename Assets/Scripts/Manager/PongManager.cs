using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongManager : MonoBehaviour {

    [SerializeField]
    private PaddleMovement[] paddleMovsComp;

    private GameObject PongBall;

    [HideInInspector]
    public enum MatchState
    {
        ready = 0,
        match = 1,
        point = 2
    }
    private MatchState currentState;

    void Awake()
    {
        PongBall = GameObject.Find("PongBall");
    }

    private void OnEnable()
    {
        //currentState = MatchState.ready;
        GlobalVariablesManager.Instance.PointsP1 = 0;
        GlobalVariablesManager.Instance.PointsP2 = 0;
        ChangeState(MatchState.ready);

    }


    public void ChangeState(MatchState _newState)
    {
        currentState = _newState;
        switch (currentState)
        {
            case MatchState.ready:
                for (int i = 0; i < paddleMovsComp.Length; i++)
                {
                    paddleMovsComp[i].enabled = false;
                }
                PongBall.SetActive(false);
                StartCoroutine(StartReadyCount());
                break;
            case MatchState.match:
                for (int i = 0; i < paddleMovsComp.Length; i++)
                {
                    paddleMovsComp[i].enabled = true;
                }
                PongBall.SetActive(true);
                break;
            case MatchState.point:
                break;
        }
    }

    IEnumerator StartReadyCount()
    {
        print("3");
        yield return new WaitForSeconds(1f);
        print("2");
        yield return new WaitForSeconds(1f);
        print("1");
        yield return new WaitForSeconds(1f);
        print("FCP");
        yield return new WaitForSeconds(1f);
        ChangeState(MatchState.match);


    }

    /*public IEnumerator StartBall()
    {
        PongBall.SetActive(false);
        yield return new WaitForSeconds(3f);
        PongBall.SetActive(true);
    }*/

}
