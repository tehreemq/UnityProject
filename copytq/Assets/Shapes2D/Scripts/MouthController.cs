using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouthController : MonoBehaviour {
    private Animator animator;
    private readonly int SAD = 1, ANGRY = 1, HAPPY = 0, SURPRISED = 2, SPEAKING = 5, IDLE = 4;
    int curentEmotion;  


    // Start is called before the first frame update
    void Start() {
        animator = GetComponent<Animator>();
        //curentEmotion = HAPPY; //just in case scenario
    }

    // Update is called once per frame
    void Update() {
    }

    //Function will be called from Java
    //Controls mouth state
    public void SetEmotion(string emotion) {
        switch (emotion) {
            case "ANGRY":
                animator.SetInteger("emotion", ANGRY);
                break;
            case "SAD":
                animator.SetInteger("emotion", SAD);
                break;
            case "HAPPY":
                animator.SetInteger("emotion", HAPPY);
                break;
            case "SURPRISED":
                animator.SetInteger("emotion", SURPRISED);
                break;
            case "IDLE":
                animator.SetInteger("emotion", IDLE);
                break;
        }
    }

    //Function will be called from Java
    //Controls speaking state
    public void SetSpeaking(string speaking) {
        
        switch (speaking) {
            case "START":
                //save previous mouth state
                if(animator.GetInteger("emotion") != SPEAKING)
                    curentEmotion = animator.GetInteger("emotion");
                //set state to sepaking
                animator.SetInteger("emotion", SPEAKING);
                break;
            case "STOP":
                //reset mouth state after done sepaking
                animator.SetInteger("emotion", curentEmotion);
                break;
        }

    }
}
