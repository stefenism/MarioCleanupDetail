using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaPlacer : InteractableObject
{
    private bool isPlaced = false;

    private Animator anim;
    public bool filled = false;

    public override void Awake(){
        base.Awake();

    }

    private void Start() {
        GameManager.gameManager.enimesToPlace += 1;
        anim = GetComponent<Animator>();
    }

    private void Update() {
        checkAnims();
    }

    void checkAnims(){
        anim.SetBool("filled", filled);
    }

   public override bool InteractedFirst(){
       if(!isPlaced){
            if(GameManager.gameManager.player.getCarryList().Count > 0){
                if(GameManager.gameManager.player.getCarryList()[0].gameObject.TryGetComponent(out Goomba block)){
                    isPlaced = true;
                    print("replaced correctly");
                    GameManager.gameManager.enimesPlaced += 1;
                    GameManager.gameManager.player.clearCurrentInteractableObject(this);
                    this.transform.GetChild(0).gameObject.SetActive(false);

                    //REPLACE SPRITE HERE
                    filled = true;
                    return true;
                }
            }
        }
        return false;
   }
}
