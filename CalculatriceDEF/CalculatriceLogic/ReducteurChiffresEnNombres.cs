using System;
using System.Collections.Generic;

namespace CalculatriceDEF.CalculatriceLogic
{
    class ReducteurChiffresEnNombres
    {

        public List<String> Reduire(String s)
        {
            List<String> listeElement = new List<string>();
            bool estParam = false;
            bool apresVirgule = false;
            bool negatif = false;
            float param = 0F;
            float baseDecimal = 0.1F;
            int i = 0;
            if (s[0] == '-')
            {
                negatif = true;
                i++;
            }
                
            for (; i < s.Length; i++)
            {

                if (Char.IsNumber(s[i])) // detecté le debut d'un parametre 
                {
                    estParam = true;
                }
                else
                {
                    if (i>0 && s[i] == '-' && !Char.IsNumber(s[i-1]) && (s[i - 1]!=')' || s[i - 1] == '('))
                    {
                        negatif = true;
                        continue;
                    }
                }

                if (s[i] == ',')
                {
                    apresVirgule = true;
                    continue;
                }
                if (estParam) // reduction des parametre 
                {
                    if (apresVirgule)
                    {
                        param = param + float.Parse(s[i].ToString()) * baseDecimal;
                        baseDecimal = baseDecimal / 10.0F;
                    }
                    else
                    {
                        param = param * 10 + float.Parse(s[i].ToString());
                    }

                    if (i == s.Length - 1 || (!Char.IsNumber(s[i + 1]) && s[i + 1] != ','))
                    {
                        if (negatif) param = -1 * param;
                        listeElement.Add(param.ToString());
                        estParam = false;
                        apresVirgule = false;
                        baseDecimal = 0.1F;
                        param = 0;
                        negatif = false;
                    }
                    continue;
                }

                listeElement.Add(s[i].ToString());
            }

            return listeElement;
        }
    }
}