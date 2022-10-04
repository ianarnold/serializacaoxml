using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Xml.Serialization;

namespace ClienteEnvia
{
    class Program
    {
        static void Main(string[] args)
        {
            OcorrenciaPonto pnt = new OcorrenciaPonto();
            List<OcorrenciaPonto> pontos = new List<OcorrenciaPonto>();
            XmlSerializer obj = new XmlSerializer(pontos.GetType());
            TextWriter arquivo = new StreamWriter("teste.xml");
            string linha;
            StreamReader file = new StreamReader("abril2017.txt");
            linha = file.ReadLine();
            while (linha != null)
            {
                
                pnt.prontuario = linha.Substring(0, 15);
                pnt.data = linha.Substring(15, 6);
                pnt.hora = linha.Substring(21, 4);
                pnt.filler = linha.Substring(25, 8);
                Console.WriteLine(linha);
                linha = file.ReadLine();
               
                pontos.Add(pnt);

            }
            obj.Serialize(arquivo, pontos);

            arquivo.Close();

            Console.ReadKey();

        }
    }
}
