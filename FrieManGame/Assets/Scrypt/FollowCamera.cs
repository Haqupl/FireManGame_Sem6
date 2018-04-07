using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{

    public Transform player;
    private Vector3 offset;
    // Use this for initialization
    void Start()
    {
        offset = transform.position - player.position;
    }

    public void LateUpdate()
    {
        transform.position = offset + player.position;
    }
}
