using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUIStore : MonoBehaviour
{
    public DATA_CUP cup;
    public RectTransform parentCup;
    public GameObject prefabsCup;
    private List<GameObject> listCup = new List<GameObject>();
    public void ShowCup()
    {
        for (int i = 0; i < listCup.Count; i++) Destroy(listCup[i]);
        listCup.Clear();
        for (int i = 0; i < cup.StoreCup.Count; i++)
        {
            GameObject g = Instantiate(prefabsCup, Vector3.zero, Quaternion.identity);
            g.transform.SetParent(parentCup);
            g.transform.localScale = Vector3.one;
            g.GetComponent<CupElement>().SetData(cup.StoreCup[i]);
            listCup.Add(g);
        }

        float dY = cup.StoreCup.Count % 3 == 0 ? (float)cup.StoreCup.Count / 3f * 300f : ((float)cup.StoreCup.Count / 3f + 1f) * 300f;
    }

    public DATA_BALL ball;
    public RectTransform parentBall1, parentBall2;
    public GameObject prefabsBall;
    private List<GameObject> listBall = new List<GameObject>();

    public void ShowBall()
    {
        for (int i = 0; i < listBall.Count; i++) Destroy(listBall[i]);
        listBall.Clear();
        for (int i = 0; i < listBall.Count; i++)
        {
            GameObject g = Instantiate(prefabsBall, Vector3.zero, Quaternion.identity);
            if (i % 2 == 0)
            {
                g.transform.SetParent(parentBall1);
            }
            else
            {
                g.transform.SetParent(parentBall2);
            }
            
            g.transform.localScale = Vector3.one;
            g.GetComponent<BallElement>().SetData(ball.StoreBall[i]);
            listBall.Add(g);
        }

        float dY = ball.StoreBall.Count % 3 == 0 ? (float)ball.StoreBall.Count / 3f * 300f : ((float)ball.StoreBall.Count / 3f + 1f) * 300f;
    }
}
