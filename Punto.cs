using Newtonsoft.Json;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Punto
    {
        //atributos

        private float ejeX { get; set; }
        private float ejeY { get; set; }
        private float ejeZ { get; set; }
        //properties
        [JsonProperty] public float x { get { return ejeX; } set { ejeX = value; } }
        [JsonProperty] public float y { get => ejeY; set => ejeY = value;}
        [JsonProperty] public float z { get => ejeZ; set => ejeZ = value; }

        //contructor con parametros---------------------------------------------------------
    public Punto(float x, float y, float z)
        {
            this.ejeX = x;
            this.ejeY = y;
            this.ejeZ = z;
        }

        public Punto(): this(0, 0, 0) { }

        //Contructor copia
        public Punto(Punto p)
        {
            this.ejeX = p.ejeX;
            this.ejeY = p.ejeY;
            this.ejeZ = p.ejeZ;
        }
        //Contructor con el mismo valor inicial 
        public Punto(float valor)
        {
            this.ejeX = this.ejeY = this.ejeZ = valor;
        }

        public Vector3 ToVector3() 
        { 
            return new Vector3(this.ejeX, this.ejeY, this.ejeZ); 
        }

        public override string ToString() => $"({ejeX},{ejeY},{ejeZ})";
        


    }
}
