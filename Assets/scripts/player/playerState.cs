using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class playerState : MonoBehaviour {
    
    private enum PlayerState{
        DEFAULT,
        CARRYING,
        INTERACTING
    }

    private List<PickupObject> carriedPickups = new List<PickupObject>();
    public PickupObject currentPotentialPickup = null;

    public Transform carryPosition;

    private void Start() {
        GameManager.gameManager.player = this;
        carryPosition = transform.GetChild(0);
    }

    public void addPickup(PickupObject newPickup){
        if(!carriedPickups.Contains(newPickup)){
            carriedPickups.Add(newPickup);
        }
    }

    public void pickup(PickupObject newPickup){
        float yOffset = newPickup.getColliderHeight();
        print("yoffset is: " + yOffset);
        foreach(PickupObject obj in carriedPickups){
            print("obj.name in moving up: " + obj.gameObject.name);
            Vector3 newPosition = obj.gameObject.transform.position;
            newPosition.y += yOffset;
            obj.transform.position = newPosition;
        }
        addPickup(newPickup);
        newPickup.nullifyGravity();
        newPickup.transform.position = carryPosition.position;
        newPickup.transform.parent = this.transform;
    }

    public void setCurrentPotentialPickup(PickupObject newPickup){
        if(currentPotentialPickup == null){
            currentPotentialPickup = newPickup;
        }
    }

    public void clearCurrentPotentialPickup(PickupObject oldPickup){
        if(currentPotentialPickup != null){
            currentPotentialPickup = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if(collider.transform.parent.gameObject.TryGetComponent(out PickupObject pickupObject)){
            setCurrentPotentialPickup(pickupObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collider) {
        if(collider.transform.parent.gameObject.TryGetComponent(out PickupObject pickupObject)){
            clearCurrentPotentialPickup(pickupObject);
        }
    }
}