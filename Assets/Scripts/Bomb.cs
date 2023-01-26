using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //check if the collision was with a blade, return if null
        Blade blade = collision.GetComponent<Blade>();

        if (!blade)
        {
            return;
        }

        gameManager.OnBombHit();

        Debug.Log("do bomb stuff");
    }
}
