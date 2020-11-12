using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    UnityEvent deathEvents, winEvents;

    public LivesUI lives;

    private void Awake()
    {
        Instance = this;
    }

    #region ManaBasic Functionality
    public void Die()
    {
        deathEvents.Invoke();
    }

    public void Win()
    {
        winEvents.Invoke();
    }
    #endregion

    #region debug

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.End))
        {
            lives.Lives++;
        }

        if (Input.GetKeyDown(KeyCode.Home))
        {
            lives.Lives--;
        }
    }

    #endregion
}
