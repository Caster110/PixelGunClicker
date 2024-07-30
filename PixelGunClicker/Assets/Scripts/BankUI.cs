using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YG;
public class BankUI : MonoBehaviour
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
    private Bank bank;
    private void Awake()
    {
        if (YandexGame.SDKEnabled)
            Initialize();
        else
            YandexGame.GetDataEvent += Initialize;
    }
    private void Initialize()
    {
        YandexGame.GetDataEvent -= Initialize;
        bank = new Bank();
        UpdateAllUI();
        gun.onClick.AddListener(HandleGunClick);
        buyUpgarde.onClick.AddListener(HandlePurchaseClick);
        adForMoney.onClick.AddListener(() => YandexGame.RewVideoShow(0));
        adForClicks.onClick.AddListener(() => YandexGame.RewVideoShow(1));
        YandexGame.RewardVideoEvent += GiveReward;
    }
    private void HandleGunClick()
    {
        bank.IncreaseClicks(bank.RewardForClick);
        bank.IncreaseMoney(bank.RewardForClick);
        UpdateScoreUI();
    }
    private void GiveReward(int id)
    {
        if (id == 0)
            bank.IncreaseMoney(bank.MoneyRewardForAd);
        else
            bank.IncreaseClicks(bank.ClickRewardForAd);
        UpdateScoreUI();
    }
    private void HandlePurchaseClick()
    {
        if(bank.TryBuyUpgrade())
            UpdateAllUI();
    }
    private void UpdateAllUI()
    {
        UpdateCostUI();
        UpdateScoreUI();
    }
    private void UpdateScoreUI()
    {
        moneyText.text = bank.Money.ToString();
        clicksText.text = Bank.Clicks.ToString();
    }
    private void UpdateCostUI()
    {
        moneyRewardForAdText.text = bank.MoneyRewardForAd.ToString();
        clickRewardForAdText.text = bank.ClickRewardForAd.ToString();
        upgradeCostText.text = bank.UpgradeCost.ToString();
    }
}
