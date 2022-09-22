using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    Fruit Fruit;

    [SerializeField] private int coroutineTimeDelay = 5;
    [SerializeField] private float minTimeDelay = 0.3f;
    [SerializeField] private float maxTimeDelay = 1f;
    [SerializeField] private float minForce = 20f;
    [SerializeField] private float maxForce = 40f;
    private float randomForce;
    public Transform[] spawnLocations;
    public GameObject fruitPrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnFruits());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnFruits()
    {
        /*
        Fruit.InstantiateFruit(slicedFruitPrefab, spawnLocationTransform.position, spawnLocationTransform.rotation);
        yield return new WaitForSeconds(coroutineTimeDelay);
        */
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minTimeDelay, maxTimeDelay));

            Transform spawnLocation = spawnLocations[Random.Range(0, spawnLocations.Length)];
            GameObject spawnedFruit = Instantiate(fruitPrefab, spawnLocation.position, spawnLocation.rotation);
            randomForce = Random.Range(minForce, maxForce);
            Debug.Log("Random force is: " + randomForce);
            spawnedFruit.GetComponent<Rigidbody2D>().AddForce(spawnLocation.transform.up * randomForce, ForceMode2D.Impulse);
            Destroy(spawnedFruit, 5f);

            
        }
        
        
    }


}
