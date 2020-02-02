using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioPlacer : InteractableObject
{
    // Start is called before the first frame update
    private bool isPlaced = false;

    public override bool InteractedFirst(){
        if(!isPlaced){
            if(GameManager.gameManager.player.getCarryList().Count > 0){
                if(GameManager.gameManager.player.getCarryList()[0].gameObject.TryGetComponent(out Mario block)){
                    isPlaced = true;
                    print("replaced correctly");
                    GameManager.gameManager.placedMario = true;
                    GameManager.gameManager.player.clearCurrentInteractableObject(this);
                    this.transform.GetChild(0).gameObject.SetActive(false);

                    //REPLACE SPRITE HERE
                    //DO GAME END

                    return true;
                }
            }
        }   
        return false;     
    }
}
