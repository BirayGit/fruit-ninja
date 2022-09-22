using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public GameObject slicedFruitPrefab;
    [SerializeField]
    private float explosionRadius = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateSlicedFruit();
        }
    }

    //Instantiates sliced version of the fruit at the position of the GameObject(uncut version) and destroys the GameObject.
    public void CreateSlicedFruit()
    {
        GameObject inst = Instantiate(slicedFruitPrefab, transform.position, transform.rotation);
        Rigidbody[] rbSliced = inst.transform.GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody rb in rbSliced)
        {
            rb.transform.rotation = Random.rotation;
            rb.AddExplosionForce(Random.Range(500, 1000), transform.position, explosionRadius);
        }


        Destroy(gameObject);
    }

    public void OnCutDestructionFX()
    {
        

        
    }
}
