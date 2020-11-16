using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnIndicator : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Scale(TurnManager.Instance.actors.actors[0].transform.position, new Vector3(1, 0, 1)) - Vector3.up * 0.5f;
    }
}
