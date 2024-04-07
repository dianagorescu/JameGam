using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{
    public Transform player;
    public Text scoreText;
    float score = 0;

    // Update is called once per frame
    void Update()
    {
        score += Time.deltaTime;
        scoreText.text = Math.Floor(score).ToString();
           
        
    }
}
