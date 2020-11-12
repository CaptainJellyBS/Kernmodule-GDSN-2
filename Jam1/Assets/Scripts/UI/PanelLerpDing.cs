using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelLerpDing : MonoBehaviour
{
    public void SetPanelColour()
    {
        GetComponent<Image>().color = Color.Lerp(new Color(0.7f,0,0,1), new Color(0,0.7f,0,1), GameManager.Instance.correctCode);
    }
}
