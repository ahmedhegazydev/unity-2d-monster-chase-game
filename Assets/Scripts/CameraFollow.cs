using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{


    private Vector3 tempPos;
    private Transform player;

    [SerializeField]
    private float minX, maxX;
     

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player1").transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        //tempPos = transform.position;
        //tempPos.x = player.position.x;

        //transform.position = tempPos;

    }

    private void LateUpdate()
    {
        tempPos = transform.position;
        tempPos.x = player.position.x;

        if (tempPos.x < minX)
            tempPos.x = minX;

        if (tempPos.x > maxX)
            tempPos.x = maxX;



        transform.position = tempPos;
    }



}
