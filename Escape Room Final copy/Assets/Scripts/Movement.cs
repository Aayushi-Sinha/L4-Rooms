using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CharacterController))]

public class Movement : MonoBehaviour
{
    CharacterController cc;
    Animator anim;

    [System.Serializable]
    public class AnimationStrings
    {
        public string forward = "forward";
        public string strafe = "strafe";
        public string sprint = "sprint";
    }
    
    [SerializeField] // Corrected typo here
    public AnimationStrings animStrings;

    // Define your input settings similar to your InputSystems script
    [System.Serializable]
    public class InputSettings
    {
        public string forwardInput = "Vertical";
        public string strafeInput = "Horizontal";
    }
    
    [SerializeField] // Corrected typo here
    public InputSettings input;

    // Your movement speed variable
    public float movementSpeed = 5.0f; // Adjust this speed as needed

    void Start()
    {
        cc = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float forwardInput = Input.GetAxis(input.forwardInput);
        float strafeInput = Input.GetAxis(input.strafeInput);

        // Adjust the movement speed here
        Vector3 moveDirection = new Vector3(strafeInput, 0, forwardInput).normalized;
        cc.Move(moveDirection * movementSpeed * Time.deltaTime);

        // Animation updates here...
        anim.SetFloat(animStrings.forward, forwardInput);
        anim.SetFloat(animStrings.strafe, strafeInput);
    }

    public void AnimateCharacter(float forward, float strafe)
    {
        anim.SetFloat(animStrings.forward, forward);
        anim.SetFloat(animStrings.strafe, strafe);
    }

    public void SprintCharacter(bool isSprinting)
    {
        anim.SetBool(animStrings.sprint, isSprinting);
    }
}
