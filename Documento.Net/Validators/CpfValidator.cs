using System;
using System.Collections.Generic;
using System.Linq;

namespace Documento.Net.Validators
{
    internal class CpfValidator : IValidator
    {
        public bool IsValid(string document)
        {
            char[] cpfBase = document.ToCharArray();
            int primeiroDV, segundoDV, somaDv = 0;
            int multiplicador = 10;
            Dictionary<int, int> dictionary = new Dictionary<int, int>();

            try
            {
                for (int i = 0; i < cpfBase.Count() - 2; i++)
                {
                    dictionary.Add(i, multiplicador * int.Parse(cpfBase[i].ToString()));
                    if (dictionary.TryGetValue(i, out int value))
                    {
                        somaDv += value;
                    }
                    multiplicador -= 1;
                }

                primeiroDV = 11 - (somaDv % 11);
                multiplicador = 11;
                dictionary.Clear();
                somaDv = 0;

                if (primeiroDV.ToString() == cpfBase[9].ToString() ||
                    (primeiroDV == 0 && cpfBase[9] == '0') ||
                    (primeiroDV == 1 && cpfBase[9] == '0'))
                {
                    for (int i = 0; i < cpfBase.Count() - 1; i++)
                    {
                        dictionary.Add(i, multiplicador * int.Parse(cpfBase[i].ToString()));

                        if (dictionary.TryGetValue(i, out int value))
                            somaDv += value;

                        multiplicador -= 1;
                    }
                    segundoDV = 11 - (somaDv % 11);

                    if (segundoDV.ToString() == cpfBase[10].ToString() ||
                    (segundoDV == 0 && cpfBase[10] == '0') ||
                    (segundoDV == 1 && cpfBase[10] == '0'))
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
