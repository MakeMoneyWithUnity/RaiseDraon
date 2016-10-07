using UnityEngine;
using UnityEngine.Advertisements;

public class UnityAdsExample : MonoBehaviour {
    // Serialize private fields
    //  instead of making them public.
    [SerializeField]
    string iosGameId;
    [SerializeField]
    string androidGameId = "1162288";
    [SerializeField]
    bool enableTestMode = true;

    void Start() {
        string gameId = null;

#if UNITY_IOS // If build platform is set to iOS...
        gameId = iosGameId;
#elif UNITY_ANDROID // Else if build platform is set to Android...
        gameId = "1162288";
#endif

        if (string.IsNullOrEmpty(gameId)) { // Make sure the Game ID is set.
            Debug.LogError("Failed to initialize Unity Ads. Game ID is null or empty.");
        } else if (!Advertisement.isSupported) {
            Debug.LogWarning("Unable to initialize Unity Ads. Platform not supported.");
        } else if (Advertisement.isInitialized) {
            Debug.Log("Unity Ads is already initialized.");
        } else {
            Debug.Log(string.Format("Initialize Unity Ads using Game ID {0} with Test Mode {1}.",
                gameId, enableTestMode ? "enabled" : "disabled"));
            Advertisement.Initialize("1162288", enableTestMode);
        }
    }

    
    public void ShowRewardedAd() {
        if (Advertisement.IsReady("rewardedVideo")) {
            var options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show("rewardedVideo", options);
        }
    }

    private void HandleShowResult(ShowResult result) {
        switch (result) {
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown.");
                //
                // YOUR CODE TO REWARD THE GAMER
                // Give coins etc.
                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");
                break;
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown.");
                break;
        }
    }
}