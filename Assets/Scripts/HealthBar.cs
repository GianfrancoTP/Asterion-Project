﻿using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform bar;

    private void Start()
    {
        bar = transform.Find("Bar");
    }

    // Update is called once per frame
    public void setSize(float sizeNormalized) 
    {
        bar.localScale = new Vector2(sizeNormalized, 1f);
    }
    void Update()
    {
        
    }
}
