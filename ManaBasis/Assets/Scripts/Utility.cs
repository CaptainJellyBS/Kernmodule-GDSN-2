using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "Utility", menuName = "ScriptableObjects/Utility")]
public class Utility : ScriptableObject
{
    CursorLockMode originalCursorLockState;
    #region time scale sheninigans
    public void SetTimescale(float ts)
    {
        Time.timeScale = ts;
    }

    public void PauseTime()
    {
        SetTimescale(0.0f);
    }

    public void StartTime()
    {
        SetTimescale(1.0f);
    }

    public void ToggleTime()
    {
        SetTimescale(Mathf.Abs(Time.timeScale - 1.0f));
    }
    #endregion

    #region SceneManagement

    public void SwitchScene(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }

    public void SwitchScene(Scene scene)
    {
        SwitchScene(scene.buildIndex);
    }

    public void ReloadScene()
    {
        SwitchScene(SceneManager.GetActiveScene());
    }

    public void SwitchToMainMenu()
    {
        SwitchScene(0);
    }

    #endregion

    #region Cursor Locking

    public void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void UnlockCursor()
    {
        originalCursorLockState = Cursor.lockState;
        Cursor.lockState = CursorLockMode.None;
    }

    public void ConfineCursor()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void ResetCursor()
    {
        Cursor.lockState = originalCursorLockState;
    }

    public void ToggleCursor()
    {
        if(Cursor.lockState == CursorLockMode.None) { ResetCursor(); return; }
        UnlockCursor();
    }

    #endregion

    public void QuitGame()
    {
        Application.Quit();
    }
}
