using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSO.ParticleSwarmOptimization
{
    class GlobalParticle:Particle
    {
        public GlobalParticle()
        {

        }

        public GlobalParticle(int dimension)
        {
            this.fitness = -5.0 / 0.0;
            this.dimension = dimension;
            this.present = new double[this.dimension];
        }

        public void GlobalParticleUpdate(PersonalParticle[] particleSet, bool findMaximum)
        {
            for (int i = 0; i < particleSet.Length; i++)
            {
                if (findMaximum && (particleSet[i].fitness > this.fitness || this.fitness == -5.0 / 0.0))
                {
                    InfoUpdate(particleSet[i].fitness, particleSet[i].present);
                }
                else if (!findMaximum && (particleSet[i].fitness < this.fitness || this.fitness == -5.0 / 0.0))
                {
                    InfoUpdate(particleSet[i].fitness, particleSet[i].present);
                }
            }
        }

        private void InfoUpdate(double fitness, double[] present)
        {
            this.fitness = fitness;
            Array.Copy(present, this.present, this.dimension);
        }
    }
}
