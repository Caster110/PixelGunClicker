using System;
using UnityEngine;
[Serializable]
public class Gun
{
    [SerializeField] private int index;
    [SerializeField] private Sprite unlocked;
    [SerializeField] private Sprite locked;
    [SerializeField] private int cost;
    [SerializeField] private bool isAvailable;
    public Sprite UnlockedSprite => unlocked;
    public Sprite LockedSprite => locked;
    public int Cost => cost;
    public bool IsAvailable => isAvailable;
    Gun()
    {
        EventBus.ClicksIncreased += CheckAvailability;
    }
    private void CheckAvailability(int value)
    {
        if (value >= cost)
            SetAvailable();
    }
    private void SetAvailable()
    {
        isAvailable = true;
        EventBus.ClicksIncreased -= CheckAvailability;
        EventBus.GunBecameAvailable?.Invoke();
    }
}
