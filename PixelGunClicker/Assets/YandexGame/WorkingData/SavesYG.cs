using UnityEngine;
namespace YG
{
    [System.Serializable]
    public class SavesYG
    {
        // "Технические сохранения" для работы плагина (Не удалять)
        public int idSave;
        public bool isFirstSession = true;
        public string language = "ru";
        public bool promptDone;

        public int RewardForClick = 1;
        public int Money = 0;
        public int Clicks = 0;
        public bool[] Availability = new bool[15];
        public int UpgradeCost = 100;
        public int MoneyRewardForAd = 300;
        public int ClickRewardForAd = 300;
        public SavesYG()
        {
            Availability[0] = true;
            for (int i = 1; i < Availability.Length; i++)
                Availability[i] = false;
        }
    }
}
