using UnityEngine;
using UnityEngine.UI;
public class BankUI : Bank
{
    [SerializeField] private Button buyUpgarde;
    [SerializeField] private Button adForMoney;
    [SerializeField] private Button adForClicks;
    [SerializeField] private Button gun;
    private void Start()
    {
        gun.onClick.AddListener(HandleGunClick);
        adForClicks.onClick.AddListener(() => HandleVideoClick(false));
        adForMoney.onClick.AddListener(() => HandleVideoClick(true));
        buyUpgarde.onClick.AddListener(HandlePurchase);
    }
    private void HandleGunClick()
    {
        IncreaseClicks(RewardForClick);
        IncreaseMoney(RewardForClick);
        //display
    }
    private void HandleVideoClick(bool isForMoney)
    {
        if (isForMoney)
            IncreaseMoney(MoneyRewardForAd);
        else
            IncreaseClicks(ClickRewardForAd);
        //display

    }
    private void HandlePurchase()
    {
        TryBuyUpgrade();
        //display
    }
}
