using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1
{
    class Escenario: IObjeto 
    {
        protected Dictionary<string, Objeto> lista;

        public Escenario()
        {
          lista = new Dictionary<string, Objeto>();
        }

        public void Adicionar(string name,Objeto x)
        {
            if (lista.ContainsKey(name)) { lista.Remove(name); }
            lista.Add(name, x);
        }

        public void Dibujar()
        {
            foreach (KeyValuePair<string, Objeto> v in lista)
            {
                v.Value.Dibujar();
            }

        }

        public void Rotar(float x, float y, float z)
        {
            foreach (KeyValuePair<string, Objeto> v in lista)
            {
                v.Value.Rotar(x, y, z);
            }
        }

        public void Trasladar(float x, float y, float z)
        {
            foreach (KeyValuePair<string, Objeto> v in lista)
            {
                v.Value.Trasladar(x, y, z);
            }

        }

        public void Escalar(float x, float y, float z)
        {
            foreach (KeyValuePair<string, Objeto> objeto in lista)
                objeto.Value.Escalar(x, y, z);
        }

    }
}
