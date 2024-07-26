using UnityEngine;
using YG;
public class Bank : MonoBehaviour
{
    public int RewardForClick { get; private set; }
    public int MoneyRewardForAd { get; private set; }
    public int ClickRewardForAd { get; private set; }
    public int UpgradeCost { get; private set; }
    public int Money { get; private set; }
    public static int Clicks { get; private set; }
    private void Start()
    {
        Money = YandexGame.savesData.Money;
        Clicks = YandexGame.savesData.Clicks;
        RewardForClick = YandexGame.savesData.RewardForClick;
        UpgradeCost = YandexGame.savesData.UpgradeCost;
        MoneyRewardForAd = YandexGame.savesData.MoneyRewardForAd;
        ClickRewardForAd = YandexGame.savesData.ClickRewardForAd;
    }
    protected void IncreaseClicks(int value)
    {
        Clicks += value;
        YandexGame.savesData.Clicks = Clicks;
        EventBus.ClicksIncreased?.Invoke(Clicks);
    }
    protected void IncreaseMoney(int value) 
    {
        Money += value;
        YandexGame.savesData.Money = Money;
    }
    private void IncreaseReward()
    {
        MoneyRewardForAd += 300;
        ClickRewardForAd += 300;
    }
    protected bool TryBuyUpgrade()
    {
        if (Money >= UpgradeCost)
        {
            Money -= UpgradeCost;
            UpgradeCost += 1000;
            IncreaseReward();
            RewardForClick++;
            YandexGame.savesData.UpgradeCost = UpgradeCost;
            YandexGame.savesData.RewardForClick = RewardForClick;
            YandexGame.savesData.Money = Money;
            YandexGame.SaveProgress();
            return true;
        }
        return false;
    }
}
