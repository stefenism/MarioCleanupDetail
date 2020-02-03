using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class audioManager : MonoBehaviour {

    public static audioManager audioDaddy = null;

    public AudioSource cameraAudioSource = null;

    public AudioClip jumpSfx;
    public AudioClip typeWriterSfx;
    public AudioClip coinDeposit;
    public AudioClip flagCrank;
    public AudioClip boxFix;
    public AudioClip levelComplete;
    public AudioClip pickupSfx;
    public AudioClip putDownSfx;
    public AudioClip shroomStarDeposited;
    public AudioClip clumsyDropSfx;
    public AudioClip scissorUp;
    public AudioClip scissorDown;
    public AudioClip clockOut;

    private void Awake() {
        if(audioDaddy == null){
            audioDaddy = this;
        } else if(audioDaddy != this){
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void playSfx(AudioClip playClip){
        print("Playing");
        if(playClip != null){
            cameraAudioSource.PlayOneShot(playClip, 0.35f);
        }
    }
    
}