using UnityEngine;

public class VehicleMovement : MonoBehaviour
{
    // Speed at which the AppleTree moves
    [SerializeField] public float speed = 10f;
    // Distance where AppleTree turns around
    [SerializeField] public float leftAndRightEdge = 100f;
    
    void Update () {
        // Basic Movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        // Destroy when past the set distance
        if (Mathf.Abs(pos.x) > Mathf.Abs(leftAndRightEdge)) { Destroy(this.gameObject); } 
    }

    
}
