using System;
namespace Cities_console
{
    public class City
    {
        private String name;
        private Double longitude;
        private Double latitude;
        private Region region;

        public City(String name, Double lon, Double lat, Region region)
        {
            this.name = name;
            this.longitude = lon;
            this.latitude = lat;
            this.region = region;
        }
    }
}
