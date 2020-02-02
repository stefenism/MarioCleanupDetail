using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScissorLiftTop : InteractableObject
{
    public float positionOffset {get; set;} = 0f;
    public ScissorLift parent;
    private bool canMoveUp = true;

    private Vector3 startPos;


     public override void Awake() {
        base.Awake();
        startPos = this.transform.position;  
    }

   public override void Interacted(){
       positionOffset += 1f;
       updatePosition();
   }

   public void updatePosition(){
        Vector3 newPosition = this.transform.position;
        Vector3 oldPos = newPosition;
        Vector3 newPlayerPosition = GameManager.gameManager.player.transform.position;
        newPlayerPosition.y += 1f;
        newPosition.y += 1f;
        GameManager.gameManager.player.transform.position = newPlayerPosition;
        this.transform.position = newPosition;
        
        parent.addStructure();

   }

   public void resetPosition(){
       transform.parent.rotation = Quaternion.identity;
       transform.localPosition = Vector3.zero;
        foreach (GameObject go in parent.prefabs){
            Destroy(go);
        }
        parent.prefabs.Clear();
   }

   


}
