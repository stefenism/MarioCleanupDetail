using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioVender : Vending
{
    // Start is called before the first frame update
    private bool hasSpawned = false;

    public override void Interacted(){
        if(!hasSpawned){
            GameObject clone = Instantiate(structurePrefab, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
            hasSpawned = true;
        }
    }
}
