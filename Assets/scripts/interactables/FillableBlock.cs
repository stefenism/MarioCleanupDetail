using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillableBlock : InteractableObject
{
    public List<object> items {get; set;}
    public int maxCapacity = 999;
    public bool isOpen {get; set;} = false;

    public FillItem fillItem = FillItem.coin;
    public enum FillItem{
        coin = 0,
        mushroom = 1
    }

    private void Awake() {
        base.Awake();
        items = new List<object>();
    }

    private void Start() {
        GameManager.gameManager.totalBlocksToFill += maxCapacity;
    }

    public override void Interacted(){
        if(items.Count < maxCapacity){
            List<PickupObject> carried = GameManager.gameManager.player.getCarryList();
            if(carried.Count > 0){
                items.Add(carried[0]);
                if(carried[0].gameObject.TryGetComponent(out coin c)){
                    if(fillItem == FillItem.coin){
                        GameManager.gameManager.blocksFilled += 1;
                    }
                } else if(carried[0].gameObject.TryGetComponent(out coin mush)){
                    if(fillItem == FillItem.mushroom){
                        GameManager.gameManager.blocksFilled += 1;
                    }
                }
                if(items.Count == maxCapacity){
                    //Close Block animation
                    print("Block is full");
                    GameManager.gameManager.player.clearCurrentInteractableObject(this);
                    this.transform.GetChild(0).gameObject.SetActive(false);
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
