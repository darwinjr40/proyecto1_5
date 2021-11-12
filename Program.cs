using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using OpenTK.Graphics.OpenGL;

namespace Proyecto1
{
    class Program
    {
        static String path = "casa1.json";
        static void Main(string[] args)
        {
            Game juego = new Game(800, 600, "LearnOpenTK");
            juego.Run(60.0);
            //SerializarJson();
            //Deserialize();
            //Console.ReadLine();
        }








        public static void Deserialize()
        {
            var obj = GetObjetosJsonFromFile();
            DeserializeJsonFile(obj);
        }

        public static void DeserializeJsonFile(string json)
        {
            Console.WriteLine(json);
            var objetos = JsonConvert.DeserializeObject<Objeto>(json);

        }
        public static string GetObjetosJsonFromFile()
        {
            string x;
            using (var reader = new StreamReader(path))
            {
                x = reader.ReadToEnd();
            }
            return x;
        }
        
        //serializar----------------------------
        public static void SerializarJson()
        {
            var x = getObjeto();
            //var x = getCara();
            SerializeJsonFile(x);
        }
        public static void SerializeJsonFile(Objeto obj)
        {
            string objJson = JsonConvert.SerializeObject(obj, Formatting.Indented);
            File.WriteAllText(path, objJson);
        }
        public static Objeto getObjeto()
        {
            Objeto cubo = new Objeto(
                        new Punto(0, 0, 0),
                        8,
                        5,
                        10,
                        new Dictionary<string, Cara>
                        {
                            //planta
                            //derecha
                            {
                                "cara1",
                                new Cara(
                                    new Punto(0, 0, 0),
                                    PrimitiveType.LineLoop,
                                    new Dictionary<string, Punto>
                                    {
                                        { "1", new Punto(-8.0f, -5.0f, -10f) },
                                        { "2", new Punto(-8.0f, 5.0f, -10f) },
                                        { "3", new Punto(8.0f, 5.0f, -10f) },
                                        { "4", new Punto(8.0f, -5.0f, -10f) }
                                    },
                                    Color.Pink
                                )
                            },
                            //izquierda
                            {
                                "cara2",
                                new Cara(
                                    new Punto(0, 0, 0),
                                    PrimitiveType.LineLoop,
                                    new Dictionary<string, Punto>
                                    {
                                        { "1", new Punto(-8.0f, -5.0f, -10f) },
                                        { "2", new Punto(-8.0f, 5.0f, -10f) },
                                        { "3", new Punto(-8.0f, 5.0f, 10f) },
                                        { "4", new Punto(-8.0f, -5.0f, 10f) }
                                    },
                                    Color.Red
                                )
                            },
                            //derecha
                            {
                                "cara3",
                                new Cara(
                                    new Punto(0, 0, 0),
                                    PrimitiveType.LineLoop,
                                    new Dictionary<string, Punto>
                                    {
                                        { "1", new Punto(8.0f, -5.0f, 10f) },
                                        { "2", new Punto(8.0f, 5.0f, 10f) },
                                        { "3", new Punto(8.0f, 5.0f, -10f) },
                                        { "4", new Punto(8.0f, -5.0f, -10f) }
                                    },
                                    Color.Yellow
                                )
                            },
                            //superior
                            {
                                "cara4",
                                new Cara(
                                    new Punto(0, 0, 0),
                                    PrimitiveType.LineLoop,
                                    new Dictionary<string, Punto>
                                    {
                                        { "1", new Punto(-8.0f, 5.0f, 10f) },
                                        { "2", new Punto(-8.0f, 5.0f, -10f) },
                                        { "3", new Punto(8.0f, 5.0f, -10f) },
                                        { "4", new Punto(8.0f, 5.0f, 10f) }
                                    },
                                    Color.Aqua
                                )
                            },
                            //inferior
                            {
                                "cara5",
                                new Cara(
                                    new Punto(0, 0, 0),
                                    PrimitiveType.LineLoop,
                                    new Dictionary<string, Punto>
                                    {
                                        { "1", new Punto(-8.0f, -5.0f, -10f) },
                                        { "2", new Punto(-8.0f, -5.0f, 10f) },
                                        { "3", new Punto( 8.0f, -5.0f,  10f) },
                                        { "4", new Punto( 8.0f, -5.0f, -10f) }
                                    },
                                    Color.Blue
                                )
                            },
                            //frente
                            {
                                "cara6",
                                new Cara(
                                    new Punto(0, 0, 0),
                                    PrimitiveType.LineLoop,
                                    new Dictionary<string, Punto>
                                    {
                                        { "1", new Punto(-8.0f, -5.0f, 10f) },
                                        { "2", new Punto(-8.0f, 5.0f, 10f) },
                                        { "3", new Punto(8.0f, 5.0f, 10f) },
                                        { "4", new Punto(8.0f, -5.0f, 10f) }
                                    },
                                    Color.Green
                                )
                            },

                             //TECHO----------------------------------------------\
                             //izquierdo
                            {
                                "cara7",
                                new Cara(
                                    new Punto(0, 0, 0),
                                    PrimitiveType.Quads,
                                    new Dictionary<string, Punto>
                                    {
                                        { "1", new Punto(-8.0f, 5.0f, -10f) },
                                        { "2", new Punto(0, 10.0f, -10.0f) },
                                        { "3", new Punto(0, 10.0f, 10.0f) },
                                        { "4", new Punto(-8.0f, 5.0f, 10f) }
                                    },
                                    Color.Red
                                )
                            },
                            //derecho
                            {
                                "cara8",
                                new Cara(
                                    new Punto(0, 0, 0),
                                    PrimitiveType.Quads,
                                    new Dictionary<string, Punto>
                                    {
                                        { "1", new Punto(8.0f, 5.0f, 10f) },
                                        { "2", new Punto(0, 10f, 10f) },
                                        { "3", new Punto(0, 10f, -10f) },
                                        { "4", new Punto(8.0f, 5.0f, -10f) }
                                    },
                                    Color.Yellow
                                )
                            },
                            //atras
                            {
                                "cara9",
                                new Cara(
                                    new Punto(0, 0, 0),
                                    PrimitiveType.Triangles,
                                    new Dictionary<string, Punto>
                                    {
                                        { "1", new Punto(-8.0f, 5.0f, -10f) },
                                        { "2", new Punto(0, 10.0f, -10f) },
                                        { "3", new Punto(8.0f, 5.0f, -10f) }
                                    },
                                    Color.Pink
                                )
                            },
                            //frente
                            {
                                "cara10",
                                new Cara(
                                    new Punto(0, 0, 0),
                                    PrimitiveType.Triangles,
                                    new Dictionary<string, Punto>
                                    {
                                        { "1", new Punto(-8.0f, 5.0f, 10f) },
                                        { "2", new Punto(0, 10f, 10f) },
                                        { "3", new Punto(8.0f, 5.0f, 10f) }
                                    },
                                    Color.Green
                                )
                            },

                            //puerta
                            {
                                "cara11",
                                new Cara(
                                    new Punto(0, 0, 0),
                                    PrimitiveType.LineLoop,
                                    new Dictionary<string, Punto>
                                    {
                                        { "1", new Punto(-1.6f, -5.0f, 10f) },
                                        { "2", new Punto(-1.6f, 1.5f, 10f) },
                                        { "3", new Punto(1.6f, 1.5f, 10f) },
                                        { "4", new Punto(1.6f, -5.0f, 10f) }
                                    },
                                    Color.White
                                )
                            },
                            //ventana
                            {
                                "cara12",
                                new Cara(
                                    new Punto(0, 0, 0),
                                    PrimitiveType.LineLoop,
                                    new Dictionary<string, Punto>
                                    {
                                        { "1", new Punto(8.0f, -2.0f, 4.0f) },
                                        { "2", new Punto(8.0f, 2.0f, 4.0f) },
                                        { "3", new Punto(8.0f, 2.0f, -4.0f) },
                                        { "4", new Punto(8.0f, -2.0f, -4.0f) }
                                    },
                                    Color.White
                                )
                            },
                        }
                        
                ); 
            return cubo;
        }

