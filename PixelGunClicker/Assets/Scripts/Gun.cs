using System;
using UnityEngine;
using UnityEngine.UIElements;
using YG;
[Serializable]
public class Gun
{
    [SerializeField] private int index;
    [SerializeField] private Sprite unlocked;
    [SerializeField] private Sprite locked;
    [SerializeField] private int cost;
    [SerializeField] private Vector2 muzzleFlashPositions;
    [SerializeField] private Vector2 muzzleFlashScales;
    [SerializeField] private Color muzzleFlashColors;
    [SerializeField] private AudioClip gunSound;
    private bool isAvailable;
    public Sprite Unlocked => unlocked;
    public Sprite Locked => locked;
    public int Cost => cost;
    public bool IsAvailable => isAvailable;
    public Vector2 MuzzleFlashPositions => muzzleFlashPositions;
    public Vector2 MuzzleFlashScales => muzzleFlashScales;
    public Color MuzzleFlashColors => muzzleFlashColors;
    public AudioClip GunSound => gunSound;
    Gun()
    {
        LoadSaves();
    }

    private void LoadSaves()
    {
        if (!YandexGame.SDKEnabled)
        {
            isAvailable = YandexGame.savesData.Availability[index];
            if (!isAvailable)
                EventBus.ClicksIncreased += CheckAvailability;
            YandexGame.GetDataEvent -= LoadSaves;
        }
        else
            YandexGame.GetDataEvent += LoadSaves;
    }
    public void CheckAvailability()
    {
        if (Bank.Clicks >= cost)
            SetAvailable();
    }
    private void SetAvailable()
    {
        isAvailable = true;
        EventBus.ClicksIncreased -= CheckAvailability;
        EventBus.GunBecameAvailable?.Invoke();
        YandexGame.savesData.Availability[index] = true;
    }
}
