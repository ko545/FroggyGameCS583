using UnityEngine;

public class GoldSpawner : MonoBehaviour
{
    // Prefab for instantiating apples
    [SerializeField] public GameObject prefab;
    [SerializeField] public GameObject prefab2;
    [SerializeField] public GameObject prefab3;
    // Rate at which Apples will be instantiated
    [SerializeField] public float secondsBetweenDrops = 10f;
    // Chance that the AppleTree will change directions
    [SerializeField] public float chanceToDrop = 0.1f;
    [SerializeField] public float chanceToDrop2 = 0.01f;

    private Vector3 randomVec = Vector3.zero;
    void Start () {
        // Dropping apples every second
        Invoke( "DropPrefab", 2f); // a
    }

    void DropPrefab() { // b
        GameObject gold = Instantiate<GameObject>( prefab ); // c
        gold.transform.position = transform.position + randomVec; // d
        Invoke( "DropPrefab", secondsBetweenDrops ); // e
    }
    
    void DropPrefab2() { // b
        GameObject gold = Instantiate<GameObject>( prefab2 ); // c
        gold.transform.position = transform.position + randomVec; // d
        Invoke( "DropPrefab", secondsBetweenDrops ); // e
    }
    
    void DropPrefab3() { // b
        GameObject gold = Instantiate<GameObject>( prefab3 ); // c
        gold.transform.position = transform.position + randomVec; // d
        Invoke( "DropPrefab", secondsBetweenDrops ); // e
    }
    
    void FixedUpdate() {
        randomVec = Random.insideUnitCircle * 3;
        
        if (Random.value < chanceToDrop) { Invoke( "DropPrefab2", 3f);
        }
        if (Random.value < chanceToDrop2) { Invoke( "DropPrefab3", 3f);
        }
    }
}
