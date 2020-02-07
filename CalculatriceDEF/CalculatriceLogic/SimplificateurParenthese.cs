using System;
using System.Collections.Generic;



namespace CalculatriceDEF.CalculatriceLogic
{
    class SimplificateurParenthese : ISimplificateurParenthese
    {
        public List<String> Simplifier(List<String> listeIn)
        {
            List<String> listeElement = new List<string>();
            float param;
            int i = 0;
            for (; i < listeIn.Count - 2; i++)
            {
                if (listeIn[i].CompareTo("(") == 0 && float.TryParse(listeIn[i + 1], out param) && listeIn[i + 2].CompareTo(")") == 0)
                {
                    listeElement.Add(listeIn[i + 1]);
                    i = i + 2;
                    continue;
                }
                listeElement.Add(listeIn[i].ToString());
            }
            for (; i < listeIn.Count; i++)
            {
                listeElement.Add(listeIn[i].ToString());
            }

            return listeElement;
        }
    }
}