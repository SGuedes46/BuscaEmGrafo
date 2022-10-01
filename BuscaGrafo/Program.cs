using System;
using System.IO;

namespace BuscaGrafo
{
    internal class Program
    {

        static void Main(string[] args)
        {


            var grafo = new Grafo();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("=====Informe as propriedades do Grafo=====");
            Console.ForegroundColor = ConsoleColor.White;

            grafo.grafoDirecionado = false;


            string caminho = @"C:\Development\Grafo.txt";
            if (caminho == null)
            {
                Console.WriteLine("Informe o caminho do arquivo");
                caminho = Console.ReadLine();
            }

            string[] lines = File.ReadAllLines(caminho);
            for (int i = 0; i < lines.Length; i++)
            {
                string[] linha = lines[i].Split(',');
                grafo.AdicionarAresta(linha[0], linha[1]);
            }



            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("=====Busca em Profundidade=====");
            Console.ForegroundColor = ConsoleColor.White;

            grafo.BuscaProfundidade();

            string fileName = @"C:\Development\TabelaTempo.html";
            string fileName2 = @"C:\Development\TabelaTempo.txt";
            string fName = @"C:\Development\ListaVertices.html";
            string fName2 = @"C:\Development\ListaVertices.txt";
            string sName = @"C:\Development\ArvoreBusca.html";
            string sName2 = @"C:\Development\ArvoreBusca.txt";

            try
            {
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }

                using (StreamWriter sw = File.CreateText(fileName))
                using (StreamWriter sw2 = File.CreateText(fileName2))
                using (StreamWriter fw = File.CreateText(fName))
                using (StreamWriter fw2 = File.CreateText(fName2))
                {
                    sw.WriteLine("<h1 align='center'>=====Busca em Profundidade=====</h1>");
                    sw2.WriteLine("=====Busca em Profundidade=====");
                    Console.WriteLine("\n\n|Vertice|TD\t|TT\t|Pai");
                    sw2.WriteLine("\n\n|Vertice|TD\t|TT\t|Pai");
                    sw.WriteLine("<p><table border = 1 align='center'><tr><td><h3><b>Vertice</b></h3></td><td><h3><b>TD</b></h3></td><td><h3><b>TT</b></h3></td><td><b><h3><h3><b>Pai</b></h3></td></tr>");
                    foreach (var vertice in grafo.Vertices)
                    {
                        Console.WriteLine("|   {0}\t|{1}\t|{2}\t|{3}", vertice.Nome, vertice.TempoDescoberta, vertice.TempoTermino, vertice?.Pai?.Nome);
                        sw2.WriteLine("|   {0}\t|{1}\t|{2}\t|{3}", vertice.Nome, vertice.TempoDescoberta, vertice.TempoTermino, vertice?.Pai?.Nome);
                        sw.WriteLine("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td></tr>", vertice.Nome, vertice.TempoDescoberta, vertice.TempoTermino, vertice?.Pai?.Nome);
                    }
                    sw.WriteLine("</table></p>");
                    fw.WriteLine("<h1 align='center'>=====Lista Vertices Visitados=====</h1>");
                    fw2.WriteLine("=====Lista Vertices Visitados=====");
                    fw.Write("<span align='center'>");
                    foreach (var vertice in grafo.Vertices)
                    {
                        Console.Write("BP(" + vertice.Nome + ") => (" + vertice.Nome + ") = {");
                        fw2.Write("BP(" + vertice.Nome + ") => ɽ(" + vertice.Nome + ") = {");
                        fw.Write("<p>BP(" + vertice.Nome + ") => ɽ(" + vertice.Nome + ") = {");
                        foreach (var aresta in vertice.Arestas)
                        {
                            Console.Write("  {0}", aresta.Destino.Nome);
                            fw2.Write("  {0}", aresta.Destino.Nome);
                            fw.Write("  {0}", aresta.Destino.Nome);
                        }
                        Console.WriteLine(" }");
                        fw2.WriteLine(" }");
                        fw.WriteLine(" }</p>");
                    }
                    fw.Write("</span>");

                    sw.Close();
                    sw2.Close();
                    fw2.Close();
                    fw.Close();
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }


            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\n\n=====Busca em Largura=====");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Por qual vertice quer iniciar a busca? ");
            string ret = "";
            while (true)
            {
                string verticeInicial = Console.ReadLine();
                try
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\n\n\n=====Busca em Largura=====");
                    Console.ForegroundColor = ConsoleColor.White;
                    ret = grafo.BuscaEmLargura(verticeInicial);
                    break;
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Vertice não encontrado.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Por qual vertice quer iniciar a busca? ");
                }
            }

            try
            {
                if (File.Exists(sName))
                {
                    File.Delete(sName);
                }

                // Create a new file     
                using (StreamWriter sw = File.CreateText(sName))
                using (StreamWriter sw2 = File.CreateText(sName2))
                {
                    sw.WriteLine("<h1 align='center'>=====Busca em Largura=====</h1>");
                    sw.WriteLine("<p><table border = 1 align='center'><tr><td><h3><b>Vertice</b></h3></td><td><h3><b>Nivel</b></h3></td><td><h3><b>Largura</b></h3></td><td><b><h3><h3><b>Pai</b></h3></td></tr>");
                    sw2.WriteLine("=====Busca em Largura=====");
                    Console.WriteLine("\n\n{0}", ret);
                    sw2.WriteLine("\n\n{0}", ret);
                    sw.WriteLine("<p><p>{0}</p></p>", ret);
                    Console.WriteLine("\n\n|Vertice|Nivel\t|Largura|Pai");
                    foreach (var vertice in grafo.Vertices)
                    {
                        Console.WriteLine("|   {0}\t|{1}\t|{2}\t|{3}", vertice.Nome, vertice.Nivel, vertice.TempoDescoberta, vertice?.Pai?.Nome);
                        sw2.WriteLine("|   {0}\t|{1}\t|{2}\t|{3}", vertice.Nome, vertice.Nivel, vertice.TempoDescoberta, vertice?.Pai?.Nome);
                        sw.WriteLine("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td></tr>", vertice.Nome, vertice.Nivel, vertice.TempoDescoberta, vertice?.Pai?.Nome);
                    }
                    sw.WriteLine("</table></p>");
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }

            Console.ReadKey();

        }
    }

}


