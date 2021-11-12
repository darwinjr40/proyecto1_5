using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1
{
    class Techo
    {

        private float ancho;
        private float alto;
        private float profundidad;
        public Punto origen;

        public Techo(Punto p, float ancho, float alto, float profundidad)
        {
            origen = p;
            this.ancho = ancho;
            this.alto = alto;
            this.profundidad = profundidad;

        }

        public void dibujar()
        {
            PrimitiveType primitiveType = PrimitiveType.Triangles;
            //PrimitiveType primitiveType = PrimitiveType.Quads;
            //GL.Rotate(0.8, 1, 1, 1);
            back(primitiveType);  //rosado
            left(PrimitiveType.Quads);   //rojo
            right(PrimitiveType.Quads);  //amarillo
            front(primitiveType);  //verde
            bottom(PrimitiveType.Quads); //azul

        }

        private void bottom(PrimitiveType primitiveType)
        {
            GL.Begin(primitiveType);
            GL.Color3(0.0, 0.0, 1.0);//azul;
            GL.Vertex3(origen.x - ancho, origen.y - alto, origen.z - profundidad); //
            GL.Vertex3(origen.x - ancho, origen.y - alto, origen.z + profundidad);//2do
            GL.Vertex3(origen.x + ancho, origen.y - alto, origen.z + profundidad);//
            GL.Vertex3(origen.x + ancho, origen.y - alto, origen.z - profundidad); //
            GL.End();
        }





        private void left(PrimitiveType primitiveType)
        {
            GL.Begin(primitiveType);
            GL.Color3(1, 0.0, 0.0);//rojo
            GL.Vertex3(origen.x - ancho, origen.y - alto, origen.z - profundidad); //1ro
            GL.Vertex3(origen.x, origen.y + alto, origen.z - profundidad);//2do
            GL.Vertex3(origen.x, origen.y + alto, origen.z + profundidad);//3ro
            GL.Vertex3(origen.x - ancho, origen.y - alto, origen.z + profundidad); //4to
            GL.End();
        }

        private void right(PrimitiveType primitiveType)
        {
            GL.Begin(primitiveType);
            GL.Color3(1.0, 1.0, 0.0);//amarillo
            GL.Vertex3(origen.x + ancho, origen.y - alto, origen.z + profundidad); //1ro
            GL.Vertex3(origen.x, origen.y + alto, origen.z + profundidad);//2do
            GL.Vertex3(origen.x, origen.y + alto, origen.z - profundidad);//3ro
            GL.Vertex3(origen.x + ancho, origen.y - alto, origen.z - profundidad); //4to
            GL.End();
        }
        private void front(PrimitiveType primitiveType)
        {
            GL.Begin(primitiveType);
            GL.Color3(0.0, 1.0, 0.0);//verde
            GL.Vertex3(origen.x - ancho, origen.y - alto, origen.z + profundidad);
            GL.Vertex3(origen.x, origen.y + alto, origen.z + profundidad);
            GL.Vertex3(origen.x + ancho, origen.y - alto, origen.z + profundidad);
            GL.End();
        }


        private void back(PrimitiveType primitiveType)
        {
            GL.Begin(primitiveType);
            GL.Color3(1, 0.2, 1);//rosado
            GL.Vertex3(origen.x - ancho, origen.y - alto, origen.z - profundidad);
            GL.Vertex3(origen.x, origen.y + alto, origen.z - profundidad);
            GL.Vertex3(origen.x + ancho, origen.y - alto, origen.z - profundidad);
            GL.End();
        }
    }
}
