using UnityEngine;
using UnityEngine.UI;

public class SoundOFF_ON : MonoBehaviour
{
    public Image imageButton;
    public Sprite imageOFF;
    public Sprite imageON;

    public AudioSource audioSource_1;
    public AudioSource audioSource_2;
    public AudioSource audioSource_3;
    public AudioSource audioSource_4;
    public AudioSource audioSource_5;
    public AudioSource audioSource_6;
    public AudioSource audioSource_7;

    public void SoundOffON()
    {
        audioSource_1.enabled = !audioSource_1.enabled;
        audioSource_2.enabled = !audioSource_2.enabled;
        audioSource_3.enabled = !audioSource_3.enabled;
        audioSource_4.enabled = !audioSource_4.enabled;
        audioSource_5.enabled = !audioSource_5.enabled;
        audioSource_6.enabled = !audioSource_6.enabled;
        audioSource_7.enabled = !audioSource_7.enabled;

        if(audioSource_1.enabled == true)
        {
            imageButton.sprite = imageON;
        }
        else
        {
            imageButton.sprite = imageOFF;
        }
    }
}
