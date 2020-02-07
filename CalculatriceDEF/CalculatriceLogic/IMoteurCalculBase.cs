using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatriceDEF.CalculatriceLogic
{
    interface IMoteurCalculBase
    {
        bool IsOpearteurUnaire(String s);

        bool IsOpearteurBinaire(String s);

        bool IsOperationPrioritaire(string oper1, string oper2);

        float Additioner(float param1, float param2);

        float Soustraire(float param1, float param2);

        float Multiplier(float param1, float param2);

        float Diviser(float param1, float param2);

        float Puissance(float param1, float param2);


    }
}
