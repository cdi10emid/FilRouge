using ClassAccesData;
using ClassMetier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            AccesOffre accesOffre = new AccesOffre();
            List<Offre> offre = accesOffre.AfficheOffreByIdPoste(1);
            Console.Read();
        }
    }
}
