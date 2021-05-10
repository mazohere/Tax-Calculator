using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Language : MonoBehaviour
{

    public InputField GetGrossSalaryText;
    public Dropdown GetSalaryPayPeriodText;
    public Text NetIncomeText;
    public Text TaxPaidText;
    public Text MedicareLevyText;
    public Dropdown GetLanguage;
    public Text Timeframe;
    public Text GrossIncome;

    public void MakeLanguage() 
    {
        if (GetLanguage.value == 0)
        {
            Timeframe.text = "Timeframe: ";
            GrossIncome.text = "GrossIncome: ";
            GetSalaryPayPeriodText.te
            //etc
        }
        else if (GetLanguage.value == 1)
        {
            Timeframe.text = "periodo de tiempo: ";
            GrossIncome.text = "Ingresos brutos: ";
            //etc 

            GetSalaryPayPeriodText.options.Clear();
            GetSalaryPayPeriodText.options.Add(new Dropdown.OptionData() { text = "Semanal" });
            GetSalaryPayPeriodText.options.Add(new Dropdown.OptionData() { text = "Quincenal" });
            GetSalaryPayPeriodText.options.Add(new Dropdown.OptionData() { text = "Mensual" });
            GetSalaryPayPeriodText.options.Add(new Dropdown.OptionData() { text = "Anual" });

        }
    }
}
