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

        // Тестовые сохранения для демо сцены
        // Можно удалить этот код, но тогда удалите и демо (папка Example)
        public int money;
        public string newPlayerName;
        public bool[] openLevels = new bool[10];


        public int RewardForClick = 1;
        public int Money = 0;
        public int Clicks = 0;
        public bool[] GunsAvailability = new bool[10];
        public int UpgradeCost = 1000;
        public int MoneyRewardForAd = 300;
        public int ClickRewardForAd = 300;
        public SavesYG()
        {
            GunsAvailability[0] = true;
            for (int i = 1; i < GunsAvailability.Length; i++)
                GunsAvailability[i] = false;
        }
    }
}
