using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillableBlock : InteractableObject
{
    public List<object> items {get; set;}
    public int maxCapacity {get; set;} = 999;
    public bool isOpen {get; set;} = false;

    private void Awake() {
        base.Awake();
        items = new List<object>();
    }

    public override void Interacted(){
        if(items.Count < maxCapacity){
            List<PickupObject> carried = GameManager.gameManager.player.getCarryList();
            if(carried.Count > 0){
                items.Add(carried[0]);
                print("Put Item in Block");
                if(items.Count == maxCapacity){
                    //Close Block animation
                    print("Block is full");
                }
            }  
        }           
    }

    public override void InteractedFirst(){
        if(!isOpen){
            isOpen = true;
            print("Opened Block");
        }
    }
}
