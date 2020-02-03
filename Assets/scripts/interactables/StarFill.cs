using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarFill : InteractableObject
{
    private bool isFilled = false;
    private void Start() {
        GameManager.gameManager.totalBlocksToFill++;
    }

    public override bool Interacted(){
        if(!isFilled){
            isFilled = true;
            List<PickupObject> carried = GameManager.gameManager.player.getCarryList();
            if(carried.Count > 0){
                if(carried[0].gameObject.TryGetComponent(out star st)){
                    GameManager.gameManager.blocksFilled += 1;
                    print("Block is full");
                    GameManager.gameManager.player.clearCurrentInteractableObject(this);
                    this.transform.GetChild(0).gameObject.SetActive(false);
                
                    return true;
                }    
            } 
        }
        return false;
    }

}
