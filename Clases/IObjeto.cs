﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1
{
    interface IObjeto
    {
        void Dibujar();
        void Rotar(float x, float y, float z);
        void Trasladar(float x, float y, float z);
    }
}
