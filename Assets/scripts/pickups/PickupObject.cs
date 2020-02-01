using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour {

    public PickupObject IObject = null;
    public static bool isPickedUp { get; set; } = false;

    private Collider2D collider;
    private Rigidbody2D rb;

    public virtual void Awake() {
        collider = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    public virtual void Interacted() {
    }

    public float getColliderHeight(){
        float ySize = collider.bounds.extents.y * 2;
        print("collider bounds: " + collider.bounds.extents.y);
        print("ysize in get collider height: " + ySize);
        return ySize;
    }

    public void nullifyGravity(){
        rb.gravityScale = 0;
        rb.simulated = false;
    }

    public void addGravity(){
        rb.gravityScale = 1;
        rb.simulated = true;
    }



}