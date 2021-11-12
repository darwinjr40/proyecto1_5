using Newtonsoft.Json;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1
{
    [JsonObject(MemberSerialization.OptIn)]
    class Objeto : IObjeto
    {
        [JsonProperty] protected Punto origen;
        [JsonProperty] protected float ancho;
        [JsonProperty] protected float alto;
        [JsonProperty] protected float profundidad;
        [JsonProperty] protected Dictionary<string, Cara> lista;

        public Objeto() : this(new Punto(), 10, 10 ,10) { }
        //public Objeto(Punto centro, PrimitiveType tipo) : this(centro, tipo, new Dictionary<string, Punto>(), Color.Red) { }
        public Objeto(Punto origen, float ancho, float alto, float profundidad,  Dictionary<string, Cara> caras) {
            this.origen = origen;
            this.ancho = ancho;
            this.alto = alto;
            this.profundidad = profundidad;
            this.lista = caras;
        }
        public Objeto(Punto origen, float ancho, float alto, float profundidad)
        {
            this.origen = origen;
            this.ancho = ancho;
            this.alto = alto;
            this.profundidad = profundidad;
            this.lista = new Dictionary<string, Cara>();
        }
        //--------------------------------------------------------------------------------------------------------------------
        public Objeto(Objeto objeto)
        {
            this.origen = objeto.origen;
            this.ancho = objeto.ancho;
            this.alto = objeto.alto;
            this.profundidad = objeto.profundidad;
            this.lista = objeto.lista;
        }

        //--------------------------------------------------------------------------------------------------------------------

        public Objeto(string json)
        {
            string x = new StreamReader(json).ReadToEnd();
            Objeto objeto = JsonConvert.DeserializeObject<Objeto>(x);
            this.origen = objeto.origen;
            this.ancho = objeto.ancho;
            this.alto = objeto.alto;
            this.profundidad = objeto.profundidad;
            this.lista = objeto.lista;
        }
        //--------------------------------------------------------------------------------------------------------------------
        public void Adicionar(string name, Cara x)
        {
            if (lista.ContainsKey(name))
                lista.Remove(name);
            lista.Add(name, x);
        }

        public void Dibujar()
        {
            foreach (KeyValuePair<string, Cara> v in lista)
            {
                v.Value.Dibujar();
            }    
        }

        public void Rotar(float x, float y, float z)
        {
            foreach (KeyValuePair<string, Cara> v in lista)
                v.Value.Rotar(x, y, z,  origen);
        }
        public void Escalar(float x, float y, float z)
        {
            foreach (KeyValuePair<string, Cara> cara in lista)
                cara.Value.Escalar(x, y, z);
            
        }
        public void Trasladar(float x, float y, float z)
        {
            foreach (KeyValuePair<string, Cara> v in lista)
                v.Value.Trasladar(x, y, z);

            origen.x += x;
            origen.y += y;
            origen.z += z;
        }
        public void cargarAutomatico()
        {
            Cara c1;
            //DIBUJO LA BASE
            //atras
            c1 = new Cara(origen, PrimitiveType.LineLoop, Color.Pink);
            c1.Adicionar("1", new Punto(-ancho, -alto, -profundidad));
            c1.Adicionar("2", new Punto(-ancho, alto, -profundidad));
            c1.Adicionar("3", new Punto(ancho, alto, -profundidad));
            c1.Adicionar("4", new Punto(ancho, -alto, -profundidad));
            Adicionar("cara2", c1);

            //izquierda
            c1 = new Cara(origen, PrimitiveType.LineLoop, Color.Red);
            c1.Adicionar("1", new Punto(-ancho, -alto, -profundidad));
            c1.Adicionar("2", new Punto(-ancho, alto, -profundidad));
            c1.Adicionar("3", new Punto(-ancho, alto, profundidad));
            c1.Adicionar("4", new Punto(-ancho, -alto, profundidad));
            Adicionar("cara3", c1);

            //derecha
            c1 = new Cara(origen, PrimitiveType.LineLoop, Color.Yellow);
            c1.Adicionar("1", new Punto(ancho, -alto, profundidad));
            c1.Adicionar("2", new Punto(ancho, alto, profundidad));
            c1.Adicionar("3", new Punto(ancho, alto, -profundidad));
            c1.Adicionar("4", new Punto(ancho, -alto, -profundidad));
            Adicionar("cara4", c1);

            //superior
            c1 = new Cara(origen, PrimitiveType.LineLoop, Color.Aqua);
            c1.Adicionar("1", new Punto(-ancho, alto, profundidad));
            c1.Adicionar("2", new Punto(-ancho, alto, -profundidad));
            c1.Adicionar("3", new Punto(ancho, alto, -profundidad));
            c1.Adicionar("4", new Punto(ancho, alto, profundidad));
            Adicionar("cara5", c1);

            //inferior
            c1 = new Cara(origen, PrimitiveType.LineLoop, Color.Blue);
            c1.Adicionar("1", new Punto(-ancho, -alto, -profundidad));
            c1.Adicionar("2", new Punto(-ancho, -alto, profundidad));
            c1.Adicionar("3", new Punto(ancho, -alto, profundidad));
            c1.Adicionar("4", new Punto(ancho, -alto, -profundidad));
            Adicionar("cara6", c1);

            //frente
            c1 = new Cara(origen, PrimitiveType.LineLoop, Color.Green);
            c1.Adicionar("1", new Punto(-ancho, -alto, profundidad));
            c1.Adicionar("2", new Punto(-ancho, alto, profundidad));
            c1.Adicionar("3", new Punto(ancho, alto, profundidad));
            c1.Adicionar("4", new Punto(ancho, -alto, profundidad));
            Adicionar("cara1", c1);


            //TECHO----------------------------------------------

            //izquierdo
            c1 = new Cara(origen, PrimitiveType.Quads, Color.Red);
            c1.Adicionar("1", new Punto(-ancho, alto, -profundidad));
            c1.Adicionar("2", new Punto(0, alto*2, -profundidad));
            c1.Adicionar("3", new Punto(0, alto*2, profundidad));
            c1.Adicionar("4", new Punto(-ancho, alto, +profundidad));

            Adicionar("cara8", c1);
            //derecho
            c1 = new Cara(origen, PrimitiveType.Quads, Color.Yellow);
            c1.Adicionar("1", new Punto(ancho, alto, profundidad));
            c1.Adicionar("2", new Punto(0, alto*2, profundidad));
            c1.Adicionar("3", new Punto(0, alto*2, -profundidad));
            c1.Adicionar("4", new Punto(ancho, alto, -profundidad));
            Adicionar("cara9", c1);
            ////abajo
            ////c1 = new Cara(origen, PrimitiveType.Quads, Color.Blue);
            ////c1.Adicionar("1", new Punto(-ancho, -alto, -profundidad));
            ////c1.Adicionar("2", new Punto(-ancho, -alto, profundidad));
            ////c1.Adicionar("3", new Punto(ancho, -alto, profundidad));
            ////c1.Adicionar("4", new Punto(ancho, -alto, -profundidad));
            ////Adicionar("cara10", c1);

            //atras
            c1 = new Cara(origen, PrimitiveType.Triangles, Color.Pink);
            c1.Adicionar("1", new Punto(-ancho, alto, -profundidad));
            c1.Adicionar("2", new Punto(0, alto*2, -profundidad));
            c1.Adicionar("3", new Punto(ancho, alto, -profundidad));
            Adicionar("cara7", c1);
            //frente
            c1 = new Cara(origen, PrimitiveType.Triangles, Color.Green);
            c1.Adicionar("1", new Punto(-ancho, alto, profundidad));
            c1.Adicionar("2", new Punto(0, alto*2, profundidad));
            c1.Adicionar("3", new Punto(ancho, alto, profundidad));
            Adicionar("cara11", c1);

            //puerta ----------------------------------------------
            c1 = new Cara(origen, PrimitiveType.LineLoop, Color.Green);
            c1.Adicionar("1", new Punto(-ancho*0.2f, -alto, profundidad));
            c1.Adicionar("2", new Punto(-ancho*0.2f, alto*0.3f, profundidad));
            c1.Adicionar("3", new Punto(ancho*0.2f, alto*0.3f, profundidad));
            c1.Adicionar("4", new Punto(ancho*0.2f, -alto, profundidad));
            Adicionar("cara12", c1);
            //ventana--------------------------------------------------
            c1 = new Cara(origen, PrimitiveType.LineLoop, Color.Green);
            c1.Adicionar("1", new Punto(ancho , -alto*0.4f, profundidad*0.4f));
            c1.Adicionar("2", new Punto(ancho, alto*0.4f, profundidad * 0.4f));
            c1.Adicionar("3", new Punto(ancho, alto * 0.4f, -profundidad * 0.4f));
            c1.Adicionar("4", new Punto(ancho, -alto * 0.4f, -profundidad * 0.4f));
            Adicionar("cara13", c1);
        }
    }
}
