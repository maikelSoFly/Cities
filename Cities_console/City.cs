using System;

namespace Cities_console
{
    public class City
    {

        private String name;
        private int uid;
        private Double longitude;
        private Double latitude;
        private Region region;


        public City(String name, int uid, Double lon, Double lat, Region region)
        {
            this.name = name;
            this.uid = uid;
            this.longitude = lon;
            this.latitude = lat;
            this.region = region;
        }


        //MARK: - Getters.
        public int getUID()
        {
            return uid;
        }

        public int getRegionUID()
        {
            return region.getUID();
        }

        public String getName()
        {
            return name;
        }

        public Double getLongitude()
        {
            return longitude;
        }

        public Double getLatitude()
        {
            return latitude;
        }

        public Region getRegion()
        {
            return region;
        }
    }
}
