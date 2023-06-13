using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    public Vector3 camOffset = new Vector3(0f, 5f, -10f);
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void LateUpdate()
    {
        // 5
        this.transform.position = target.TransformPoint(camOffset);
        // 6
        this.transform.LookAt(target);
    }

}
