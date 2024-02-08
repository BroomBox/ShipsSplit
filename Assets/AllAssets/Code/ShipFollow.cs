using UnityEngine;

public class ShipFollow : MonoBehaviour
{
    public Transform shipTarget;

    public float smoothing = 0.15f;
    public Vector3 offset = new();
    
    
    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = shipTarget.position + offset;
        
        transform.rotation = Quaternion.Lerp(transform.rotation, shipTarget.rotation, smoothing);
    }
}