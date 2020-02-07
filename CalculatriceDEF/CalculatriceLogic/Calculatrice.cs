using System;
using System.Collections.Generic;


namespace CalculatriceDEF.CalculatriceLogic
{
    class Calculatrice
    {
        
        private SimplificateurParenthese aSimplificateurParenthese;
        private ExecuteurOperationBasique aCalculateurBasique;
        private ReducteurChiffresEnNombres aReduireChiffresEnNombres;
        private AnalyseurSyntaxique aAnalyseurSyntaxique;

        public Calculatrice(SimplificateurParenthese pSimplificateurParenthese,
                            ExecuteurOperationBasique pCalculateurBasique,
                            ReducteurChiffresEnNombres pReduireChiffresEnNombres,
                            AnalyseurSyntaxique pAnalyseurSyntaxique)
        {
            aSimplificateurParenthese = pSimplificateurParenthese;
            aCalculateurBasique = pCalculateurBasique;
            aReduireChiffresEnNombres = pReduireChiffresEnNombres;
            aAnalyseurSyntaxique = pAnalyseurSyntaxique;
        }

        public String Calculer(String s)
        {
            s = aAnalyseurSyntaxique.Analyser(s);
            List<String> listElement = aReduireChiffresEnNombres.Reduire(s);

            while (listElement.Count > 1)
            {
                listElement = aSimplificateurParenthese.Simplifier(listElement);
                try
                {
                    listElement = aCalculateurBasique.Executer(listElement);
                }
                catch(Exception e)
                {
                    return e.Message;
                }
                
            }

            return listElement[0];
        }
    }
}
