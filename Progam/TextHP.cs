﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextHP : MonoBehaviour
{
    [SerializeField]
    public static int HealthCurrent;
    public int HealthMax;
    private Image healthBar;
    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Image>();
        HealthCurrent = HealthMax;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = (float)HealthCurrent / (float)HealthMax;
    }
}
