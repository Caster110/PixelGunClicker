using YG;
public static class ProgressSaver
{
    public static void SaveProgress()
    {
        YandexGame.Instance._SaveProgress();
        YandexGame.NewLeaderboardScores("ClickRecords", Bank.Clicks);
    }
}
