using UnityEngine;
using YG;
public class ProgressSaver : MonoBehaviour
{
    public void SaveProgress()
    {
        YandexGame.SaveProgress();
        YandexGame.NewLeaderboardScores("ClickRecors", Bank.Clicks);
    }
}
