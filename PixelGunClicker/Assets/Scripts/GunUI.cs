using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using YG;
public class GunUI : MonoBehaviour
{
    [SerializeField] private TMP_Text costOfLockedGun;
    [SerializeField] private Image lockedGun;
    [SerializeField] private Image selectedGun;
    [SerializeField] private Button next;
    [SerializeField] private Button prev;
    [SerializeField] private Button gun;
    [SerializeField] private Gun[] guns;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Animator gunAnimator;
    [SerializeField] private Image muzzleFlashImage;
    private Coroutine muzzleFlashCoroutine;
    private int currentGunIndex = 0;
    private void Start()
    {
        if (YandexGame.SDKEnabled)
            Initialize();
        else
            YandexGame.GetDataEvent += Initialize;
    }
    private void Initialize()
    {
        for (int i = 0; i < guns.Length; i++)
            guns[i].Initialize();
        gun.onClick.AddListener(HandleGunClick);
        next.onClick.AddListener(() => HandleChange(1));
        prev.onClick.AddListener(() => HandleChange(-1));
        EventBus.GunBecameAvailable += HandleButtonsState;
        HandleButtonsState();
        YandexGame.GetDataEvent -= Initialize;
    }
    private void HandleChange(int direction)
    {
        currentGunIndex += direction;
        selectedGun.sprite = guns[currentGunIndex].Sprite;
        HandleButtonsState();
    }
    private void HandleButtonsState()
    {
        if (currentGunIndex == guns.Length - 1)
        {
            next.gameObject.SetActive(false);
            return;
        }
        if (currentGunIndex != 0)
        {
            prev.gameObject.SetActive(true);
        }
        else
        {
            prev.gameObject.SetActive(false);
        }    

        if (guns[currentGunIndex + 1].IsAvailable)
        {
            costOfLockedGun.gameObject.SetActive(false);
            lockedGun.gameObject.SetActive(false);
            next.gameObject.SetActive(true);
        }
        else
        {
            costOfLockedGun.gameObject.SetActive(true);
            lockedGun.gameObject.SetActive(true);
            costOfLockedGun.text = guns[currentGunIndex + 1].Cost.ToString();
            lockedGun.sprite = guns[currentGunIndex + 1].Sprite;
            next.gameObject.SetActive(false);
        }
    }
    private void HandleGunClick()
    {
        PlaySound();
        ShowMuzzleFlash();
        PlayRecoilAnimation();
    }
    private void PlaySound()
    {
        audioSource.clip = guns[currentGunIndex].GunSound;
        audioSource.Play();
    }
    private void PlayRecoilAnimation()
    {
        gunAnimator.Play("FireAnim", 0, 0f);
    }
    private void ShowMuzzleFlash()
    {
        if (muzzleFlashCoroutine != null)
        {
            StopCoroutine(muzzleFlashCoroutine);
        }

        SetMuzzleFlash(guns[currentGunIndex].MuzzleFlashPositions,
             guns[currentGunIndex].MuzzleFlashScales,
            guns[currentGunIndex].MuzzleFlashColors);
    }

    private void SetMuzzleFlash(Vector2 position, Vector2 scale, Color color)
    {
        muzzleFlashImage.rectTransform.anchoredPosition = position;
        muzzleFlashImage.rectTransform.localScale = scale;
        muzzleFlashImage.color = color;
        muzzleFlashImage.enabled = true;

        muzzleFlashCoroutine = StartCoroutine(FadeOutMuzzleFlash());
    }

    private IEnumerator FadeOutMuzzleFlash()
    {
        float duration = 0.13f; 
        float elapsed = 0f;
        Color initialColor = muzzleFlashImage.color;
        Color targetColor = new Color(initialColor.r, initialColor.g, initialColor.b, 0f);

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            muzzleFlashImage.color = Color.Lerp(initialColor, targetColor, elapsed / duration);
            yield return null;
        }

        muzzleFlashImage.enabled = false;
    }
}