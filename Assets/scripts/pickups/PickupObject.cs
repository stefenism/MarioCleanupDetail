using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour {

    public PickupObject IObject = null;

    public bool isPickedUp = false;
    public playerState player;

    public bool highlighted = false;


    private BoxCollider2D collider;
    private Rigidbody2D rb;
    private Animator anim;

    public virtual void Awake() {
        collider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    public virtual void Update() {
        checkAnims();
    }

    void checkAnims(){
        anim.SetBool("highlighted", highlighted);
    }

    public virtual void pickupObject(playerState player, Vector3 newPosition) {
        setCarrier(player);
        nullifyGravity();
        transform.position = newPosition;
        transform.parent = player.transform;
        gameObject.layer = LayerMask.NameToLayer("PickedUpColliders");
    }

    public float getColliderHeight(){
        return collider.size.y;
    }

    public void setCarrier(playerState newPlayer){
        player = newPlayer;
        isPickedUp = true;
    }

    public void removeCarrier(){
        isPickedUp = false;
        player = null;
        transform.parent = null;
    }

    public void nullifyGravity(){
        Destroy(rb);
    }

    public void addGravity(){
       rb = gameObject.AddComponent(typeof(Rigidbody2D)) as Rigidbody2D;
    }

    public virtual void dropTopPickup(){
        removeCarrier();
        addGravity();
        gameObject.layer = LayerMask.NameToLayer("PickupCollider");
    }

    public void startDropTop(){
        if(isPickedUp){
            if(player.isPlayerCarrying()){
                player.setPlayerDropping();
                player.dropTop(this);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.collider.gameObject.layer == LayerMask.NameToLayer("Ground")){
            startDropTop();
        }
    }
}