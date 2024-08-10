using UnityEngine;
using YG;
public class ProgressSaver : MonoBehaviour
{
    public void SaveProgress()
    {
        YandexGame.SaveCloud();
        YandexGame.SaveLocal();
        YandexGame.NewLeaderboardScores("ClickRecors", Bank.Clicks);
    }
}
