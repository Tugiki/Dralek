using System;
using UnityEngine;

public class Gold : MonoBehaviour, IItem
{
    public static event Action<int> OnGoldCollect;
    public int worth = 10;
    public void Collect()
    {
        OnGoldCollect.Invoke(worth);
        Destroy(gameObject);
    }
}
