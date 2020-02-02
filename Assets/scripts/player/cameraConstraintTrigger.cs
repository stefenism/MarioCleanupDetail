using UnityEngine;
using Cinemachine;

public class cameraConstraintTrigger : MonoBehaviour {
    
    public Collider2D upperConstraint;
    public Collider2D lowerConstraint;

    public CinemachineConfiner confiner;

    public void changeBoundingVolume(){
        print("triggered");
        confiner.InvalidatePathCache();
        if(confiner.m_BoundingShape2D == upperConstraint){
            confiner.m_BoundingShape2D = lowerConstraint;
        } 
        else if(confiner.m_BoundingShape2D == lowerConstraint){
            confiner.m_BoundingShape2D = upperConstraint;
        }
    }

    public void checkIfBelowTrigger(Vector3 playerPosition){
        if(playerPosition.y < transform.position.y){
            confiner.m_BoundingShape2D = lowerConstraint;
        }
    }
}