using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject player;        //Public variable to store a reference to the player game object

    private Vector3 offset;            //Private variable to store the offset distance between the player and camera

    // Use this for initialization
    void Start()
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - player.transform.position;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        //transform.position = player.transform.position + offset;

        /*if (Input.GetKey(KeyCode.Period))
        {
            //transform.Rotate(player.transform.rotation.x, player.transform.rotation.y, player.transform.rotation.z, Space.Self);
            transform.RotateAround(player.transform.position, Vector3.up, -5);
        }
        else if (Input.GetKey(KeyCode.Comma))
        {
            //transform.Rotate(player.transform.rotation.x, player.transform.rotation.y, player.transform.rotation.z, Space.Self);
            transform.RotateAround(player.transform.position, Vector3.up, 5);
        }*/

        if (Input.GetKey(KeyCode.Period) || Input.GetKey(KeyCode.Comma))
        {
            float x = transform.position.x, z = transform.position.z;

            if (Vector3.up == player.transform.up || Vector3.up == -player.transform.up)
            {
                x = player.transform.position.x + Mathf.Cos(player.transform.eulerAngles.y) * Mathf.PI / 180 * offset.magnitude;
                z = player.transform.position.z + Mathf.Sin(player.transform.eulerAngles.y) * Mathf.PI / 180 * offset.magnitude;
                //transform.Rotate(0, 5, 0, Space.Self);
            }
            else if (Vector3.up == player.transform.forward || Vector3.up == -player.transform.forward)
            {
                x = player.transform.position.x + Mathf.Cos(player.transform.eulerAngles.z) * Mathf.PI / 180 * offset.magnitude;
                z = player.transform.position.z + Mathf.Sin(player.transform.eulerAngles.z) * Mathf.PI / 180 * offset.magnitude;
                //transform.Rotate(0, 5, 0, Space.Self);
            }
            else if (Vector3.up == player.transform.right || Vector3.up == -player.transform.right)
            {
                x = player.transform.position.x + Mathf.Cos(player.transform.eulerAngles.x) * Mathf.PI / 180 * offset.magnitude;
                z = player.transform.position.z + Mathf.Sin(player.transform.eulerAngles.x) * Mathf.PI / 180 * offset.magnitude;
                //transform.Rotate(0, 5, 0, Space.Self);
            }

            transform.position = new Vector3(x, transform.position.y, z);
            transform.LookAt(player.transform);
        }

        else
        {
            transform.position = player.transform.position + offset;
        }

    }
}
