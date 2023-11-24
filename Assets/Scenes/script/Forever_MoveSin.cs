using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forever_MoveSin : MonoBehaviour
{

    public float speedX = 1;
    public float speedY = 0;
    public float speedZ = 0;
    public float second = 1;

    float time = 0f;



    // Update is called once per frame
    private void FixedUpdate()
    {
        time += Time.deltaTime;
        float s = Mathf.Sin(time * 3.14f / second);
        this.transform.Translate(speedX * s / 50, speedY * s / 50, speedZ * s / 50);

    }
}