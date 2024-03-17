using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public PlayerHealth HP;
    public Image fillImage;
    private Slider slider;
    
    
    // Start is called before the first frame update
    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {

        fillImage.enabled = true;
        if (slider.value <= slider.minValue)
        {
            fillImage.enabled = false;

        }

        // if (slider.value > slider.minValue && !fillImage.enabled) 
        // {
        //     fillImage.enabled = true;
        // }

        float fillValue = HP.currentHealth;
        if (fillValue <= slider.maxValue / 4) 
        {
            fillImage.color = Color.red;
        }
        else if (fillValue > slider.maxValue / 4) 
        {
            fillImage.color = Color.green;
        }

        slider.value = fillValue;
    }
}
