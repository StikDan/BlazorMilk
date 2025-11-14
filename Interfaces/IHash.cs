using System;
using System.Text;
using System.Security.Cryptography;
using BlazorMilk.Models;

namespace BlazorMilk.Interfaces;

    public interface IHash 
    {
        public string CalculateHashData(string nonHashData);
    }