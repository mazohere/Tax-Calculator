using UnityEngine;
using SpeechLib;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class TaxCalculator : MonoBehaviour
{

    public InputField GetGrossSalaryText;
    public Dropdown GetSalaryPayPeriodText;
    public Text NetIncomeText;
    public Text TaxPaidText;
    public Text MedicareLevyText;

    // Constant rate for the Medicare Levy
    const double MEDICARE_LEVY = 0.02;

    // Variables
    bool textToSpeechEnabled = true;

    private void Start()
    {
        Speak("Welcome to the A.T.O. Tax Calculator");
    }

    // Run this function on the click event of your 'Calculate' button
    public void Calculate()
    {
        // Initialisation of variables
        double medicareLevyPaid = 0;
        double incomeTaxPaid = 0;

        // Input
        double grossSalaryInput = GetGrossSalary();
        string salaryPayPeriod = GetSalaryPayPeriod();

        // Calculations
        double grossYearlySalary = CalculateGrossYearlySalary(grossSalaryInput, salaryPayPeriod);
        double netIncome = CalculateNetIncome(grossYearlySalary, ref medicareLevyPaid, ref incomeTaxPaid);

        // Output
        OutputResults(medicareLevyPaid, incomeTaxPaid, netIncome);
    }

    private double GetGrossSalary()
    {
        double grossYearlySalary;
        if (double.TryParse(GetGrossSalaryText.text, out double getGrossYearlySalary))
        {
            grossYearlySalary = Convert.ToDouble(GetGrossSalaryText.text);
        }
        else 
        {
            grossYearlySalary = 0;
        }
        return grossYearlySalary;
    }

    private string GetSalaryPayPeriod()
    {
        string salaryPayPeriod;
        if (GetSalaryPayPeriodText.value == 0)
        {
            salaryPayPeriod = "weekly";
        } else if (GetSalaryPayPeriodText.value == 1)
        {
            salaryPayPeriod = "fortnightly";
        } else if (GetSalaryPayPeriodText.value == 2)
        {
            salaryPayPeriod = "monthly";
        } else
        {
            salaryPayPeriod = "yearly";
        }
        return salaryPayPeriod;
    }

    private double CalculateGrossYearlySalary(double grossSalaryInput, string salaryPayPeriod)
    {
        if (salaryPayPeriod == "weekly")
        {
            return (grossSalaryInput * 52);
        }
        else if (salaryPayPeriod == "fortnightly")
        {
            return (grossSalaryInput * 26);
        }
        else if (salaryPayPeriod == "monthly")
        {
            return (grossSalaryInput * 12);
        }
        else 
        {
            return grossSalaryInput;
        }
    }

    private double CalculateNetIncome(double grossYearlySalary, ref double medicareLevyPaid, ref double incomeTaxPaid)
    {
        medicareLevyPaid = CalculateMedicareLevy(grossYearlySalary);
        incomeTaxPaid = CalculateIncomeTax(grossYearlySalary);

        return (grossYearlySalary - medicareLevyPaid - incomeTaxPaid);
    }

    private double CalculateMedicareLevy(double grossYearlySalary)
    {
        return(grossYearlySalary * 0.02);
    }

    private double CalculateIncomeTax(double grossYearlySalary)
    {
        if (grossYearlySalary < 18200)
        {
            return(0);
        }
        else if (grossYearlySalary < 37000)
        {
            return(0.19 * (grossYearlySalary - 18200));
        }
        else if (grossYearlySalary < 87000)
        {
            return(3572 + 0.325 * (grossYearlySalary - 37000));
        }
        else if (grossYearlySalary < 180000)
        {
            return(19822 + 0.37 * (grossYearlySalary - 87000));
        }
        else
        {
            return(54232 + 0.45 * (grossYearlySalary - 180000));

        }

    }

    private void OutputResults(double medicareLevyPaid, double incomeTaxPaid, double netIncome)
    {
        if (netIncome == 0)
        {
            NetIncomeText.color = Color.red;
            MedicareLevyText.color = Color.red;
            TaxPaidText.color = Color.red;
            NetIncomeText.text = "pootis";
            MedicareLevyText.text = "pootis";
            TaxPaidText.text = "pootis";
        }
        else
        {
            NetIncomeText.color = Color.black;
            MedicareLevyText.color = Color.black;
            TaxPaidText.color = Color.black;
            NetIncomeText.text = Convert.ToString("$" + netIncome);
            MedicareLevyText.text = Convert.ToString("$" + medicareLevyPaid);
            TaxPaidText.text = Convert.ToString("$" + incomeTaxPaid);
        }
    }

    // Text to Speech
    private void Speak(string textToSpeak)
    {
        if(textToSpeechEnabled)
        {
            SpVoice voice = new SpVoice();
            voice.Speak(textToSpeak);
        }
    }
}
