using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioVender : Vending
{
    // Start is called before the first frame update
    private bool hasSpawned = false;

    public override bool Interacted(){
        if(!hasSpawned){
            GameObject clone = Instantiate(structurePrefab, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
            hasSpawned = true;
            GameManager.gameManager.player.clearCurrentInteractableObject(this);
            this.transform.GetChild(0).gameObject.SetActive(false);
            return true;
        }
        return false;
    }
}
