using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    [SerializeField] private Image healthGlobe, manaGlobe;
    [SerializeField] private Slider xpSlider;
    [SerializeField] private PlayerHealth health;
    [SerializeField] private TMP_Text levelText;



    public void UpdateLevelText(int level)
    {
        levelText.text = level.ToString();
    }
    
    // Update is called once per frame
    void Update()
    {
        healthGlobe.fillAmount = health.GetHealthRatio();
    }

    public void UpdateXpSlider(float xpRatio)
    {
        xpSlider.value = xpRatio;
    }
}
