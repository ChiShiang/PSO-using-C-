using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSO.ParticleSwarmOptimization;
using Benchmark;

namespace PSO
{
    class PSO
    {
        public List<double> start(int dimension, int numberOfParticle, int iterationTimes)
        {
            BenchmarkFunction BFunction = new BenchmarkFunction();
            GlobalParticle globalParticl = new GlobalParticle(dimension);
            PersonalParticle[] personalParticle = new PersonalParticle[numberOfParticle];
            List<double> globalFitnessContents = new List<double>();
            for (int i = 0; i < iterationTimes; i++)
            {
                for (int j = 0; j < numberOfParticle; j++)
                {
                    if (i == 0)
                    {
                        personalParticle[j] = new PersonalParticle(dimension, BFunction.AckleyFunctionTarget(), 32, -32, true);
                    }
                    else
                    {
                        personalParticle[j].VelocityUpdate(globalParticl.present);
                        personalParticle[j].PresentUpdate();                     
                    }
                    personalParticle[j].fitness = BFunction.AckleyFunction(personalParticle[j].present);
                    personalParticle[j].PersonalBestUpdate();
                }
                globalParticl.GlobalParticleUpdate(personalParticle, BFunction.AckleyFunctionTarget());
                globalFitnessContents.Add(globalParticl.fitness);
            }
            return globalFitnessContents;
        }
    }
}
