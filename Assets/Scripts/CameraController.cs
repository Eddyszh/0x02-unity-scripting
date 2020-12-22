using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    void Start()
    {
        offset = new Vector3
            (
            transform.position.x - player.transform.position.x,
            transform.position.y - player.transform.position.y,
            transform.position.z - player.transform.position.z
            );
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        transform.position = player.transform.position + offset;
    }
}
