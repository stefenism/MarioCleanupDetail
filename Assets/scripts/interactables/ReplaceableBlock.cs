using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaceableBlock : InteractableObject
{
    // Start is called before the first frame update
    private bool isReplaced = false;

    public override void Awake() {
        base.Awake(); 
    }

    private void Start() {
         GameManager.gameManager.totalBlocksToReplace++;
    }

    public override void InteractedFirst(){
        if(!isReplaced){
            if(GameManager.gameManager.player.getCarryList().Count > 0){
                if(GameManager.gameManager.player.getCarryList()[0].gameObject.TryGetComponent(out ReplaceBlock block)){
                    isReplaced = true;
                    print("replaced correctly");
                    GameManager.gameManager.blocksReplaced += 1;
                    GameManager.gameManager.player.clearCurrentInteractableObject(this);
                    this.transform.GetChild(0).gameObject.SetActive(false);

                    //REPLACE SPRITE HERE

                    
                }
            }
        }
    }
}
