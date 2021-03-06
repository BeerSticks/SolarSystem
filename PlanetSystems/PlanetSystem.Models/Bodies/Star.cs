﻿using System.Collections.Generic;
using PlanetSystem.Models.Utilities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PlanetSystem.Models.Bodies
{
    public class Star : AstronomicalBody
    {
        // Constructors
        public Star(Point center, double mass, double radius, Vector velocity, string name)
            : base(center, mass, radius, velocity, name)
        {
        }

        public Star(Point center, double mass, double radius, string name)
            : this(center, mass, radius, new Vector(new Point(0, 0, 0)), name)
        {
        }

        public Star(Star star)
            : this(star.Center, star.Mass, star.Radius, star.Velocity, star.Name)
        {
        }

        // Required from Entity Framework
        private Star() { }

        // Properties
        [Key, ForeignKey("PlanetarySystem")]
        public int StarId { get; set; }
        public virtual PlanetarySystem PlanetarySystem { get; set; }

        public virtual ICollection<Planet> Planets
        {
            get
            {
                if (PlanetarySystem != null)
                {
                    return PlanetarySystem.Planets;
                }
                else
                {
                    return new List<Planet>();
                }
            }
        }

        // Methods 
        public void Attach(PlanetarySystem planetarySystem)
        {
            this.PlanetarySystem = planetarySystem;
        }

        public void Detach()
        {
            this.PlanetarySystem = null;
        }
    }
}
