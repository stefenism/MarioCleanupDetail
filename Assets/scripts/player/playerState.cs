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

    private Animator anim;
    private Rigidbody2D rb = null;

    private List<PickupObject> carriedPickups = new List<PickupObject>();
    public PickupObject currentPotentialPickup = null;
    public InteractableObject currentInteractableObject = null;
    public List<PickupObject> currentPotentialPickups = new List<PickupObject>();

    public Transform carryPosition;
    public GameObject interactIcon;

    private void Start() {
        GameManager.gameManager.player = this;
        carryPosition = transform.GetChild(0);
        interactIcon = transform.GetChild(1).gameObject;
        interactIcon.SetActive(false);
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        checkAnims();

        if(carriedPickups.Count == 0){
            playersState = PlayerState.DEFAULT;
        }
    }

    void checkAnims(){
        anim.SetBool("carrying", isPlayerCarrying());
        anim.SetFloat("speed", Mathf.Abs(rb.velocity.x));
        anim.SetFloat("vspeed", Mathf.Abs(rb.velocity.y));
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
            newPickup.highlighted = true;
        }
    }

    public void setCurrentInteractableObject(InteractableObject newInteractable){
        if(currentInteractableObject == null){
            currentInteractableObject = newInteractable;
            currentInteractableObject.isInteracting = true;
        }
    }

    public void clearCurrentInteractableObject(InteractableObject oldInteractable){
        if(currentInteractableObject != null){
            if(currentInteractableObject == oldInteractable){
                currentInteractableObject.isInteracting = false;
                currentInteractableObject = null;
            }
        }
    }
    public void removeCurrentPotentialPickup(PickupObject oldPickup){
        if(currentPotentialPickups.Contains(oldPickup)){
            currentPotentialPickups.Remove(oldPickup);
            oldPickup.highlighted = false;
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
           interactIcon.SetActive(true);
        }
        }catch{print("Ooops all berrys");}

        if(collider.gameObject.TryGetComponent(out cameraConstraintTrigger constraintTrigger)){
            constraintTrigger.changeBoundingVolume();
        }
    }

    private void OnTriggerExit2D(Collider2D collider) {
        try{
        if(collider.transform.parent.gameObject.TryGetComponent(out PickupObject pickupObject)){
            removeCurrentPotentialPickup(pickupObject);
        }
        if(collider.transform.parent.gameObject.TryGetComponent(out InteractableObject io)){
            clearCurrentInteractableObject(io);
            interactIcon.SetActive(false);
        }
        }catch{print("Please ignore, nothing to see here.");}

        if(collider.gameObject.TryGetComponent(out cameraConstraintTrigger constraintTrigger)){
            constraintTrigger.checkIfBelowTrigger(transform.position);
        }
    }

    public List<PickupObject> getCarryList(){
        return carriedPickups;
    }
}