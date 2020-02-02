using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaPlacer : MonoBehaviour
{
    private bool isPlaced = false;

    public override void Awake(){
        base.Awake();
        GameManager.gameManager.enimesToPlace += 1;
    }

   public override void Interacted(){
       if(!isPlaced){
            if(GameManager.gameManager.player.getCarryList().Count > 0){
                if(GameManager.gameManager.player.getCarryList()[0].gameObject.TryGetComponent(out Goomba block)){
                    isPlaced = true;
                    print("replaced correctly");
                    GameManager.gameManager.enimesPlaced += 1;
                    GameManager.gameManager.player.clearCurrentInteractableObject(this);
                    this.transform.GetChild(0).gameObject.SetActive(false);

                    //REPLACE SPRITE HERE
                }
            }
        }
   }
}
