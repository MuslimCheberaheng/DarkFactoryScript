using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSlider : MonoBehaviour
{
    public AudioSource BackgroundSound;
    public void Sli_manual(Slider SliderName)
    {
        BackgroundSound.GetComponent<AudioSource>().volume = SliderName.value;
    }
}
