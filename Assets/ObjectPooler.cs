using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler Instance;

    public List<GameObject> ballList;
    public GameObject prefabsBall;
    
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        ballList = new List<GameObject>();
        SpawnBall();

    }
    private void SpawnBall()
    {
        for(int i=0; i<10; i++)
        {
            GameObject obj = Instantiate(prefabsBall,this.transform.position, Quaternion.identity);
            if (obj == null)
            {
                Debug.Log("NULL");
            }
            else
            {
                obj.SetActive(false);
                ballList.Add(obj);
            }
        }
        
    }

    
}
