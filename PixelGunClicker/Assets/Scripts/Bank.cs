using UnityEngine;
using YG;
public class Bank : MonoBehaviour
{
    public int RewardForClick { get; private set; }
    public int MoneyRewardForAd { get; private set; }
    public int ClickRewardForAd { get; private set; }
    private int money;
    private int clicks;
    private int upgradeCost = 1000;
    private void Start()
    {
        money = YandexGame.savesData.Money;
        clicks = YandexGame.savesData.Clicks;
        RewardForClick = YandexGame.savesData.RewardForClick;
    }
    protected int IncreaseClicks(int value)
    {
        clicks += value;
        YandexGame.savesData.Clicks = clicks;
        EventBus.ClicksIncreased?.Invoke(clicks);
        return clicks;
    }
    protected int IncreaseMoney(int value) 
    {
        money += value;
        YandexGame.savesData.Money = money;
        return money;
    }
    protected int TryBuyUpgrade()
    {
        if (money >= upgradeCost)
        {
            money -= upgradeCost;
            RewardForClick++;
        }
        YandexGame.savesData.RewardForClick = RewardForClick;
        YandexGame.savesData.Money = money;
        YandexGame.SaveProgress();
        return money;
    }
}
