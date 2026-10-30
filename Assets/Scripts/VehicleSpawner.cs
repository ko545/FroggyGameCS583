using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleSpawner : MonoBehaviour
{
    // Prefab for instantiating apples
    [SerializeField] public GameObject applePrefab;
    // Rate at which Apples will be instantiated
    [SerializeField] public float secondsBetweenAppleDrops = 2f;
    // Chance that the AppleTree will change directions
    [SerializeField] public float chanceToChangeDirections = 0.01f;
    
    void Start () {
        // Dropping apples every second
        Invoke( "DropApple", 2f); // a
    }

    void DropApple() { // b
        GameObject apple = Instantiate<GameObject>( applePrefab ); // c
        apple.transform.position = transform.position; // d
        Invoke( "DropApple", secondsBetweenAppleDrops ); // e
    }
    
    void FixedUpdate() {
        if (Random.value < chanceToChangeDirections) { Invoke( "DropApple", 0f);
        }
    }
    
}
