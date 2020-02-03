using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenableBlock : InteractableObject {

    public bool isOpen { get; set; } = false;

    public override bool Interacted() {
        isOpen = !isOpen;
        return false;
    }
        
}
