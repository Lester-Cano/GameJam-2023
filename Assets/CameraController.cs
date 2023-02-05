using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public PlayerMovementHybrid player;
    private Vector2 offset;
    public Vector3 PlayerPos;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerMovementHybrid>().GetComponent<PlayerMovementHybrid>();
        offset = transform.position - player.transform.position;
        PlayerPos = player.pos;
    }

    // Update is called once per frame
    void LateUpdate()
    {

        transform.position = PlayerPos;
    }
}
