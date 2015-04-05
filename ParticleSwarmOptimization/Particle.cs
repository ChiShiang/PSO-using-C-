using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSO
{
    class Particle
    {
        public int dimension { get; set; }
        public double fitness { get; set; }
        public double[] present { get; set; }
        
        protected double[] velocity { get; set; }
        public Particle()
        {
            this.fitness = 0;
            this.present = new double[1] { 0 };
            this.velocity = new double[1] { 0 };
        }
        public Particle(int dimension)
        {
            this.fitness = 0;
            this.present = new double[1] { 0 };
            this.velocity = new double[1] { 0 };
            this.dimension = dimension;
        }
    }
}
