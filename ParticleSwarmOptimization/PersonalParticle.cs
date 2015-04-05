using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSO.ParticleSwarmOptimization
{
    class PersonalParticle:Particle
    {
        public double c1 { get; set; }
        public double c2 { get; set; }
        public double velocityWeight { get; set; }
        public double time { get; set; }
        public double rangeMax { get; set; }
        public double rangeMin { get; set; }
        public double limitOfVelocity { get; private set; }
        public double personalBestFitness { get; private set; }
        public double[] personalBestPresent { get; private set; }
        private bool findMaximum { get; set; }
        private Random r = new Random(Guid.NewGuid().GetHashCode());


        public PersonalParticle()
        {
            this.c1 = this.c2 = 2;
            this.velocityWeight = 0;
            this.time = 1;
            this.findMaximum = true;
            this.personalBestFitness = -5.0 / 0.0;
            this.personalBestPresent = new double[0];
        }

        public PersonalParticle(int dimension, bool findMaximum, double rangeMax, double rangeMin, bool initialVelocityIsStatic)
        {
            this.dimension = dimension;
            this.findMaximum = findMaximum;
            this.rangeMax = rangeMax;
            this.rangeMin = rangeMin;
            this.c1 = this.c2 = 2;
            this.velocityWeight = 0;
            this.time = 1;
            this.personalBestFitness = -5.0 / 0.0;
            this.personalBestPresent = new double[dimension];
            PresentInitialize();
            VelocityInitialize(initialVelocityIsStatic);
        }

        public void PresentInitialize()
        {
            this.present = new double[this.dimension];
            for (int i = 0; i < this.dimension; i++)
            {
                this.present[i] = PresentReset();
            }
        }

        public void VelocityInitialize(bool initialVelocityIsStatic)
        {
            double v = 0.0;
            this.velocity = new double[this.dimension];
            this.limitOfVelocity = this.rangeMax - this.rangeMin;
            for (int i = 0; i < this.velocity.Length; i++)
            {
                if (initialVelocityIsStatic)
                {
                    this.velocity[i] = 0.0;
                }
                else
                {
                    v = VelocityReset();
                    this.velocity[i] = v > this.limitOfVelocity || v < -this.limitOfVelocity ? 0 : v;
                }
            }
        }

        public void PresentUpdate()
        {
            for (int i = 0; i < this.present.Length; i++)
            {
                double tempPresent;
                tempPresent = this.present[i] + this.velocity[i] * time;
                this.present[i] = tempPresent > this.rangeMax || tempPresent < this.rangeMin ? PresentReset() : tempPresent;
            }
        }

        public void VelocityUpdate(double[] globalPresent)
        {
            for (int i = 0; i < this.velocity.Length; i++)
            {
                double tempVelocity, eq1, eq2;
                eq1 = this.c1 * r.NextDouble() * (this.personalBestPresent[i] - this.present[i]);
                eq2 = this.c2 * r.NextDouble() * (globalPresent[i] - this.present[i]);
                tempVelocity = velocity[i] * this.velocityWeight + eq1 + eq2;
                this.velocity[i] = tempVelocity > this.limitOfVelocity || tempVelocity < -this.limitOfVelocity ? VelocityReset() : tempVelocity;
            }
        }

        public void PersonalBestUpdate()
        {
            if (this.findMaximum && (this.fitness > this.personalBestFitness || this.personalBestFitness == 5.0 / 0.0))
            {
                this.personalBestFitness = this.fitness;
                Array.Copy(present, personalBestPresent, this.dimension);
            }
            else if (!this.findMaximum && (this.fitness < this.personalBestFitness || this.personalBestFitness == -5.0 / 0.0))
            {
                this.personalBestFitness = this.fitness;
                Array.Copy(present, personalBestPresent, this.dimension);
            }
        }

        private double PresentReset()
        {
            double newPresent = (this.rangeMax - this.rangeMin) * r.NextDouble() + this.rangeMin;
            return newPresent;
        }

        private double VelocityReset()
        {
            double newVelocity = (this.limitOfVelocity - (-this.limitOfVelocity)) * r.NextDouble() + (-this.limitOfVelocity);
            return newVelocity;
        }
    }
}
