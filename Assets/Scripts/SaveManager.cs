using UnityEngine;

public static class SaveManager
{
    public static bool isLevelUnlocked(string sceneName) {
        return PlayerPrefs.HasKey(getKey(sceneName));
    }

    public static void setLevelUnlocked(string sceneName) {
        PlayerPrefs.SetInt(getKey(sceneName), 1);
        PlayerPrefs.Save();
    }

    private static string getKey(string sceneName) {
      return sceneName + "_Unlocked";
    }
}
