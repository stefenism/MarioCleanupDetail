using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour {

    public InteractableObject IObject = null;
    private Collider2D collider;
    private Rigidbody2D rb;

    public virtual void Awake() {
        collider = GetComponent<Collider2D>();
        rb = transform.parent.GetComponent<Rigidbody2D>();
    }

    public virtual void Interacted() {
    }

    public float getColliderHeight(){
        float ySize = collider.bounds.extents.y + transform.position.y;
        return ySize;
    }

    public void nullifyGravity(){
        rb.gravityScale = 0;
    }

    public void addGravity(){
        rb.gravityScale = 1;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.Collider2D.tryGetComponent(out playerControls player)){
            Debug.Log("Player hit");
        }
    }

}