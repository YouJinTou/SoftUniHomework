using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class NewUI : MonoBehaviour
{
    public int Increment;
    public Button SliderTrigger;
    public Slider Slider;

    private bool isFilling;

    void Start()
    {
        if (this.SliderTrigger != null)
        {
            this.SliderTrigger.onClick.AddListener(() => this.ToggleFillState());
        }
    }

    void Update()
    {
        if (this.SliderTrigger == null || this.Slider == null)
        {
            return;
        }

        if (this.Slider.value >= this.Slider.maxValue)
        {
            this.Slider.value = this.Slider.minValue;
        }

        if (this.isFilling)
        {
            this.Slider.value = (this.Slider.value + this.Increment);
        }
    }

    public void ToggleFillState()
    {
        this.isFilling = !this.isFilling;
    }
}
