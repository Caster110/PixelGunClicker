using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class BankUI : Bank
{
    [SerializeField] private Button buyUpgarde;
    [SerializeField] private Button adForMoney;
    [SerializeField] private Button adForClicks;
    [SerializeField] private Button gun;
    [SerializeField] private TMP_Text moneyText;
    [SerializeField] private TMP_Text clicksText;
    private void Start()
    {
        gun.onClick.AddListener(HandleGunClick);
        adForClicks.onClick.AddListener(() => HandleVideoClick(false));
        adForMoney.onClick.AddListener(() => HandleVideoClick(true));
        buyUpgarde.onClick.AddListener(HandlePurchase);
    }
    private void HandleGunClick()
    {
        UpdateUIState(
            IncreaseClicks(RewardForClick), 
            IncreaseMoney(RewardForClick));
    }
    private void HandleVideoClick(bool isForMoney)
    {
        if (isForMoney)
            UpdateUIState(IncreaseMoney(MoneyRewardForAd), isForMoney);
        else
            UpdateUIState(IncreaseClicks(ClickRewardForAd), isForMoney);

    }
    private void HandlePurchase()
    {
        UpdateUIState(TryBuyUpgrade(), true); ;
    }
    private void UpdateUIState(int value, bool isForMoney)
    {
        if (isForMoney)
            moneyText.text = value.ToString();
        else
            clicksText.text = value.ToString();
    }
    private void UpdateUIState(int clickValue, int moneyValue)
    {
        clicksText.text = clickValue.ToString();
        moneyText.text = moneyValue.ToString();
    }
}
