using System;

namespace Yacaa.Shared.Models
{
    public class Contract
    {
        public string Number { get; set; }
        public string Date { get; set; }
        public string ContractType { get; set; }
        public string Currency { get; set; }
        public string ValidUntil { get; set; }
        public string Prolongation { get; set; }
        public string ProlongationTerms { get; set; } = null;

        public Contract(string number, string date, string contractType, string currency, string validUntil, string prolongation, string prolongationTerms)
        {
            Number = number;
            Date = date;
            ContractType = contractType;
            Currency = currency;
            ValidUntil = validUntil;
            Prolongation = prolongation;
            ProlongationTerms = prolongationTerms;
        }

        public Contract(string number, string date, string contractType, string currency, string validUntil, string prolongation)
        {
            Number = number;
            Date = date;
            ContractType = contractType;
            Currency = currency;
            ValidUntil = validUntil;
            Prolongation = prolongation;
        }
        
    }
}