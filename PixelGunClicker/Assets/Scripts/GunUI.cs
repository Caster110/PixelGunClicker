using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GunUI : MonoBehaviour
{
    [SerializeField] private TMP_Text costOfLockedGun;
    [SerializeField] private Image lockedGun;
    [SerializeField] private Image selectedGun;
    [SerializeField] private Button next;
    [SerializeField] private Button prev;
    [SerializeField] private Gun[] guns;
    private int currentGunIndex = 0;
    private void Start()
    {
        HandleButtonsState();
        next.onClick.AddListener(() => HandleChange(1));
        prev.onClick.AddListener(() => HandleChange(-1));
        EventBus.GunBecameAvailable += HandleButtonsState;
    }
    private void HandleChange(int direction)
    {
        currentGunIndex += direction;
        selectedGun.sprite = guns[currentGunIndex].UnlockedSprite;
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
            //Hide price and locked gun image
            next.gameObject.SetActive(true);
        }
        else
        {
            //Show price and locked gun image
            costOfLockedGun.text = guns[currentGunIndex + 1].Cost.ToString();
            lockedGun.sprite = guns[currentGunIndex + 1].LockedSprite;
            next.gameObject.SetActive(false);
        }
    }
}
