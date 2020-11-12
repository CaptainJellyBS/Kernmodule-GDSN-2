using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Tutorial : MonoBehaviour
{
    public Camera[] cameras;
    public GameObject[] panels;
    public GameObject[] afterPanelsText;

    public UnityEvent afterTutorial;

    int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].enabled = false;
            panels[i].SetActive(false);
        }
        StartCoroutine(TutorialC());
    }

    IEnumerator TutorialC()
    {
        cameras[0].enabled = true;
        panels[0].SetActive(true);

        yield return new WaitForSeconds(3.0f);

        for (int i = 1; i < 4; i++)
        {
            //cameras[i - 1].enabled = false;
            //cameras[i].enabled = true;
            cameras[0].transform.position = cameras[i].transform.position;
            cameras[0].transform.rotation = cameras[i].transform.rotation;

            panels[i - 1].SetActive(false);
            panels[i].SetActive(true);

            yield return new WaitForSeconds(3.0f);
        }

        panels[3].SetActive(false);
        cameras[0].enabled = false;

        afterPanelsText[0].SetActive(true);
        afterPanelsText[4].SetActive(true);
        afterPanelsText[1].SetActive(true);
        bool doCont = false;
        while(!doCont)
        {
            doCont = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D);
            yield return null;
        }
        yield return new WaitForSeconds(1.0f);
        
        doCont = false;
        afterPanelsText[1].SetActive(false);
        afterPanelsText[2].SetActive(true);
        while (!doCont)
        {
            doCont = Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.LeftShift);
            yield return null;
        }
        yield return new WaitForSeconds(1.0f);

        doCont = false;
        afterPanelsText[2].SetActive(false);
        afterPanelsText[3].SetActive(true);
        while (!doCont)
        {
            doCont = Input.GetMouseButton(0);
            yield return null;
        }
        yield return new WaitForSeconds(3.0f);
        afterTutorial.Invoke();
    }
}
