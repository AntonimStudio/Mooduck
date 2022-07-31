using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseAndContinuation : MonoBehaviour
{

    public void Pause()
    {
        Time.timeScale = 0f;
    }

    public void Continuation()
    {
        Time.timeScale = 1f;
    }
}
