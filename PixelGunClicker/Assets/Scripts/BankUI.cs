using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YG;
public class BankUI : Bank
{
    [SerializeField] private Button buyUpgarde;
    [SerializeField] private Button adForMoney;
    [SerializeField] private Button adForClicks;
    [SerializeField] private Button gun;
    [SerializeField] private TMP_Text moneyRewardForAdText;
    [SerializeField] private TMP_Text clickRewardForAdText;
    [SerializeField] private TMP_Text upgradeCostText;
    [SerializeField] private TMP_Text moneyText;
    [SerializeField] private TMP_Text clicksText;
    private void Start()
    {
        UpdateAllUI();
        gun.onClick.AddListener(HandleGunClick);
        buyUpgarde.onClick.AddListener(HandlePurchaseClick);
        adForMoney.onClick.AddListener(() => YandexGame.RewVideoShow(0));
        adForClicks.onClick.AddListener(() => YandexGame.RewVideoShow(1));
        YandexGame.RewardVideoEvent += GiveReward;
    }
    private void HandleGunClick()
    {
        IncreaseClicks(RewardForClick);
        IncreaseMoney(RewardForClick);
        UpdateScoreUI();
    }
    private void GiveReward(int id)
    {
        if (id == 0)
            IncreaseMoney(MoneyRewardForAd);
        else
            IncreaseClicks(ClickRewardForAd);
        UpdateScoreUI();
    }
    private void HandlePurchaseClick()
    {
        if(TryBuyUpgrade())
            UpdateAllUI();
    }
    private void UpdateAllUI()
    {
        UpdateCostUI();
        UpdateScoreUI();
    }
    private void UpdateScoreUI()
    {
        moneyText.text = Money.ToString();
        clicksText.text = Clicks.ToString();
    }
    private void UpdateCostUI()
    {
        moneyRewardForAdText.text = MoneyRewardForAd.ToString();
        clickRewardForAdText.text = ClickRewardForAd.ToString();
        upgradeCostText.text = UpgradeCost.ToString();
    }
}
