using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeIncreaser : MonoBehaviour
{
    public float increaseAmount = 0.1f;
    private float timer = 0;


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 1f)
        {
            timer = 0;
            transform.localScale += new Vector3(increaseAmount, increaseAmount, increaseAmount);
        }
        
    }
}
