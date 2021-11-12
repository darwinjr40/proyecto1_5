using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1
{
    class Game : GameWindow
    {
       
        Cara cara;
        Objeto obj;
        Escenario esc;
        public Game(int width, int height, string title) : base(width, height, GraphicsMode.Default, title){  }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            KeyboardState input = Keyboard.GetState();
            if (input.IsKeyDown(Key.Q))
                esc.Rotar(0.8f, 0, 0);
            else if (input.IsKeyDown(Key.W))
                esc.Rotar(0,0.8f, 0);
            else if (input.IsKeyDown(Key.E))
                esc.Rotar(0, 0, 0.8f);
            else if (input.IsKeyDown(Key.A))
                esc.Trasladar(0.2f, 0, 0);
            else if (input.IsKeyDown(Key.S))
                esc.Trasladar(0, 0.2f, 0);
            else if (input.IsKeyDown(Key.D))
                esc.Trasladar(0, 0, 0.2f);
            else if (input.IsKeyDown(Key.F))
                esc.Trasladar(-0.2f, 0, 0);
            else if (input.IsKeyDown(Key.G))
                esc.Trasladar(0, -0.2f, 0);
            else if (input.IsKeyDown(Key.H))
                esc.Trasladar(0, 0, -0.2f);

            else if (input.IsKeyDown(Key.Z))
                esc.Escalar(0.9f, 0, 0);
            else if (input.IsKeyDown(Key.X))
                esc.Escalar(1.1f, 0, 0);
            else if (input.IsKeyDown(Key.C))
                esc.Escalar(0, 0.9f, 0);
            else if (input.IsKeyDown(Key.V))
                esc.Escalar(0, 1.1f, 0);
            else if (input.IsKeyDown(Key.B))
                esc.Escalar(0, 0, 0.9f);
            else if (input.IsKeyDown(Key.N))
                esc.Escalar(0, 0, 1.1f);
            //cara.Trasladar(0, 0, 0);
            //esc.Trasladar(2, 0, 0);

            base.OnUpdateFrame(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);
            //GL.MatrixMode(GL_MODELVIEW);
            cara = new Cara("cara.json");
            //obj = new Objeto(new Punto(), 8, 5, 10);
            //obj.cargarAutomatico();
            //obj = new Objeto("objeto.json");
            esc = new Escenario();
            esc.Adicionar("casa", new Objeto("casa1.json"));
            esc.Adicionar("cubo", new Objeto("cubo.json"));
            //---------------------------
            base.OnLoad(e);  
        }

        protected override void OnUnload(EventArgs e)
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            //GL.DeleteBuffer(VertexBufferObject);
            base.OnUnload(e);
        }
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.MatrixMode(MatrixMode.Modelview);
            //GL.Enable(EnableCap.DepthTest);
            //------------------------------------
            esc.Dibujar();
            
            //------------------------------------
            Context.SwapBuffers();
            base.OnRenderFrame(e);
        }

        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-55, 55, -55, 55, -55, 55);
            GL.MatrixMode(MatrixMode.Modelview);
            base.OnResize(e);
        }


    }
}
