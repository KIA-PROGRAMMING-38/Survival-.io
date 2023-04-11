using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    // 프리펩 저장
    public GameObject[] Prefabs;

    // 각 프리펩을 담을 풀
    List<GameObject>[] pools;

    private void Awake()
    {
        pools = new List<GameObject>[Prefabs.Length];
        for (int i = 0; i < Prefabs.Length; ++i)
        {
            pools[i] = new List<GameObject>();
        }
    }
    public GameObject Get(int index)
    {
        GameObject select = null;

        foreach (GameObject item in pools[index])
        {
            if (item.activeSelf == false)
            {
                select = item;
                select.SetActive(true);
                break;
            }
        }

        if (!select)
        {
            select = Instantiate(Prefabs[index], transform);
            pools[index].Add(select);
        }

        return select;
    }
}
