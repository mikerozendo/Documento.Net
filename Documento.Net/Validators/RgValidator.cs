using System;
using System.Collections.Generic;
using System.Linq;

namespace Documento.Net.Validators
{
    internal class RgValidator : IValidator
    {
        public bool IsValid(string document)
        {
            char[] rgBase = document.ToCharArray();
            int resultadoDv, somaDv = 0;
            Dictionary<int, int> dictionary = new Dictionary<int, int>();

            try
            {
                for (int i = 0; i < rgBase.Count() - 1; i++)
                {
                    dictionary.Add(i, (i + 2) * int.Parse(rgBase[i].ToString()));

                    if (dictionary.TryGetValue(i, out int value))
                        somaDv += value;
                }

                resultadoDv = 11 - (somaDv % 11);

                if ((rgBase.Last() == 'X' && resultadoDv == 10) ||
                    (rgBase.Last() != 'X' && rgBase.Last() != '0' && rgBase.Last().ToString() == resultadoDv.ToString()) ||
                    (rgBase.Last() == '0' && resultadoDv == 11))
                    return true;
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
