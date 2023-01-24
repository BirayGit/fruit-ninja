using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{

    private Rigidbody2D bladeRB;

    // Start is called before the first frame update
    void Awake()
    {
        bladeRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        SetBladeToMouse();
    }

    //Gets the mouse position of the player according to the main camera. Moves the rigidbody of the blade to this mouse position.
    private void SetBladeToMouse()
    {
        var mousePos = Input.mousePosition;
        //Since the game is 2d and mouse position is a vector 3 we need to set the z manually. z=10 since our camera is at z= -10
        mousePos.z = 10;

        bladeRB.position = Camera.main.ScreenToWorldPoint(mousePos);
    }
}
