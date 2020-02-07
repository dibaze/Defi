using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculatriceDEF.CalculatriceLogic
{
    public class AnalyseurSyntaxique : IAnalyseurSyntaxique
    {
        public string Analyser(string s) // liste de verification syntaxique espace virgule expression reguliére ... 
        {
            var mots = s.Split(' ');
            String sOut = "";
            foreach (String mot in mots)
            {
                sOut += mot;
            }

            return sOut.Replace('.', ',');
        }
    }
}
