using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScissorLift : PickupObject
{
    public ScissorLiftBottom bottom;
    public ScissorLiftTop top;
    public GameObject structurePrefab;
    public List<GameObject> prefabs;
    

    public override void Awake() {
        base.Awake();
        top = GetComponentInChildren<ScissorLiftTop>();
        top.parent = this;
        bottom = GetComponentInChildren<ScissorLiftBottom>();
        bottom.parent = this;
        prefabs = new List<GameObject>();
    }

    public void addStructure(){
       GameObject clone = Instantiate(structurePrefab, new Vector3(bottom.transform.position.x, bottom.transform.position.y + prefabs.Count + .5f, 0), Quaternion.identity);
       clone.transform.parent = transform;
       prefabs.Add(clone);
   }

   public override void pickupObject(playerState player, Vector3 newPosition){
       base.pickupObject(player, newPosition);
       Destroy(top.rb);
       Destroy(bottom.rb);
   }

}
