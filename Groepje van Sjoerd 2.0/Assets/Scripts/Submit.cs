using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Submit : MonoBehaviour
{
    public TMP_Text text;
    public TMP_Text scoreText;
    public float score;
    public float time;

    public void SubmitOrder()
    {
        scoreText.text = score.ToString();
        text.text = (score - time).ToString();
    }
}
