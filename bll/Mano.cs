﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bll
{
    public class Mano
    {
        public static List<be.Mano> crearManos()
        {
            List<be.Mano> manos = new List<be.Mano>();
            manos.Add(new be.Mano());
            manos.Add(new be.Mano());
            manos.Add(new be.Mano());
            return manos;
        }


    }
}