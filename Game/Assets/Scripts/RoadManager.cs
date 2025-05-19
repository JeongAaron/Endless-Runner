using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class RoadManager : MonoBehaviour
{
    [SerializeField] List<GameObject> roads;
    [SerializeField] float speed;
    //[SerializeField] float offset = 40.0f;
    [SerializeField] float newZ = 40.0f;
    [SerializeField] GameObject start;
    public void InitializePostion()
    {
        GameObject newRoad = roads[0];
        roads.Remove(roads[0]);
        newRoad.transform.position = roads[roads.Count - 1].transform.position + new Vector3(0, 0, newZ);
        roads.Add(newRoad);
       // GameObject newRoad = roads[0];
       // roads.Remove(newRoad);
       // float newZ = roads[roads.Count - 1].transform.position.z + offset;
       // newRoad.transform.position = new Vector3(0, 0, newZ);
       // roads.Add(newRoad);
    }
    private bool isMoving = false;
    public void OnStartButtonClick()
    {
        isMoving = true;
        Camera.main.transform.position = new Vector3(0, 3, -4);
        Camera.main.transform.rotation = Quaternion.Euler(12f, 0f, 0f);
        start.SetActive(false);
    }
    void Start()
    {
        Camera.main.transform.position = new Vector3(1.1f, 0.5f, 0.5f);
        Camera.main.transform.rotation = Quaternion.Euler(-22f, -95f, 0f);
    }
    void Update()
    {
        if (isMoving)
        {
            for (int i = 0; i < roads.Count; i++)
            {
                roads[i].transform.Translate(speed * Vector3.back * Time.deltaTime);
            }
        }
    }
}
