using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class audioManager : MonoBehaviour {

    public static audioManager audioDaddy = null;

    public AudioSource cameraAudioSource = null;

    public AudioClip jumpSfx;
    public AudioClip typeWriterSfx;

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
            cameraAudioSource.PlayOneShot(playClip, 0.5f);
        }
    }
    
}