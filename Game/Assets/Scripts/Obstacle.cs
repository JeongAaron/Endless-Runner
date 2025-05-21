using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Obstacle : MonoBehaviour, ICollidable
{
    [SerializeField] float speed;
    public void Activate()
    {
        gameObject.SetActive(false);
    }
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

}
