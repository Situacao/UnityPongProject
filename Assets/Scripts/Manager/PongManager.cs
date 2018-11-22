using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PongManager : MonoBehaviour {

    // Game stuff
    [Header("    GAMEPLAY STUFF")]
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


    // UI stuff
    [Header("    UI STUFF")]
    [SerializeField]
    private TextMeshProUGUI readyText;
    [SerializeField]
    private TextMeshProUGUI p1ScoreText;
    [SerializeField]
    private TextMeshProUGUI p2ScoreText;

    void Awake()
    {
        PongBall = GameObject.Find("PongBall");
    }

    private void OnEnable()
    {
        //currentState = MatchState.ready;
        GlobalVariablesManager.Instance.PointsP1 = 0;
        GlobalVariablesManager.Instance.PointsP2 = 0;
        ChangeScoreText();
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
        readyText.gameObject.SetActive(true);
        readyText.text = "3";
        yield return new WaitForSeconds(1f);
        readyText.text = "2";
        yield return new WaitForSeconds(1f);
        readyText.text = "1";
        yield return new WaitForSeconds(1f);
        readyText.text = "GO!";
        yield return new WaitForSeconds(1f);
        ChangeState(MatchState.match);
        readyText.gameObject.SetActive(false);

    }

    public void ChangeScoreText()
    {
        p1ScoreText.text = GlobalVariablesManager.Instance.PointsP1.ToString();
        p2ScoreText.text = GlobalVariablesManager.Instance.PointsP2.ToString();
    }

}
