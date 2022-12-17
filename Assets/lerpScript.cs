using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lerpScript : MonoBehaviour
{
    float lerpTime = 2f;
    float currentLerpTime;

    Vector3 startPos;
    Vector3 endPos;

    bool started = false;

    protected void Start()
    {
        startPos = transform.position;
    }

    void InitializeFinalPosition(Vector3 v)
    {   // you can't use start. But this is just as good.

        endPos = v;
        started = true;

    }

    protected void Update()
    {

        if (started)
        {
            //increment timer once per frame
            currentLerpTime += Time.deltaTime;
            if (currentLerpTime > lerpTime)
            {
                currentLerpTime = lerpTime;
            }

            //lerp!
            float perc = currentLerpTime / lerpTime;
            transform.position = Vector3.Lerp(startPos, endPos, perc);
            if(transform.position == endPos)
            {
                Destroy(gameObject);
            }
        }
    }
}
