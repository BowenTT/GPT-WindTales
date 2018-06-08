using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void CoinUpdateEvent();
    public static event CoinUpdateEvent coinUpdateEvent;

    public static void CoinUpdate()
    {
        if (coinUpdateEvent != null)
            coinUpdateEvent();
    }
}