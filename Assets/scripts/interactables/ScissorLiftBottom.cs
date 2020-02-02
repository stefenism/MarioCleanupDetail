using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScissorLiftBottom : InteractableObject
{
        private ScissorLift parent;

        public override void Interacted(){
            parent.top.positionOffset = 0f;
            parent.top.updatePosition();
        }
}
