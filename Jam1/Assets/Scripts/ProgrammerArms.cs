using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgrammerArms : MonoBehaviour
{
    public float curAngle, minAngle, maxAngle, speed;

    private void Update()
    {
        if((curAngle < minAngle && speed < 0) || (curAngle > maxAngle && speed > 0))
        {
            speed *= -1;
        }

        curAngle += speed * Time.deltaTime;

        transform.rotation = Quaternion.AngleAxis(curAngle, transform.right); 
    }


}
