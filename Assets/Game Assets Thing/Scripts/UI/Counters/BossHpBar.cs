using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BossHpBar : MonoBehaviour
{
    public Slider slider;
    public Image fill;

    public TextMeshProUGUI bossHp;

    public void FillBar()
    {
        slider.maxValue = FindObjectOfType<BossHealth>().maxHp;
        slider.value = slider.maxValue;
        bossHp.text = $"{(slider.value / slider.maxValue) * 100}%";
    }

    private void OnEnable()
    {
        Invoke(nameof(FillBar), 0.1f);
    }

    private void FixedUpdate()
    {
        if (slider.value > 0)
        {
            slider.value = FindObjectOfType<BossHealth>().currentHp;
            bossHp.text = $"{(slider.value / slider.maxValue) * 100}%";
        }
    }
}
