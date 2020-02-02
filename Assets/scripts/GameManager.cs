using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager gameManager = null;

    public playerState player = null;
    public typewriter screenText = null;

    //Game completion objects
    public int blocksReplaced { get; set; } = 0;
    public int totalBlocksToReplace { get; set; } = 9999;
    public int blocksFilled { get; set; } = 0;
    public int totalBlocksToFill { get; set; } = 9999;
    public bool flagLowered { get; set; } = false;
    public bool placedMario { get; set; } = false;

    //IF TIME TODO
    public int mariosCleanedUp { get; set; } = 0;
    public int totalMariosToCleanUp { get; set; } = 999;
    public bool placedInvisableBlock { get; set; } = false;
    public int enimesPlaced { get; set; } = 0;
    public int enimesToPlace { get; set; } = 999;

    //TIMER
    public float timeRemaining { get; set; } = 500f;

    void Awake() {
        if (gameManager == null) {
            gameManager = this;
        } else if (gameManager != this) {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

    }

    static public void setTypewriter(typewriter newTypeWriter) {
        gameManager.screenText = newTypeWriter;
    }

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
}
