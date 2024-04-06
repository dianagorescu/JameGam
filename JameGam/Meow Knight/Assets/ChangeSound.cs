using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ChangeSound : MonoBehaviour
{
    private Sprite SoundOnimage;
    public Sprite SoundOffimage;
    public Button button;
    public AudioSource audioSource;
    public Image offImage;

    // Start is called before the first frame update
    void Start()
    {
        SoundOnimage = button.image.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ButtonClicked()
    {
        audioSource.mute = !audioSource.mute;
        offImage.enabled = !offImage.enabled;
    }
}
