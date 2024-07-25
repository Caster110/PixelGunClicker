using UnityEngine;
using UnityEngine.UI;
public class GunUI : MonoBehaviour
{
    [SerializeField] private Image selectedGun;
    [SerializeField] private Button next;
    [SerializeField] private Button prev;
    [SerializeField] private Gun[] guns;
    private int gunIndex = 0;
    private void Start()
    {
        HandleChange(0);
        next.onClick.AddListener(() => HandleChange(1));
        prev.onClick.AddListener(() => HandleChange(-1));
        EventBus.GunBecameAvailable += HandleButtonsState;
    }
    private void HandleChange(int direction)
    {
        gunIndex += direction;
        selectedGun.sprite = guns[gunIndex].UnlockedSprite;
        HandleButtonsState();
    }
    private void HandleButtonsState()
    {
        if (gunIndex == 0)
        {
            prev.gameObject.SetActive(false);
        }
        else if (gunIndex == guns.Length - 1)
        {
            next.gameObject.SetActive(false);
            return;
        }
        else
        {
            next.gameObject.SetActive(true);
            prev.gameObject.SetActive(true);
        }

        if (guns[gunIndex + 1].IsAvailable == false)
        {
            //Show price and locked gun image, block nextButton !!DO NOT DISABLE GAMEOBJECT
        }
        else
        {
            //Hide price and locked gun image, unblock nextButton
        }
    }
}
