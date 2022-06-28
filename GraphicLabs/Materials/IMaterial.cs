﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphicLabs.Basic;
using GraphicLabs.SceneStuff;
using GraphicLabs.SceneStuff.Light;

namespace GraphicLabs.Materials
{
    public interface IMaterial
    {
        public ResultColor Calculate(Ray ray, Hit hit, Scene scene, int recursions = 0);
    }
}
