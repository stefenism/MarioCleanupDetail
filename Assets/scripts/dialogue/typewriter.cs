using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class typewriter : MonoBehaviour {
    
    public TextMeshProUGUI typeWriter;

    public float textSpeed = 0.005f;
    public float refreshDelay = .75f;
    public int maxTextCount = 40;
    public string fullText = "";
    private string currentText = "";

    private void Awake() {
        typeWriter = GetComponent<TextMeshProUGUI>();
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.H)){
            startTypeWriter("here I am, rock you like a hurricane");
        }
    }

    private void Start() {
        GameManager.setTypewriter(this);
    }

    public void startTypeWriter(string newText){
        fullText = newText;
        StartCoroutine(showText());
    }

    IEnumerator showText() {
        string newString = fullText;
        int j = 0;
        for(int i = 0; i <= fullText.Length; i++){
            currentText = newString.Substring(0, j);
            typeWriter.SetText(currentText);
            audioManager.audioDaddy.playSfx(audioManager.audioDaddy.typeWriterSfx);
            if(j >= maxTextCount){
                j = 0;
                yield return new WaitForSeconds(refreshDelay);
                newString = fullText.Substring(i, (fullText.Length - 1) - i);
                currentText = "";
                typeWriter.SetText(currentText);
            }
            j++;
            yield return new WaitForSeconds(textSpeed);
        }
        yield return new WaitForSeconds(refreshDelay);
        fullText = "";
        typeWriter.SetText(fullText);
    }
}