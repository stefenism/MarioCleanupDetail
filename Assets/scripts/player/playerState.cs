using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class playerState : MonoBehaviour {
    
    public enum PlayerState{
        DEFAULT,
        CARRYING,
        INTERACTING,
        DROPPING
    }

    public PlayerState playersState = PlayerState.DEFAULT;

    private List<PickupObject> carriedPickups = new List<PickupObject>();
    public PickupObject currentPotentialPickup = null;
    public InteractableObject currentInteractableObject = null;
    public List<PickupObject> currentPotentialPickups = new List<PickupObject>();

    public Transform carryPosition;

    private void Start() {
        GameManager.gameManager.player = this;
        carryPosition = transform.GetChild(0);
    }

    public void addPickup(PickupObject newPickup){
        if(!carriedPickups.Contains(newPickup)){
            carriedPickups.Insert(0, newPickup);
        }
    }

    public void pickup(PickupObject newPickup){
        if(playersState != PlayerState.CARRYING){
            setPlayerCarrying();
        }
        newPickup.transform.rotation = Quaternion.identity;
        float yOffset = newPickup.getColliderHeight();
        foreach(PickupObject obj in carriedPickups){
            Vector3 newPosition = obj.gameObject.transform.position;
            newPosition.y += yOffset;
            obj.transform.position = newPosition;
        }
        newPickup.pickupObject(this,carryPosition.position);
        // newPickup.setCarrier(this);
        addPickup(newPickup);
        removeCurrentPotentialPickup(newPickup);
        // newPickup.nullifyGravity();
        // newPickup.transform.position = carryPosition.position;
        // newPickup.transform.parent = this.transform;
    }

    public void setCurrentPotentialPickup(PickupObject newPickup){
        if(currentPotentialPickup == null){
            currentPotentialPickup = newPickup;
        }
    }
    public void dropTop(PickupObject newPickup){
        if(carriedPickups.Contains(newPickup)){
            int index = carriedPickups.IndexOf(newPickup);
            for(int i = carriedPickups.Count - 1; i >= index; i--){
                print("current drop name: " + carriedPickups[i].gameObject.name);
                carriedPickups[i].dropTopPickup();
                carriedPickups.Remove(carriedPickups[i]);
            }
            carriedPickups.Remove(newPickup);
        }
        setPlayerCarrying();
    }

    public void drop(){
        if(carriedPickups.Count > 0){
            PickupObject toDrop = carriedPickups[0];
            float dropDistance = toDrop.getColliderHeight();
            carriedPickups[0].dropTopPickup();
            carriedPickups.Remove(toDrop);
            setPlayerCarrying();
            foreach(PickupObject obj in carriedPickups){
                Vector3 newPosition = obj.gameObject.transform.position;
                newPosition.y -= dropDistance;
                obj.transform.position = newPosition;
            }
        }
    }

    public void addCurrentPotentialPickup(PickupObject newPickup){
        if(!currentPotentialPickups.Contains(newPickup)){
            // print("we in here: " + newPickup.gameObject.name);
            currentPotentialPickups.Insert(0,newPickup);
        }
    }

    public void setCurrentInteractableObject(InteractableObject newInteractable){
        if(currentInteractableObject == null){
            currentInteractableObject = newInteractable;
        }
    }

    public void clearCurrentInteractableObject(InteractableObject oldInteractable){
        if(currentInteractableObject != null){
            currentInteractableObject.isInteracting = false;
            currentInteractableObject = null;
        }
    }
    public void removeCurrentPotentialPickup(PickupObject oldPickup){
        if(currentPotentialPickups.Contains(oldPickup)){
            currentPotentialPickups.Remove(oldPickup);
        }
    }

    public bool isPlayerCarrying(){return playersState == PlayerState.CARRYING;}

    public void setPlayerCarrying(){playersState = PlayerState.CARRYING;}
    public void setPlayerDropping(){playersState = PlayerState.DROPPING;}

    private void OnTriggerEnter2D(Collider2D collider) {
        print("this.name: " + this.gameObject.name + " collidername: " + collider.gameObject.name);
        try{
        if(collider.transform.parent.gameObject.TryGetComponent(out PickupObject pickupObject)){
           addCurrentPotentialPickup(pickupObject);
        }
        
        if(collider.transform.parent.gameObject.TryGetComponent(out InteractableObject io)){
           setCurrentInteractableObject(io);
        }
        }catch{print("Ooops all berrys");}
    }

    private void OnTriggerExit2D(Collider2D collider) {
        try{
        if(collider.transform.parent.gameObject.TryGetComponent(out PickupObject pickupObject)){
            removeCurrentPotentialPickup(pickupObject);
        }
        if(collider.transform.parent.gameObject.TryGetComponent(out InteractableObject io)){
            clearCurrentInteractableObject(io);
        }
        }catch{print("Please ignore, nothing to see here.");}
    }

    public List<PickupObject> getCarryList(){
        return carriedPickups;
    }
}