namespace BuscaGrafo
{
    public class Aresta
    {
        public Aresta(Vertice origem, Vertice destino)
        {
            Origem = origem;
            Destino = destino;
        }

        public Vertice Origem { get; private set; }
        public Vertice Destino { get; private set; }
    }

    public enum Status
    {
        NaoVisitado,
        Visitado,
        Explorado
    }

}
