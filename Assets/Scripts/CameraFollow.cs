using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float smooth = 0.3f;
    private Vector3 velocity = Vector3.zero;

    public float height;

    private void Update()
    {
        Vector3 pos = new Vector3();
        pos.x = player.position.x -4f;
        pos.z = player.position.z;
        pos.y = player.position.y + height;
        transform.position = Vector3.SmoothDamp(transform.position, pos, ref velocity, smooth);
    }
}
