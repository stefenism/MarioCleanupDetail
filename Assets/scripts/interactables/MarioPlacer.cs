using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioPlacer : InteractableObject
{
    // Start is called before the first frame update
    private bool isPlaced = false;

    private Animator anim;
    public bool filled = false;

    private void Start() {
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
                if(GameManager.gameManager.player.getCarryList()[0].gameObject.TryGetComponent(out Mario block)){
                    isPlaced = true;
                    print("replaced correctly");
                    GameManager.gameManager.placedMario = true;
                    GameManager.gameManager.player.clearCurrentInteractableObject(this);
                    this.transform.GetChild(0).gameObject.SetActive(false);

                    //REPLACE SPRITE HERE
                    filled = true;
                    //DO GAME END
                    GameManager.gameManager.player.endGame();
                    return true;
                }
            }
        }   
        return false;     
    }
}
