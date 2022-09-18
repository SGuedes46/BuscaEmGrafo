using System.Collections.Generic;

namespace BuscaGrafo
{
    public class Vertice
    {
        public Vertice(string nome)
        {
            Nome = nome;
            Arestas = new List<Aresta>();
        }

        public string Nome { get; private set; }
        public List<Aresta> Arestas { get; private set; }
        public Status Status { get; set; }
        public Vertice Pai { get; set; }
        public int TempoDescoberta { get; set; }
        public int TempoTermino { get; set; }
        public int Nivel { get; set; }

        public void AdicionarAresta(Vertice destino)
        {
            Arestas.Add(new Aresta(this, destino));
        }

    }

}
