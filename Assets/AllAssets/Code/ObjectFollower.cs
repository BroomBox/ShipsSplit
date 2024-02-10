using UnityEngine;

public class ShipFollow : MonoBehaviour
{
    public Transform shipTarget;

    public float smoothingRotation = 0.15f;
    public float smoothingPosition = 0.5f;

    public Vector3 offset = new();


    // Update is called once per frame
    void LateUpdate()
    {
        //Szymon chce zobaczyæ jak z leeeeciutenkim opóŸnieniem na zmianie pozycji. Czego ten statek siê trzêsie?!
        //transform.position = shipTarget.position + offset;
        transform.position = Vector3.Lerp(transform.position, shipTarget.position, smoothingPosition * Time.deltaTime) + offset;

        transform.rotation = Quaternion.Lerp(transform.rotation, shipTarget.rotation, smoothingRotation * Time.deltaTime);
    }
}