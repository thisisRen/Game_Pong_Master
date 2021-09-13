using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUILevel : MonoBehaviour
{
    public DATALEVEL level;
    public RectTransform parent;
    public GameObject prefabs;
    private List<GameObject> list = new List<GameObject>();

    public void ShowLevel()
    {
        for (int i = 0; i < list.Count; i++) Destroy(list[i]);
        list.Clear();
        for (int i = 0; i < list.Count; i++)
        {
            GameObject g = Instantiate(prefabs, Vector3.zero, Quaternion.identity);
            g.transform.SetParent(parent);
            g.transform.localScale = Vector3.one;
            g.GetComponent<LevelElement>().SetData(level.listLevel[i]);
            list.Add(g);
        }

        float dY = level.listLevel.Count % 3 == 0 ? (float)level.listLevel.Count / 3f * 300f : ((float)level.listLevel.Count / 3f + 1f) * 300f;
    }
}
