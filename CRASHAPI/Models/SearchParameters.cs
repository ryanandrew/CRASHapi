using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using CRASHAPI.Models;

namespace CRASHAPI.Controllers
{
    public class SearchParameters
    {
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int? CrashType { get; set; }
        public string ReportNumber { get; set; }
        public decimal? RoadwayGroup { get; set; }
        public string DamageDescription { get; set; }
        public string DestinationHospital { get; set; }
        public string DestinationHospital2 { get; set; }
        public string ReportingAgency { get; set; }
        public int? DirectionOfCollision { get; set; }
        public string EMSAgency { get; set; }
    }

    public class BasicSearchParameters
    {
        [DataMember(IsRequired = false)]
        public string StartDate { get; set; }
        [DataMember(IsRequired = false)]
        public string EndDate { get; set; }
        [DataMember(IsRequired = false)]
        public List<string> CityCode { get; set; }
        [DataMember(IsRequired = false)]
        public List<string> CountyCode { get; set; }
        [DataMember(IsRequired = false)]
        public List<string> Route { get; set; }
        [DataMember(IsRequired = false)]
        public List<decimal> CrashType { get; set; }
        [DataMember(IsRequired = false)]
        public List<string> ReportingAgency { get; set; }
    }
    public class AccidentDetails
    {
        public vw_PQT_AccidentHeader Accident { get; set; }
        public List<vw_PQT_Persons> Persons { get; set; }
        public List<vw_PQT_Units> Units { get; set; }
    }

    public class Point
    {
        public double? x { get; set; }
        public double? y { get; set; }
    }

    public class statePlanePoint
    {
        public string x { get; set; }
        public string y { get; set; }
    }
    public class Geometries
    {
        public IEnumerable<Point> geometries { get; set; }
    }

    public class GeocodedAccident
    {
        public AccidentModel.Accident accident { get; set; }
        public Point point { get; set;}

        public GeocodedAccident(AccidentModel.Accident a, Point p)
        {
            this.accident = a;
            this.point = p;
        }
    }
}


