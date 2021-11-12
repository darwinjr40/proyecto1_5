using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1
{
    class Casa
    {
        private float ancho;
        private float alto;
        private float profundidad;
        public Punto origen;
        Cubo cubo;
        Cubo puerta;
        Cubo ventana;
        Techo techo;

        public Casa(Punto p, float ancho, float alto, float profundidad)
        {
            origen = p;
            this.ancho = ancho;
            this.alto = alto;
            this.profundidad = profundidad;
            cubo = new Cubo(p, ancho, alto, profundidad);
            techo = new Techo(new Punto(p.x, p.y + alto*2, p.z), ancho, alto, profundidad);
            puerta = new Cubo(new Punto(p.x, p.y - alto*0.5f , p.z + profundidad), ancho/3, alto/2, 0);
            ventana = new Cubo(new Punto(p.x + ancho, p.y  , p.z), 0, alto/3, profundidad/4); 
        }

        public void dibujar()
        {
            cubo.dibujar();
            techo.dibujar();
            puerta.dibujar();
            ventana.dibujar();
        }
    }
}
