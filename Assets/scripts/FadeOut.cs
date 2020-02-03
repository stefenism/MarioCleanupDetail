using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    public IEnumerator fade(){
        CanvasGroup cg = GetComponent<CanvasGroup>();
        while (cg.alpha < 1){
            cg.alpha += .05f;
            yield return null;
        }
        yield return null;
    }
}
