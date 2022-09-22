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
            CreateSlicedFruit(slicedFruitPrefab, gameObject.transform.position, gameObject.transform.rotation);
        }
    }

    public void InstantiateFruit(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        _ = Instantiate(prefab, position, rotation);
    }

    //Instantiates sliced version of the fruit at the position of the GameObject(uncut version) and destroys the GameObject.
    public void CreateSlicedFruit(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        GameObject inst = Instantiate(prefab, position, rotation);
        OnCutDestructionFX(inst);

        Destroy(gameObject);
        Destroy(inst, 5f);

    }


    public void OnCutDestructionFX(GameObject itemCut)
    {

        Rigidbody[] rbSliced = itemCut.transform.GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody rb in rbSliced)
        {
            rb.transform.rotation = Random.rotation;
            rb.AddExplosionForce(Random.Range(500, 1000), transform.position, explosionRadius);
        }

    }
}
