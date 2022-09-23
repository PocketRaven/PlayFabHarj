using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class PlayFabLogin : MonoBehaviour
{
    [Header("LOGIN")]
    private string userEmailLogin;
    private string userPasswordLogin;
    public void Start()
    {
        // Tarkistetaan ettei TitleID ole tyhj‰ eli null
        if (string.IsNullOrEmpty(PlayFabSettings.TitleId))
        {
            // Lis‰‰ oma TitleID,jonka lˆyd‰t PlayFab pilven Game Managerista
            PlayFabSettings.TitleId = "8C47D";
        }

        // T‰ss‰ luodaan API-kutsu (GET)
        var request = new LoginWithEmailAddressRequest { Email = userEmailLogin, Password = userPasswordLogin};
        // T‰ss‰ suoritetaan API-kutsu pilvess‰ olevalla palvelimelle
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnLoginFailure);
    }
    // T‰m‰ metodi suoritetaan jos Loggaus onnistuu
    private void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("Congratulations, you made your first 9successful API call!");
    }
    // T‰m‰ metodi suoritetaan jos loggaus ep‰onnistuu
    private void OnLoginFailure(PlayFabError error)
    {
        Debug.LogWarning("Something went wrong with your first API call.  :(");
        Debug.LogError("Here's some debug information:");
        Debug.LogError(error.GenerateErrorReport());
    }
    public void GetUserPasswordLogin(string passwordIn)
    {
        userPasswordLogin = passwordIn;
    }
    public void GetUserEmailLogin (string emailIn)
    {
        userEmailLogin = emailIn;
    }

    //Login painikkeen koodi eli t‰ss‰ tehd‰‰n API-kutsu PlayFab pilveen ja selvitet‰‰n onko k‰ytt‰j‰ olemassa

    public void LogIn()
    {
        var request = new LoginWithEmailAddressRequest { Email = userEmailLogin, Password = userPasswordLogin };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnLoginFailure);
    }
}
