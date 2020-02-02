using UnityEngine;

public class letter : InteractableObject {
    
    public string letterText;

    public override void Interacted(){
        GameManager.gameManager.screenText.startTypeWriter(letterText);
    }
}