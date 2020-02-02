using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScissorLiftTop : InteractableObject
{
    public float positionOffset {get; set;} = 0f;
    private ScissorLift parent;
    private bool canMoveUp = true;




   public override void Interacted(){
       positionOffset += 1f;
       updatePosition();
       print("Interacted");
   }

   public void updatePosition(){
        Vector3 newPosition = this.transform.position;
        Vector3 newPlayerPosition = GameManager.gameManager.player.transform.position;
        newPlayerPosition.y += 1f;
        newPosition.y += 1f;
        GameManager.gameManager.player.transform.position = newPlayerPosition;
        this.transform.position = newPosition;
   }
}
