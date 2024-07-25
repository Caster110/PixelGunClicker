
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
        public int Money = 0;                       // Можно задать полям значения по умолчанию
        public int Clicks = 0;
        public bool[] GunsAvailability = new bool[10];

        // Вы можете выполнить какие то действия при загрузке сохранений
        public SavesYG()
        {
            
        }
    }
}
