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
        EventBus.ClicksIncreased?.Invoke(clicks);
        return clicks;
    }
    protected int IncreaseMoney(int value) 
    {
        money += value;
        return money;
    }
    protected virtual int TryBuyUpgrade()
    {
        if (money >= upgradeCost)
        {
            money -= upgradeCost;
            RewardForClick++;
        }

        return money;
    }
}
