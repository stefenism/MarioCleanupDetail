using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScissorLiftBottom : InteractableObject
{
        public ScissorLift parent;

        private Animator anim;
        public bool highlighted;

        public override void Awake() {
            base.Awake();
            anim = GetComponent<Animator>();
        }

        private void Update() {
            checkAnims();
        }

        void checkAnims(){
            anim.SetBool("highlighted", highlighted);
        }

        public override bool Interacted(){
            parent.top.positionOffset = 0f;
            parent.top.resetPosition();
            audioManager.audioDaddy.playSfx(audioManager.audioDaddy.scissorDown);
            return true;
        }
}
