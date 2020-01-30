using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    public Transform player;

    void LateUpdate ()
    {
        Vector3 newPosition = player.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;

        //transform.rotation = Quaternion.Euler(90f, player.eulerAngles.y, 0f); //Makes the minimap rotate with the player (don't know if we want that or not)
    }

}
