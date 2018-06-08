using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InhaleAnimation : MonoBehaviour
{
    public int framesPerImage;
    public int repeatDuration;

    public Sprite inhale1;
    public Sprite inhale2;
    public Sprite inhale3;
    public Sprite inhale4;
    public Sprite inhale5;
    public Sprite inhale6;
    public Sprite airFlow1;
    public Sprite airFlow2;
    public Sprite airFlow3;
    public Sprite airFlow4;
    public Image imgChar;
    public Image ImgAir;
    public AudioClip audio;

    private bool showAnimation = true;

    private int loop = 0;
    private int frames;
    private int waitFrames;
    private AudioSource source;


    // Use this for initialization
    void Start ()
    {
        this.gameObject.SetActive(showAnimation);
        frames = framesPerImage;
        waitFrames = repeatDuration;
        source = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update ()
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
        if (loop == frames/6)
        {
            imgChar.sprite = inhale1;
            ImgAir.enabled = false;
            Debug.Log("seq 1");
        }
        if (loop == frames / 5)
        {
            imgChar.sprite = inhale2;
            ImgAir.enabled = true;
            ImgAir.sprite = airFlow1; 
        }
        if (loop == frames / 4)
        {
            imgChar.sprite = inhale3;
            ImgAir.sprite = airFlow2;
        }
        if (loop == frames / 3)
        {
            imgChar.sprite = inhale4;
            ImgAir.sprite = airFlow3;
        }
        if (loop == frames / 2)
        {
            imgChar.sprite = inhale5;
            ImgAir.sprite = airFlow4;
        }
        if (loop == frames)
        {
            imgChar.sprite = inhale6;
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
        imgChar.sprite = inhale1;
        loop = 0;
    }
}
