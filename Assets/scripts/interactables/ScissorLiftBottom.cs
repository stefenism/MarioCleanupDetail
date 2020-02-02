using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScissorLiftBottom : InteractableObject
{
        public ScissorLift parent;

        public override void Interacted(){
            parent.top.positionOffset = 0f;
            parent.top.resetPosition();
        }
}
