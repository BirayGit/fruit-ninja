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
   
    }

    public void InstantiateFruit(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        _ = Instantiate(prefab, position, rotation);
    }

    //Instantiates sliced version of the fruit at the position of the GameObject(uncut version). Destroys cut fruit immediately and uncut fruit after 5 seconds.
    public void CreateSlicedFruit(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        GameObject inst = Instantiate(prefab, position, rotation);
        OnCutDestructionFX(inst);
        //destroy uncut fruit
        Destroy(gameObject);
        //destory the sliced fruit
        Destroy(inst, 5f);

    }

    //When player cuts the object, slices fly in random direction with the explosion force.
    public void OnCutDestructionFX(GameObject itemCut)
    {

        Rigidbody[] rbSliced = itemCut.transform.GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody rb in rbSliced)
        {
            //gives the ridigbody a random rotation(rotates the banana slice)
            rb.transform.rotation = Random.rotation;
            //adds and explosion at the center of the banana.
            rb.AddExplosionForce(Random.Range(500, 1000), transform.position, explosionRadius);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Checks if the collided item has a blade component. If it doesn't returns null.
        Blade blade = collision.GetComponent<Blade>();
        //If the check was null return so rest of the code won't compile.
        if (!blade)
        {
            return;
        }
        //If the check was true cut the fruit.
        CreateSlicedFruit(slicedFruitPrefab, gameObject.transform.position, gameObject.transform.rotation);
    }
}
