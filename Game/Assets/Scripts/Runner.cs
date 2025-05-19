using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Runner : MonoBehaviour
{
    [SerializeField] float move = 4f;
    public enum RoadLine
    {
        LEFT = -1,
        MIDDLE = 0,
        RIGHT = 1
    }
    private void Awake()
    {
        roadLine = RoadLine.MIDDLE;
        rb = GetComponent<Rigidbody>();
    }
    public RoadLine roadLine;
    private Rigidbody rb;
    void Start()
    {
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (roadLine > RoadLine.LEFT)
            {
                roadLine--;
                
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (roadLine < RoadLine.RIGHT)
            {
                roadLine++;
            }
        }
    }
    private void FixedUpdate()
    {
        if (rb != null)
        {
            rb.position = new Vector3((float)roadLine*move,0,0);
        }
    }
}
