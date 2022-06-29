using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChooseOrder : MonoBehaviour
{
    public Sprite image;
    public TMP_Text infoText;

    public Order orderButton;

    public string info;
    public int order;

    //public TMP_Text colorText;
    public Image colorImage;
    public Color color;

    public Image screenImage;

    private void Start()
    {
        color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
    }
    public void ChangeOrder()
    {
        colorImage.color = color;
        screenImage.sprite = image;
        infoText.text = info;
        orderButton.order = order;
    }
}
