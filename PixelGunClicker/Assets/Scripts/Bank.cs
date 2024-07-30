using YG;
public class Bank
{
    public int RewardForClick { get; private set; }
    public int MoneyRewardForAd { get; private set; }
    public int ClickRewardForAd { get; private set; }
    public int UpgradeCost { get; private set; }
    public int Money { get; private set; }
    public static int Clicks { get; private set; }
    public Bank()
    {
        Money = YandexGame.savesData.Money;
        Clicks = YandexGame.savesData.Clicks;
        RewardForClick = YandexGame.savesData.RewardForClick;
        UpgradeCost = YandexGame.savesData.UpgradeCost;
        MoneyRewardForAd = YandexGame.savesData.MoneyRewardForAd;
        ClickRewardForAd = YandexGame.savesData.ClickRewardForAd;
    }
    public void IncreaseClicks(int value)
    {
        Clicks += value;
        YandexGame.savesData.Clicks = Clicks;
        EventBus.ClicksIncreased?.Invoke();
    }
    public void IncreaseMoney(int value) 
    {
        Money += value;
        YandexGame.savesData.Money = Money;
    }
    public void IncreaseReward()
    {
        MoneyRewardForAd += 600;
        ClickRewardForAd += 600;
    }
    public bool TryBuyUpgrade()
    {
        if (Money >= UpgradeCost)
        {
            Money -= UpgradeCost;
            UpgradeCost += 900;
            IncreaseReward();
            RewardForClick++;
            YandexGame.savesData.MoneyRewardForAd = MoneyRewardForAd;
            YandexGame.savesData.ClickRewardForAd = ClickRewardForAd;
            YandexGame.savesData.UpgradeCost = UpgradeCost;
            YandexGame.savesData.RewardForClick = RewardForClick;
            YandexGame.savesData.Money = Money;
            return true;
        }
        return false;
    }
}
