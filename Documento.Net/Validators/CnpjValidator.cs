namespace Documento.Net.Validators;

internal class CnpjValidator : IValidator
{
    public bool IsValid(string document)
    {
        char[] cnpjCarcteres = document.ToCharArray();
        int primeiroDV, segundoDV, somaDv = 0;
        int multiplicador = 6;
        Dictionary<int, int> dictionary = new Dictionary<int, int>();
        try
        {
            for (int i = 0; i <= cnpjCarcteres.Count() - 3; i++)
            {
                if (multiplicador > 9)
                    multiplicador = 2;
                dictionary.Add(i, multiplicador * int.Parse(cnpjCarcteres[i].ToString()));
                if (dictionary.TryGetValue(i, out int value))
                    somaDv += value;

                multiplicador++;
            }

            multiplicador = 5;
            primeiroDV = somaDv % 11;
            dictionary.Clear();

            if (primeiroDV.ToString() == cnpjCarcteres[12].ToString())
            {
                for (int i = 0; i <= cnpjCarcteres.Count() - 2; i++)
                {
                    if (multiplicador > 9)
                        multiplicador = 2;

                    dictionary.Add(i, multiplicador * int.Parse(cnpjCarcteres[i].ToString()));

                    if (dictionary.TryGetValue(i, out int value) && i == 0)
                        somaDv = value;
                    else if (dictionary.TryGetValue(i, out int obj))
                        somaDv += obj;

                    multiplicador++;
                }

                segundoDV = somaDv % 11;

                return segundoDV.ToString() == cnpjCarcteres[13].ToString();
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
