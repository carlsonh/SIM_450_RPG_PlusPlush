using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
using Photon.Realtime;
using System;

public class HeaderInfo : MonoBehaviourPun
{
    public TextMeshProUGUI nameText;
    public Image[] healthBars;
    private float maxValue;
    private float healthPerBar;




    /// <summary>
    /// Health Tracking
    /// </summary>

    public void Initialize(string nickName, int maxVal)
    {
        nameText.text = nickName;
        maxValue = maxVal;
        healthPerBar = (float)maxVal / (float)healthBars.Length;

        Debug.Log("maxVal " + maxValue + "\n healthPerBar " + healthPerBar);
    }

    [PunRPC]
    void UpdateHealthBar(int value)
    {
        float _healthPercent = value / maxValue;

        for (int barIndex = 0; barIndex < healthBars.Length; barIndex++)
        {
            //Get this bar's health
            float _barFill = value - ((barIndex) * healthPerBar);
            _barFill = Mathf.Min(1, _barFill / healthPerBar);
            healthBars[barIndex].fillAmount = _barFill;
        }


        if (value <= maxValue / 4f)
        {///Characters has just gotten below quarter health
            foreach (Image bar in healthBars)
            {
                bar.color = Color.red;
            }
        }
        else if (value <= maxValue / 2f)
        {///Characters has just gotten below half health
            foreach (Image bar in healthBars)
            {
                bar.color = Color.yellow;
            }
        }
        else
        {//Player health over half
            foreach (Image bar in healthBars)
            {
                bar.color = Color.green;
            }
        }


    }
}
