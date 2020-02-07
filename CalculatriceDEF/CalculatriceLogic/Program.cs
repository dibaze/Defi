using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace CalculatriceDEF.CalculatriceLogic
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Calculer("((1,2)*(-2+1))"));
            Console.ReadLine();
            var container = new UnityContainer();

            container.RegisterType<ISimplificateurParenthese, SimplificateurParenthese>();
            container.RegisterType<IMoteurCalculBase, MoteurCalculBase>();
            var calcul = container.Resolve<Calculatrice>();
            Console.WriteLine(calcul.Calculer("1+2"));
            Console.ReadLine();

        }

        public static String Calculer(String s)
        {
            List<String> listElement = ReduireChiffresEnNombres(s);

            while (listElement.Count > 1)
            {
                listElement = SimplificateurParenthese(listElement);
                listElement = CalculateurBasique(listElement);
            }

            return listElement[0];
        }

        public static List<String> ReduireChiffresEnNombres(String s)
        {
            List<String> listeElement = new List<string>();
            bool estParam = false;
            bool apresVirgule = false;
            float param = 0F;
            float baseDecimal = 0.1F;
            for (int i = 0; i < s.Length; i++)
            {

                if (Char.IsNumber(s[i])) // detecté le debut d'un parametre 
                {
                    estParam = true;
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

                    if (i < s.Count() && !Char.IsNumber(s[i + 1]) && s[i + 1] != ',')
                    {
                        listeElement.Add(param.ToString());
                        estParam = false;
                        apresVirgule = false;
                        baseDecimal = 0.1F;
                        param = 0;
                    }
                    continue;
                }

                listeElement.Add(s[i].ToString());
            }

            return listeElement;
        }

        public static List<String> CalculateurBasique(List<String> listeIn)
        {
            List<String> listeOut = new List<string>();
            int i = 0;
            float temp;
            for (; i < listeIn.Count - 2; i++)
            {
                if (IsOpearteurUnaire(listeIn[i]))
                {
                    listeOut.Add(listeIn[i] + listeIn[i + 1]);
                    i++;
                    continue;
                }
                if (listeIn[i].CompareTo(")") != 0 && listeIn[i].CompareTo("(") !=0 && IsOpearteurBinaire(listeIn[i + 1]) && float.TryParse(listeIn[i + 2],out temp))
                {
                    listeOut.Add(ExecuteurOperateur(listeIn[i], listeIn[i + 1], listeIn[i + 2]));
                    i = i + 2;
                    continue;
                }
                listeOut.Add(listeIn[i].ToString());
            }
            for (; i < listeIn.Count; i++)
            {
                listeOut.Add(listeIn[i].ToString());
            }
            return listeOut;
        }

        public static List<String> SimplificateurParenthese(List<String> listeIn)
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
        private static bool IsOpearteurUnaire(String s)
        {
            return s.CompareTo("-") == 0;
        }
        private static bool IsOpearteurBinaire(String s)
        {
            return new List<String> { "+", "-", "/", "*" }.Contains(s);
        }
        private static String ExecuteurOperateur(String param1, String op, String param2)
        {

            switch (op)
            {
                case "+":
                    return (float.Parse(param1) + float.Parse(param2)).ToString();
                case "-":
                    return (float.Parse(param1) - float.Parse(param2)).ToString();
                case "*":
                    return (float.Parse(param1) * float.Parse(param2)).ToString();
                case "/":
                    return (float.Parse(param1) / float.Parse(param2)).ToString();
            }
            return "";
        }
    }
}
