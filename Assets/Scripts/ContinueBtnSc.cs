using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueBtnSc : MonoBehaviour
{
    private PauseSc pauseScript;

    private void Start()
    {
        pauseScript = FindObjectOfType(typeof(PauseSc)) as PauseSc;
    }

    public void ContinueGame()
    {
        pauseScript.ContinueGame();
    }
}
