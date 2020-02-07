using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatriceDEF.CalculatriceLogic
{
    class MoteurCalculBase : IMoteurCalculBase
    {
        public MoteurCalculBase()
        {

        }
        public bool IsOpearteurUnaire(String s)
        {
            return s.CompareTo("-") == 0;
        }
        public bool IsOpearteurBinaire(String s)
        {
            return new List<String> { Constantes.Addition,
                                      Constantes.Soustraction,
                                      Constantes.Multiplication,
                                      Constantes.Division,
                                      Constantes.Puissance}.Contains(s);
        }
        public bool IsOperationPrioritaire(string oper1, string oper2) // test si oper1 est plus prioritaire que oper2
        {
            Dictionary<String, int> dictioPriorite = new Dictionary<string, int>();
            dictioPriorite.Add("^", 0);
            dictioPriorite.Add("*", 1);
            dictioPriorite.Add("/", 1);
            dictioPriorite.Add("+", 2);
            dictioPriorite.Add("-", 2);

            return dictioPriorite[oper1] < dictioPriorite[oper2];
        }
        public float Additioner(float param1, float param2)
        {
            return param1 + param2;
        }
        public float Soustraire(float param1, float param2)
        {
            return param1 - param2;
        }
        public float Multiplier(float param1, float param2)
        {
            return param1 * param2;
        }

        public float Diviser(float param1, float param2)
        {
            if (param2 == 0) throw new Exception(Constantes.MsgErrDivZero);

            return param1 / param2;
        }
        public float Puissance(float param1, float param2)
        {
            return (float)Math.Pow(param1, param2);
        }
        


    }
}
