using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : InteractableObject
{
    public float dropDistance = 5f;
    Vector3 startPos;

    private void Awake() {
        base.Awake();

    }

    public override void Interacted(){
        Vector3 currentPos = this.transform.GetChild(1).gameObject.transform.position;
        if(dropDistance > 0f){      
            dropDistance -= 1f;
            currentPos.y += 1f;
            this.transform.GetChild(1).gameObject.transform.position = currentPos;
            //Play sounds
            audioManager.audioDaddy.playSfx(audioManager.audioDaddy.flagCrank);
            if(dropDistance == 1f){
                //Finished Play sounds
                GameManager.gameManager.flagLowered = true;
            }
        }
    }

}
