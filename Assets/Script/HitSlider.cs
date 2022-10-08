using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitSlider : MonoBehaviour
{
    public Slider Slider;//Slider object //using UnityEngine.UI;
    public int SliderValue;//The value of the slider
    public float SliderSpeed;//The speed of the slider
    public Image Slider_Handle;//The slider of the slider //using UnityEngine.UI;


    public Color Slider_Normal;//The normal color of the slider
    public Color Slider_On;//The color of the slider in the range of Rang

    public Color color1;
    public Color color2;

    public Image Image_Red1;        //using UnityEngine.UI;
    public Image Image_Red2;        //using UnityEngine.UI;
    public Image Image_Blue;        //using UnityEngine.UI;

    private int max;
    private int RangMax;//
    private int RangMin;//
    private int min;

    public int Style;//The type of transformation

    public bool pass;

    // Use this for initialization
    public void Start()
    {
        Style = 1;
        SliderSpeed = 1f;
        Slider.value = 1;


        #region Decision Bar_Steart

        max = 100;
        min = 0;
        RangMin = Random.Range(0, 90);
        RangMax = RangMin+10;
        



        //Color initialization
        Image_Red1.color = color1;
        Image_Red2.color = color1;

        Image_Blue.color = color2;

        Slider_Handle.color = Slider_Normal;//


        //
        Image_Red1.fillAmount = (float)max / max;
        Image_Blue.fillAmount = (float)RangMax / max;
        Image_Red2.fillAmount = (float)RangMin / max;


        #endregion


    }

    // Update is called once per frame
    public void Update()
    {
        #region slider

        if (Style == 1)
        {
            Slider.value = (Slider.value -= SliderSpeed * Time.deltaTime) * Slider.value / (Slider.value);
        }
        else if (Style == 0)
        {
            Slider.value = (Slider.value += SliderSpeed * Time.deltaTime) * Slider.value / (Slider.value);
        }


        if (Slider.value <= SliderSpeed / 10 && Style == 1)
        {
            Style = 0;
            Slider.value = 0;
        }
        else if (Slider.value >= (1 - SliderSpeed / 10) && Style == 0)
        {
            Style = 1;
            Slider.value = 1;
        }


        if (Slider.value > Image_Red2.fillAmount
            && Slider.value < Image_Blue.fillAmount)
        {
            Slider_Handle.color = Slider_On;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                pass = true;
                Debug.Log("pass");
            }
        }
        else
        {
            Slider_Handle.color = Slider_Normal;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                pass = false;
                Debug.Log("Miss");
            }
                
        }


        #endregion   
    }
}
