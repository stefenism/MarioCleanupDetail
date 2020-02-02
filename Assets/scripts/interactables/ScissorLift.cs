using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScissorLift : PickupObject
{
    public ScissorLiftBottom bottom;
    public ScissorLiftTop top;
    private void Awake() {
        top = GetComponentInChildren<ScissorLiftTop>();
        bottom = GetComponentInChildren<ScissorLiftBottom>();
    }

    
    
}
