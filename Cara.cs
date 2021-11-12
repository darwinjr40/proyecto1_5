using System;
using System.Collections.Generic;
using System.Drawing;
using OpenTK.Graphics.OpenGL;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace Proyecto1
{
    [JsonObject(MemberSerialization.OptIn)]
    class Cara : IObjeto
    {

        [JsonProperty] protected Punto origen ;
        [JsonProperty] protected Dictionary<string, Punto> lista;
        [JsonProperty] protected Color color;
        [JsonProperty] protected PrimitiveType tipo;
        [JsonProperty] protected Punto rotacion;

        public Cara() : this(new Punto(), PrimitiveType.Quads, new Dictionary<string, Punto>(), Color.Red) { }
        //--------------------------------------------------------------------------------------------------------------------
        public Cara(Punto centro, PrimitiveType tipo) : this(centro, tipo, new Dictionary<string, Punto>(), Color.Red) { }
        //--------------------------------------------------------------------------------------------------------------------
        public Cara(Punto centro, PrimitiveType tipo, Color c) : this(centro, tipo, new Dictionary<string, Punto>(), c) { }
        //--------------------------------------------------------------------------------------------------------------------
        public Cara(Punto centro, Dictionary<string, Punto> x) : this(centro, PrimitiveType.Quads, x, Color.Red) { }
        //--------------------------------------------------------------------------------------------------------------------

        public Cara(Punto centro, PrimitiveType tipo, Dictionary<string, Punto> puntos, Color c)
        {
            lista = puntos;
            origen = centro;
            this.tipo = tipo;
            color = c;
            rotacion = new Punto();
        }
        //--------------------------------------------------------------------------------------------------------------------
        public Cara(Cara cara)
        {
            lista = cara.lista;
            origen = cara.origen;
            this.tipo = cara.tipo;
            color = cara.color;
        }
        //--------------------------------------------------------------------------------------------------------------------

        public Cara(string json)
        {
            string x = new StreamReader(json).ReadToEnd();
            Cara cara = JsonConvert.DeserializeObject<Cara>(x);
            this.lista = cara.lista;
            this.origen = cara.origen;
            this.tipo = cara.tipo;
            this.color = cara.color;
            this.rotacion = cara.rotacion;
        }
        //--------------------------------------------------------------------------------------------------------------------

        public void Adicionar(string name, Punto x)
        {
            if (lista.ContainsKey(name))
                lista.Remove(name);
            lista.Add(name, x);
        }
        //--------------------------------------------------------------------------------------------------------------------
        public void cargarAutomatico()
        {
            Adicionar("1", new Punto(-10, -10, 0));
            Adicionar("2", new Punto(-10, 10, 0));
            Adicionar("3", new Punto(10, 10, 0));
            Adicionar("4", new Punto(10, -10, 0));
        }
        //--------------------------------------------------------------------------------------------------------------------
        public Punto Get(string name)
        {
            return (lista.ContainsKey(name)) ? lista[name] : null;
        }
        //--------------------------------------------------------------------------------------------------------------------
        public void Dibujar()
        {
            GL.LoadIdentity();
            GL.Translate(origen.x, origen.y, origen.z);
            GL.Rotate(rotacion.x, 1, 0, 0);
            GL.Rotate(rotacion.y, 0, 1, 0);
            GL.Rotate(rotacion.z, 0, 0, 1);
            GL.Translate(-origen.x, -origen.y, -origen.z);

            GL.Begin(tipo); //tipo de figura
              GL.Color4(color); //color de la cara
                foreach (KeyValuePair<string, Punto> vertice in lista)  //dibujar los vertices
                  GL.Vertex3(origen.x + vertice.Value.x, origen.y + vertice.Value.y, origen.z + vertice.Value.z);
            GL.End();
        }
        //--------------------------------------------------------------------------------------------------------------------
        public void Rotar(float x, float y, float z)
        {
            rotacion.x += x;
            rotacion.y += y;
            rotacion.z += z;
        }
        //--------------------------------------------------------------------------------------------------------------------
        public void Rotar(float x, float y, float z, Punto origen)
        {
            this.origen = origen;
            Rotar(x, y, z);
        }

        public void Escalar(float x, float y, float z)
        {
            foreach (KeyValuePair<string, Punto> punto in lista)
            {
                if (x > 0) punto.Value.x *= x;
                if (y > 0) punto.Value.y *= y;
                if (z > 0) punto.Value.z *= z;
            }
        }
        /*
         * escalar entre x >0 && x <=1
         * si es 1 no pasa nada es el mismo
         * si es entre x >0 && x <=1 se hara mas pequeño el objeto
         * valor x, y, z
         * 
         * */
        //--------------------------------------------------------------------------------------------------------------------
        public void Trasladar(float x, float y, float z)
        {
            origen.x += x;
            origen.y += y;
            origen.z += z;
        }
    }
}
