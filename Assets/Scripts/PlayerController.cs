using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;



public class PlayerController : MonoBehaviour
{
    private MovementComponent movementComp;
    private CameraController cameraController;

    void Start()
    {
        GameObject playerCharacterObj = GameObject.FindGameObjectWithTag("Player");
        if(playerCharacterObj == null)
        {
            Debug.Log("Player object not found");
            return;
        }

        movementComp = playerCharacterObj.GetComponent<MovementComponent>();
        if(movementComp == null)
        {
            Debug.Log("Player movement component not found");
            return;
        }

        cameraController = playerCharacterObj.GetComponent<CameraController>();
    }

    void Update()
    {
        movementComp.RequestMoveForward(Input.GetAxis("Vertical"));
        movementComp.RequestMoveRight(Input.GetAxis("Horizontal"));
        if (Input.GetButton("Jump")) { movementComp.RequestJump(); }

        if (Input.GetButton("Restart")) { SceneManager.LoadScene(SceneManager.GetActiveScene().name); }

        //cameraController.RotateHorizontal(Input.GetAxis("Mouse X"));
    }

}
