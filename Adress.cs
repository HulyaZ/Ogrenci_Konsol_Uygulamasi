using System;
using System.Collections.Generic;
using System.Text;

namespace OgrenciUygulamasi
{
    public class Adress
    {

        public string City { get; set; }
        public string Province { get; set; }
        public string AveName { get; set; }
        public string StreetName { get; set; }
        public int BuildingNo { get; set; }
        public int AptNo { get; set; }


        public Adress()
        {


        }

        public Adress(string city, string province, string aveName, string streetName, int buildingNo, int aptNo)
        {
            this.City = city;
            this.Province = province;
            this.AveName = aveName;
            this.StreetName = streetName;
            this.BuildingNo = buildingNo;
            this.AptNo = aptNo;
        }
    }
}
