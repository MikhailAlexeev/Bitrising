using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public GameObject platform;
    [Range(0,1)]
    public float speed;

    private float current;
    private float dir;
    
    // Start is called before the first frame update
    void Start()
    {
        current = 0.0f;
        dir = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        current += dir * speed * Time.deltaTime;

        if (current > 1.0f)
        {
            current = 1.0f;
            dir = -1.0f;
        } else if (current < 0.0f)
        {
            current = 0.0f;
            dir = 1.0f;
        }
        
        platform.transform.position = Vector3.Lerp(startPoint.position, endPoint.position, current);
    }
}
