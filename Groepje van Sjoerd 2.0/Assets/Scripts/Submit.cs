using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Submit : MonoBehaviour
{
    public TMP_Text text;
    public float score;
    public float time;

    public void SubmitOrder()
    {
        text.text = (score - time).ToString();
    }
}
