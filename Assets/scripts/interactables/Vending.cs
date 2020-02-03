using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vending : InteractableObject
{
public GameObject structurePrefab;

public override bool Interacted(){
    GameObject clone = Instantiate(structurePrefab, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
    return true;
}


}
