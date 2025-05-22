using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] List<GameObject> obstacles;
    [SerializeField] string [ ] obstaclenames;
    [SerializeField] int createCount = 5;
    [SerializeField] Transform [ ] transforms;
    [SerializeField] float activeTime = 5;
    [SerializeField] int random;
    [SerializeField] float speed;
    private void Awake()
    {
        obstacles.Capacity = 10;
    }
    void Start()
    {
        Create();
    }
    public void Create()
    {
        for(int i = 0; i < createCount; i++)
        {
            GameObject clone = Instantiate(Resources.Load<GameObject>(obstaclenames[Random.Range(0,obstaclenames.Length)]),transform);
            clone.name = clone.name.Replace("(Clone)", "");
            clone.SetActive(false);
            obstacles.Add(clone);
            
        }
    }
    public void OnStartButtonClick()
    {
        StartCoroutine(ActiveObstacle());
    }
    public IEnumerator ActiveObstacle()
    {
        while(true)
        { 
            random = Random.Range(0,obstacles.Count);
            while (obstacles[random].activeSelf == true)
            {
                random = (random + 1) % obstacles.Count;
            }
            obstacles[random].transform.position = transforms[Random.Range(0, transforms.Length)].position;
            obstacles[random].SetActive(true);
            if(ExamineActive())
            {
                GameObject clone = Instantiate(Resources.Load<GameObject>(obstaclenames[Random.Range(0, obstaclenames.Length)]), transform);
                clone.name = clone.name.Replace("(Clone)", "");
                clone.SetActive(false);
                obstacles.Add(clone);
            }
            yield return new WaitForSeconds(activeTime);
        }
    }
    bool ExamineActive()
    {
        for (int i = 0; i < obstacles.Count; i++)
        {
            if (obstacles[i].activeSelf != true)
            {
                return false;
            }
        }
        return true;
    }
}
