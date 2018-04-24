using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using IBM.Watson.DeveloperCloud.Services.LanguageTranslator.v2;
using IBM.Watson.DeveloperCloud.Logging;
using IBM.Watson.DeveloperCloud.Utilities;
using IBM.Watson.DeveloperCloud.Connection;

public class LanguageTranslatorTest : MonoBehaviour
{
    public Text textField;

    private LanguageTranslator _languageTranslator;
    private string _translationModel = "en-es";


    void Start()
    {
        LogSystem.InstallDefaultReactors();

        Credentials languageTranslatorCredentials = new Credentials()
        {
            Url = "https://gateway.watsonplatform.net/language-translator/api",
            Username = "ffd95e0e-4b93-41ad-ab93-fe2ebe05e214",
            Password = "FOcwszjTIloh"
        };

        _languageTranslator = new LanguageTranslator(languageTranslatorCredentials);


	}

    public void Translate(string text){
        _languageTranslator.GetTranslation(OnTranslate, OnFail, text, _translationModel);
    }

    private void OnTranslate(Translations response, Dictionary<string, object> customData){
        textField.text = response.translations[0].translation;
    }

    private void OnFail(RESTConnector.Error error, Dictionary<string, object> customData){
        Log.Debug("LanguageTranslatorDemo.OnFail()", "Error: {0}", error.ToString());
    }

}
