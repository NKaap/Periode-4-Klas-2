using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization;

public class LocalizationLanguageChanger : MonoBehaviour
{
    public void SetSelectedLocale(Locale locale)
    {
        LocalizationSettings.SelectedLocale = locale;
    }

    public void ChangeToDutch()
    {
        SetSelectedLocale(LocalizationSettings.AvailableLocales.Locales[0]);
    }

    public void ChangeToEnglish()
    {
        SetSelectedLocale(LocalizationSettings.AvailableLocales.Locales[1]);
    }

}