using ComponentesTiendaMVC.Models;

namespace ComponentesTiendaMVC.Services
{
    public class FakeRepositorioOrdenadores : IRepositorioOrdenadores
    { 
        public readonly List<Ordenador> misOrderadores = new();
        public FakeRepositorioOrdenadores()
        {
            misOrderadores.Add(new Ordenador()
            {
                DescripcionOrdenador = "Ordenador Fake 1",
                IdOrdenador = 1
            });
            misOrderadores.Add(new Ordenador()
            {
                DescripcionOrdenador = "Ordenador Fake 2",
                IdOrdenador = 2
            });
            misOrderadores.Add(new Ordenador()
            {
                DescripcionOrdenador = "Ordenador Fake 3",
                IdOrdenador = 3
            });

        }


        public void EditOrdenador(Ordenador ordenador)
        {
            var OrdenadorAEditar = TomaOrdenador(ordenador.IdOrdenador);
            if (OrdenadorAEditar != null)
            {
                OrdenadorAEditar.DescripcionOrdenador = ordenador.DescripcionOrdenador;

            }
        }



        public void AddOrdenador(Ordenador ordenador)
        {
            var ultimoNumero = misOrderadores.Count;
            ordenador.IdOrdenador = ultimoNumero;
            misOrderadores.Add(ordenador);
       }

        public void BorraOrdenador(int Id)
        {
            misOrderadores.RemoveAll(x => x.IdOrdenador == Id);
        }


        public List<Ordenador> ListaOrdenadores()
        {
            return misOrderadores;
        }

        public List<Componente> ObtenerComponentesPorOrdenador(int ordenadorId)
        {
            throw new NotImplementedException();
        }

        public Componente TomaComponente(int id)
        {
            throw new NotImplementedException();
        }

        public Ordenador TomaOrdenador(int Id)
        {
            return misOrderadores.Find(x => x.IdOrdenador == Id);
        }

       
    }
}
