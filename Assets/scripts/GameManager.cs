using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager gameManager = null;

    public playerState player = null;

    //Game completion objects
    public static int blocksReplaced { get; set; } = 0;
    public static int totalBlocksToReplace { get; set; } = 9999;
    public static int blocksFilled { get; set; } = 0;
    public static int totalBlocksToFill { get; set; } = 9999;
    public static bool flagLowered { get; set; } = false;
    public static bool placedMario { get; set; } = false;

    //IF TIME TODO
    public static int mariosCleanedUp { get; set; } = 0;
    public static int totalMariosToCleanUp { get; set; } = 999;
    public static bool placedInvisableBlock { get; set; } = false;
    public static int enimesPlaced { get; set; } = 0;
    public static int enimesToPlace { get; set; } = 999;

    //TIMER
    public static float timeRemaining { get; set; } = 500f;

    void Awake() {
        if (gameManager == null) {
            gameManager = this;
        } else if (gameManager != this) {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

    }




    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
}