        public static Cara getCara()
        {
            Cara x = new Cara(
                                    new Punto(0, 0, 0),
                                    PrimitiveType.LineLoop,
                                    new Dictionary<string, Punto>
                                    {
                                        { "1", new Punto(-10f, -10f, -10f) },
                                        { "2", new Punto(-10f, 10f, -10f) },
                                        { "3", new Punto(10f, 10f, -10f) },
                                        { "4", new Punto(10f, -10f, -10f) }
                                    },
                                    Color.Pink
                                );
            return x;
        }



        //Punto a = new Punto(2);
        //Console.WriteLine(a.x);
        //Console.WriteLine(a.y);
        //Console.WriteLine(a.z);

        //Punto b = new Punto(1, 2, 3);
        //Console.WriteLine(b.x);
        //Console.WriteLine(b.y);
        //Console.WriteLine(b.z);

        //Punto c = new Punto(new Punto(4, 5, 6));
        //Console.WriteLine(c.x);
        //Console.WriteLine(c.y);
        //Console.WriteLine(c.z);

        //Punto d = new Punto();
        //Console.WriteLine(d.x);
        //Console.WriteLine(d.y);
        //Console.WriteLine(d.z);

        //Console.WriteLine(a);
        //Console.WriteLine(b);
        //Console.WriteLine(c);
        //Console.WriteLine(d);

        //Console.WriteLine(b.ToVector3());

        //Console.ReadLine();

    }
}
