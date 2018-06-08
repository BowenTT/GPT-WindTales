using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeepBreathAnimation : MonoBehaviour
{
    public int framesPerImage;
    public int repeatDuration;

    public Sprite breath1;
    public Sprite breath2;
    public Sprite breath3;
    public Sprite breath4;
    public Sprite breath5;
    public Sprite breath6;
    public Sprite breath7;
    public Sprite breath8;
    public Sprite breath9;
    public Sprite breath10;

    public Sprite airFlow1;
    public Sprite airFlow2;
    public Sprite airFlow3;
    public Sprite airFlow4;
    public Sprite airFlow5;
    public Sprite airFlow6;
    public Sprite airFlow7;
    public Sprite airFlow8;

    public Image imgChar;
    public Image ImgAir;
    public AudioClip audio;

    private bool showAnimation = true;

    private int loop = 0;
    private int frames;
    private int waitFrames;
    private AudioSource source;


    // Use this for initialization
    void Start()
    {
        this.gameObject.SetActive(showAnimation);
        frames = framesPerImage;
        waitFrames = repeatDuration;
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (showAnimation)
        {
            startAnimation();
        }
        else
            stopAnimation();
    }

    void startAnimation()
    {
        Debug.Log("start animation");
        imgChar.enabled = true;
        if (loop == 0)
        {
            source.PlayOneShot(audio);
        }
        if (loop == frames / 10 * 1)
        {
            imgChar.sprite = breath1;
            ImgAir.enabled = false;

        }
        if (loop == frames / 10 * 2)
        {
            imgChar.sprite = breath2;
            ImgAir.enabled = true;
            ImgAir.sprite = airFlow1;
        }
        if (loop == frames / 10 * 3)
        {
            imgChar.sprite = breath3;
            ImgAir.sprite = airFlow2;
        }
        if (loop == frames / 10 * 4)
        {
            imgChar.sprite = breath4;
            ImgAir.sprite = airFlow3;
        }
        if (loop == frames / 10 * 5)
        {
            imgChar.sprite = breath5;
            ImgAir.sprite = airFlow4;
        }
        if (loop == frames / 10 * 6)
        {
            imgChar.sprite = breath6;
            ImgAir.sprite = airFlow3;
        }
        if (loop == frames / 10 * 7)
        {
            imgChar.sprite = breath7;
            ImgAir.sprite = airFlow4;
        }
        if (loop == frames / 10 * 8)
        {
            imgChar.sprite = breath8;
            ImgAir.sprite = airFlow3;
        }
        if (loop == frames / 10 * 9)
        {
            imgChar.sprite = breath9;
            ImgAir.sprite = airFlow4;

        }
        if (loop == frames)
        {
            imgChar.sprite = breath10;
            ImgAir.enabled = false;
        }
        loop++;
        if (loop >= frames + waitFrames)
        {
            loop = 0;
        }

    }

    void stopAnimation()
    {
        imgChar.enabled = false;
        ImgAir.enabled = false;
        imgChar.sprite = breath1;
        loop = 0;
    }
}
