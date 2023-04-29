using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region Look
    public Vector2 GetLook()
    {
        //Vector2 inputVector = playerInputActions.Player.Look.ReadValue<Vector2>();
        Vector2 inputVector = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        Debug.Log(inputVector);
        return inputVector;
    }
    #endregion
}
