using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour {

    public PickupObject IObject = null;
    public static bool isPickedUp { get; set; } = false;

    public virtual void Awake() {
    }

    public virtual void Interacted() {
    }



}