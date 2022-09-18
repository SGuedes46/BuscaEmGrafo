using System;
using System.Collections.Generic;
using System.Linq;

namespace BuscaGrafo
{
    public class Grafo
    {
        private readonly Dictionary<string, Vertice> _vertices = new Dictionary<string, Vertice>();
        public bool grafoDirecionado;

        public void AdicionarVertice(string nome)
        {
            if (_vertices.ContainsKey(nome))
                throw new Exception("Vertice já existe");

            _vertices.Add(nome, new Vertice(nome));
        }

        public void AdicionarAresta(string origem, string destino)
        {
            if (!_vertices.ContainsKey(origem))
            {
                throw new Exception("Vertice de origem não existe");
            }
            else
            {
                if (!_vertices.ContainsKey(destino))

                {

                    throw new Exception("Vertice de destino não existe");
                }
                else
                {
                    if (grafoDirecionado)
                        _vertices[origem].AdicionarAresta(_vertices[destino]);
                    else
                    {
                        _vertices[origem].AdicionarAresta(_vertices[destino]);
                        _vertices[destino].AdicionarAresta(_vertices[origem]);
                    }
                }
            }
        }

        public void BuscaProfundidade()
        {
            foreach (var vertice in _vertices.Values)
            {
                vertice.Status = Status.NaoVisitado;
                vertice.Pai = null;
            }

            var tempo = 0;
            foreach (var vertice in _vertices.Values)
            {
                if (vertice.Status == Status.NaoVisitado)
                    tempo = BuscaProfundidadeVisit(vertice, tempo);
            }
        }

        private int BuscaProfundidadeVisit(Vertice vertice, int tempo)
        {
            tempo++;
            vertice.TempoDescoberta = tempo;
            vertice.Status = Status.Visitado;

            foreach (var aresta in vertice.Arestas)
            {
                if (aresta.Destino.Status == Status.NaoVisitado)
                {
                    aresta.Destino.Pai = vertice;
                    tempo = BuscaProfundidadeVisit(aresta.Destino, tempo);
                }
            }

            vertice.Status = Status.Explorado;
            tempo++;
            vertice.TempoTermino = tempo;
            return tempo;
        }

        public void BuscaEmLargura(string nome)
        {
            foreach (var v in _vertices.Values)
            {
                v.Status = Status.NaoVisitado;
                v.Pai = null;
                v.Nivel = 0;
                v.TempoDescoberta = 0;
            }

            int td;   
            var vertice = _vertices[nome];
            Console.Write("Fila: ");
            while (vertice != null)
            {

                td = 1;
                vertice.Status = Status.Visitado;
                vertice.TempoDescoberta = td;
                vertice.Nivel = 0;

                var fila = new Queue<Vertice>();

                Console.Write(" {0}", vertice.Nome);
                fila.Enqueue(vertice);

                while (fila.Count > 0)
                {
                    var v = fila.Dequeue();
                    foreach (var aresta in v.Arestas)
                    {
                        if (aresta.Destino.Status == Status.NaoVisitado)
                        {
                            aresta.Destino.Status = Status.Visitado;
                            aresta.Destino.TempoDescoberta = ++td;
                            aresta.Destino.Nivel = v.Nivel + 1;
                            aresta.Destino.Pai = v;
                            Console.Write(", {0}", aresta.Destino.Nome);
                            fila.Enqueue(aresta.Destino);
                        }
                    }

                    v.Status = Status.Explorado;
                }
                vertice = _vertices.Values.FirstOrDefault(v => v.Status == Status.NaoVisitado);
                if (vertice != null)
                    Console.Write(",");
            }


        }

        public IEnumerable<Vertice> Vertices
        {
            get { return _vertices.Values; }
        }

    }
}
