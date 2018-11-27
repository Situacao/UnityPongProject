using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUIManager : MonoBehaviour {

    [SerializeField]
    private GameObject MatchScreenGO;

    public void StartGameMethod()
    {
        MatchScreenGO.SetActive(true);
        gameObject.SetActive(false);
    }

    public void QuitGameMethod()
    {
        Application.Quit();
    }
}
