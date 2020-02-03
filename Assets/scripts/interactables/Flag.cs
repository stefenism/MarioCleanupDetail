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

    public override bool Interacted(){
        Vector3 currentPos = this.transform.GetChild(1).gameObject.transform.position;
        if(dropDistance > 0f){      
            dropDistance -= 1f;
            currentPos.y += 1f;
            this.transform.GetChild(1).gameObject.transform.position = currentPos;
            //Play sounds
            if(dropDistance == 0f){
                //Finished Play sounds
                GameManager.gameManager.flagLowered = true;
                GameManager.gameManager.player.clearCurrentInteractableObject(this);
                this.transform.GetChild(3).gameObject.SetActive(false);
            }
            return true;
        }
        return false;
    }

}
