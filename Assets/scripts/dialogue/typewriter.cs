using UnityEngine;
using TMPro;

public class typewriter : MonoBehaviour {
    
    private TextMeshProUGUI typeWriter;

    private void Awake() {
        typeWriter = GetComponent<TextMeshProUGUI>();
        GameManager.setTypewriter(this);
    }
}