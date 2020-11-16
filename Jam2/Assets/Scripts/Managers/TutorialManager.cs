using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TutorialManager : MonoBehaviour
{
    public UnityEvent[] TutorialEvents;

    private void Start()
    {
        StartCoroutine(Tutorial());
    }

    IEnumerator Tutorial()
    {
        TutorialEvents[0].Invoke();

        while(!(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S)|| Input.GetKey(KeyCode.D)))
        {
            yield return null;
        }
        yield return new WaitForSeconds(0.5f);
        TutorialEvents[1].Invoke();

        while(!(Player.Instance.GetComponent<GridMovement>().GridPosition.y >= 6))
        {
            yield return null;
        }

        TutorialEvents[2].Invoke();

        while (!(Input.GetKey(KeyCode.Space)))
        {
            yield return null;
        }
        yield return new WaitForSeconds(0.5f);
        TutorialEvents[3].Invoke();

        while (!(Player.Instance.GetComponent<GridMovement>().GridPosition.y >= 8))
        {
            yield return null;
        }
        TutorialEvents[4].Invoke();

        while (!(Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D)))
        {
            yield return null;
        }
        yield return new WaitForSeconds(0.5f);
        TutorialEvents[5].Invoke();

    }
}
