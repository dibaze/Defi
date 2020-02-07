using System;
using Unity;
using CalculatriceDEF.CalculatriceLogic;

namespace CalculatriceDEF
{
    public class ServiceCalculatrice
    {
        public String Calculer(string input)
        {
            var container = new UnityContainer();

            container.RegisterType<ISimplificateurParenthese, SimplificateurParenthese>();
            container.RegisterType<IMoteurCalculBase, MoteurCalculBase>();
            var calcul = container.Resolve<Calculatrice>();
            
            return calcul.Calculer(input);
        }
    }
}