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
        public bool[] UpdatedAvailability = new bool[5];
        public int UpgradeCost = 900;
        public int MoneyRewardForAd = 600;
        public int ClickRewardForAd = 600;
        public SavesYG()
        {
            Availability[0] = true;
            for (int i = 1; i < Availability.Length; i++)
                Availability[i] = false;
            for (int i = 1; i < UpdatedAvailability.Length; i++)
                UpdatedAvailability[i] = false;
        }
    }
}
