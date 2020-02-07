using System;
using System.Collections.Generic;

namespace CalculatriceDEF.CalculatriceLogic
{
    class ExecuteurOperationBasique
    {
        private IMoteurCalculBase aMoteurCalculBase;

        public ExecuteurOperationBasique(IMoteurCalculBase pMoteurCalculBase)
        {
            aMoteurCalculBase = pMoteurCalculBase;
        }
        

        public  List<String> Executer (List<String> listeIn)
        {
            List<String> listeOut = new List<string>();
            int i = 0;
            float temp;
            for (; i < listeIn.Count - 2; i++)
            {

                if (listeIn[i].CompareTo(")") != 0 && listeIn[i].CompareTo("(") != 0 && aMoteurCalculBase.IsOpearteurBinaire(listeIn[i + 1]) && float.TryParse(listeIn[i + 2], out temp))
                {

                    if (i < listeIn.Count - 4 && aMoteurCalculBase.IsOpearteurBinaire(listeIn[i + 3]) && aMoteurCalculBase.IsOperationPrioritaire(listeIn[i + 3], listeIn[i + 1]))
                    {
                        listeOut.Add(listeIn[i]);
                        listeOut.Add(listeIn[i + 1]);
                        listeOut.Add(ExecuteurOperateur(listeIn[i + 2], listeIn[i + 3], listeIn[i + 4]));
                        i = i + 5;
                        break;
                    }
                    else
                    {
                        listeOut.Add(ExecuteurOperateur(listeIn[i], listeIn[i + 1], listeIn[i + 2]));
                        i = i + 3;
                        break;
                    }
                }
                
                listeOut.Add(listeIn[i].ToString());
            }
            for (; i < listeIn.Count; i++)
            {

                listeOut.Add(listeIn[i].ToString());
            }
            return listeOut;
        }

        private String ExecuteurOperateur(String param1, String op, String param2)
        {
            
                switch (op)
                {
                    case Constantes.Addition:
                        return (aMoteurCalculBase.Additioner(float.Parse(param1), float.Parse(param2))).ToString();
                    case Constantes.Soustraction:
                        return (aMoteurCalculBase.Soustraire(float.Parse(param1), float.Parse(param2))).ToString();
                    case Constantes.Multiplication:
                        return (aMoteurCalculBase.Multiplier(float.Parse(param1), float.Parse(param2))).ToString();
                    case Constantes.Division:
                        return (aMoteurCalculBase.Diviser(float.Parse(param1), float.Parse(param2))).ToString();
                    case Constantes.Puissance:
                        return (aMoteurCalculBase.Puissance(float.Parse(param1), float.Parse(param2))).ToString();
                }
            
            return "";
        }


    }
}