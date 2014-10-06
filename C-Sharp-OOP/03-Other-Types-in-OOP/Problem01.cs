﻿using System;

namespace Problem01GalacticGPS
{
    public enum Planet
    {
        Mercury, Venus, Earth, Mars, Jupiter, Saturn, Uranus, Neptune
    }

    struct Location
    {
        private double latitude;
        private double longitude;
        private Planet planet;

        public Location(double latitude, double longitude, Planet planet) : this()
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.Planet = planet;
        }

        public double Latitude 
        {
            get { return this.latitude; }
            set { this.latitude = value; }
        }

        public double Longitude 
        {
            get { return this.longitude; }
            set { this.longitude = value; }
        }

        public Planet Planet 
        {
            get { return this.planet; }
            set { this.planet = value; }
        }

        public override string ToString()
        {
            return string.Format("{0}, {1} - {2}", Latitude, Longitude, Planet);
        }
    }

    class Problem01
    {
        static void Main(string[] args)
        {
            Location home = new Location(18.037986, 28.870097, Planet.Earth);
            Console.WriteLine(home);

            Location mars = new Location(10.056788, 15.343434, Planet.Mars);
            Console.WriteLine(mars);
        }
    }
}