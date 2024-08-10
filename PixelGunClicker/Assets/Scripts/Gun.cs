using System;
using UnityEngine;
using YG;
[Serializable]
public class Gun
{
    [SerializeField] private int index;
    [SerializeField] private Sprite sprite;
    [SerializeField] private int cost;
    [SerializeField] private Vector2 muzzleFlashPositions;
    [SerializeField] private Vector2 muzzleFlashScales;
    [SerializeField] private Color muzzleFlashColors;
    [SerializeField] private AudioClip gunSound;
    private bool isAvailable;
    public Sprite Sprite => sprite;
    public int Cost => cost;
    public bool IsAvailable => isAvailable;
    public Vector2 MuzzleFlashPositions => muzzleFlashPositions;
    public Vector2 MuzzleFlashScales => muzzleFlashScales;
    public Color MuzzleFlashColors => muzzleFlashColors;
    public AudioClip GunSound => gunSound;
    public bool isNewGuns => index >= YandexGame.savesData.Availability.Length;
    public void Initialize()
    {
        if (isNewGuns)
            isAvailable = YandexGame.savesData.UpdatedAvailability[index - 15];
        else
            isAvailable = YandexGame.savesData.Availability[index];
        if (!isAvailable)
            EventBus.ClicksIncreased += CheckAvailability;
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
        if (isNewGuns)
            YandexGame.savesData.UpdatedAvailability[index - 15] = true;
        else
            YandexGame.savesData.Availability[index] = true;
    }
}
