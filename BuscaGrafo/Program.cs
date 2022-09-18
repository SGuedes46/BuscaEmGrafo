using System;
using System.Collections.Generic;

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
            //Console.WriteLine("Quantos Vertices tem o grafo? ");
            //int qtdVertices = int.Parse(Console.ReadLine());
            //Console.WriteLine("Quantas Arestas tem o grafo? ");
            //int qtdArestas = int.Parse(Console.ReadLine());
            Console.WriteLine("O grafo é direcionado? (S/N) ");
            var res = Console.ReadLine();
            if (res == "S" || res == "s")
                grafo.grafoDirecionado = true;
            else
                grafo.grafoDirecionado = false;

            //Console.Clear();
            //Console.ForegroundColor = ConsoleColor.Yellow;
            //Console.WriteLine("=====Informe os Vertices=====");
            //Console.ForegroundColor = ConsoleColor.White;

            //for (int i = 0; i < qtdVertices; i++)
            //{
            //    Console.WriteLine("Informe o nome do {0}º vértice: ", i + 1); ;
            //    string nomeVertice = Console.ReadLine();
            //    try { grafo.AdicionarVertice(nomeVertice); }
            //    catch (Exception e)
            //    {
            //        Console.ForegroundColor = ConsoleColor.Red;
            //        Console.WriteLine(e.Message);
            //        Console.ForegroundColor = ConsoleColor.White;
            //        i--;
            //    }
            //}

            //Console.Clear();
            //Console.ForegroundColor = ConsoleColor.Yellow;
            //Console.WriteLine("=====Informe as Arestas=====");
            //Console.ForegroundColor = ConsoleColor.White;

            //for (int i = 0; i < qtdArestas; i++)
            //{
            //    Console.WriteLine("Informe a {0}º aresta usando um espaço entre origem e destino ex: (A B): ", i + 1);
            //    string[] aresta = Console.ReadLine().Split(' ');
            //    string origem = aresta[0];
            //    string destino = aresta[1];
            //    try { grafo.AdicionarAresta(origem, destino); }
            //    catch (Exception e)
            //    {
            //        Console.ForegroundColor = ConsoleColor.Red;
            //        Console.WriteLine(e.Message);
            //        Console.ForegroundColor = ConsoleColor.White;
            //        i--;
            //    }
            //}



            grafo.AdicionarVertice("A");
            grafo.AdicionarVertice("B");
            grafo.AdicionarVertice("C");
            grafo.AdicionarVertice("D");
            grafo.AdicionarVertice("E");

            grafo.AdicionarAresta("A", "B");
            grafo.AdicionarAresta("C", "D");
            grafo.AdicionarAresta("B", "C");
            
            

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("=====Busca em Profundidade=====");
            Console.ForegroundColor = ConsoleColor.White;

            grafo.BuscaProfundidade();

            Console.WriteLine("\n\n|Vertice|TD\t|TT\t|Pai");
            foreach (var vertice in grafo.Vertices)
            {
                Console.WriteLine("|   {0}\t|{1}\t|{2}\t|{3}", vertice.Nome, vertice.TempoDescoberta, vertice.TempoTermino, vertice?.Pai?.Nome);
            }

            foreach (var vertice in grafo.Vertices)
            {
                Console.Write("\nVertice: {0}", vertice.Nome + " => ");
                Console.Write("Aresta: (");
                foreach (var aresta in vertice.Arestas)
                {
                    Console.Write(" {0}", aresta.Destino.Nome);
                }
                Console.WriteLine(" )");
            }

            Console.ReadKey();
            
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("=====Busca em Largura=====");
            Console.ForegroundColor = ConsoleColor.White;
            
            Console.WriteLine("Por qual vertice quer iniciar a busca? ");



            while (true)
            {
                string verticeInicial = Console.ReadLine();
                try
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("=====Busca em Largura=====");
                    Console.ForegroundColor = ConsoleColor.White;
                    grafo.BuscaEmLargura(verticeInicial);
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

            Console.WriteLine("\n\n|Vertice|Nivel\t|Largura|Pai");
            foreach (var vertice in grafo.Vertices)
            {
                Console.WriteLine("|   {0}\t|{1}\t|{2}\t|{3}", vertice.Nome, vertice.Nivel, vertice.TempoDescoberta, vertice?.Pai?.Nome);
            }

            foreach (var vertice in grafo.Vertices)
            {
                Console.Write("\nVertice: {0}", vertice.Nome + " => ");
                Console.Write("Aresta: (");
                foreach (var aresta in vertice.Arestas)
                {
                    Console.Write(" {0}", aresta.Destino.Nome);
                }
                Console.WriteLine(" )");
            }

            Console.ReadKey();

        }
    }

}


