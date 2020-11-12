using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    public Text scoreValueText;
    public bool asPercentage;
    private int scoreValue;
    public int ScoreValue
    {
        get { return scoreValue; }
        set 
        {
            scoreValue = value;
            if (asPercentage)
            { scoreValueText.text = " " + scoreValue.ToString() + "%"; }
            else
            {
                scoreValueText.text = scoreValue.ToString();
            }    
        }
    }
}
