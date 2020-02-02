using UnityEngine;

public class letter : InteractableObject {
    
    public string letterText;

    public override bool Interacted(){
        GameManager.gameManager.screenText.startTypeWriter(letterText);
        return true;
    }
}