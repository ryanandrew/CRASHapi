using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRASHAPI.Models
{
    public class AccidentModel
    {
        private static ReferenceEntities reference = new ReferenceEntities();
        private static VCSGEntities db = new VCSGEntities();

        public class Accident
        {
            public string REPORTINGAGENCYid { get; set; }
            public string ReportingAgency { get; set; }
            public string REPORTNUMBER { get; set; }
            public decimal LOCALID { get; set; }
            public DateTime? ACCIDENTTIME { get; set; }
            public DateTime ACCIDENTDATE { get; set; }
            public string STREETADDRESS { get; set; }
            public decimal? AOTROADWAYGROUPid { get; set; }
            public string RoadGroup { get; set; }           
            public string VCSG_CITYTOWN { get; set; }
            public string VCSG_AOTROUTE { get; set; }
            public string HOWMAPPED { get; set; }
            public string GIS_LONGITUDE { get; set; }
            public string GIS_LATITUDE { get; set; }
            public string VCSG_LONGITUDE { get; set; }
            public string VCSG_LATITUDE { get; set; }
            //computed fields
            public string LATITUDE { get; set; }
            public string LONGITUDE { get; set; } 
            public string InjuryType { get; set; }
            public string Weather { get; set; }
            public string DayNight { get; set; }
            public string Impairment { get; set; }
            public string Involving { get; set; }
            public string Animal { get; set; }
            private IQueryable<vw_PQT_Units> Units { get; set; }
            public Accident(vw_PQT_AccidentHeader a)
            {
                Units = from u in db.vw_PQT_Units
                        where u.REPORTINGAGENCY == a.REPORTINGAGENCYid &&
                        u.REPORTNUMBER == a.REPORTNUMBER
                        select u;

                REPORTINGAGENCYid = a.REPORTINGAGENCYid;
                ReportingAgency = a.ReportingAgency;
                REPORTNUMBER = a.REPORTNUMBER;
                LOCALID = a.LOCALID;
                ACCIDENTTIME = a.ACCIDENTTIME;
                ACCIDENTDATE = a.ACCIDENTDATE;
                STREETADDRESS = a.STREETADDRESS;
                AOTROADWAYGROUPid = a.AOTROADWAYGROUPid;
                RoadGroup = a.RoadGroup;
                VCSG_AOTROUTE = a.VCSG_AOTROUTE;
                HOWMAPPED = a.HOWMAPPED;
                GIS_LATITUDE = a.GIS_LATITUDE;
                GIS_LONGITUDE = a.GIS_LONGITUDE;
                VCSG_LATITUDE = a.VCSG_LATITUDE;
                VCSG_LONGITUDE = a.VCSG_LONGITUDE;
                VCSG_CITYTOWN = a.VCSG_CITYTOWN;

                if (a.HOWMAPPED != null)
                {
                    LATITUDE = a.GIS_LATITUDE;
                    LONGITUDE = a.GIS_LONGITUDE;
                }
                else if (a.VCSG_LONGITUDE != null && a.VCSG_LATITUDE != null)
                {
                    LATITUDE = a.VCSG_LATITUDE;
                    LONGITUDE = a.VCSG_LONGITUDE;
                }
                //computed fields               
                InjuryType = GetInjuryType(a);
                Weather = GetWeatherCondition(a);
                DayNight = GetDayNight(a.ACCIDENTTIME);
                Impairment = GetImpairment();
                Involving = GetInvolving();
                Animal = GetAnimal();
            }

            public string GetInjuryType(vw_PQT_AccidentHeader a)
            {
                return a.CrashType;
            }

            public string GetWeatherCondition(vw_PQT_AccidentHeader a)
            {
                switch (Convert.ToInt32(a.WEATHERCONDITIONid))
                { 
                    case 1:
                        return "Clear";
                    case 2:
                    case 3:
                        return "Cloudy";
                    case 4:
                        return "Rain";
                    case 5:
                    case 6:
                        return "Freezing Precipitation";
                    case 7:
                    case 8:
                        return "Wind";
                    case 9:
                    case 10:
                    case 11:
                        return "Unknown";
                    default:
                        return "Unkown";

                }
            }

            public string GetDayNight(DateTime? a)
            {
                
                string DayNight = "Unkown";
                DateTime accidentTime;
                if (a != null)
                {
                    accidentTime = Convert.ToDateTime(a);
                }
                else {
                    return "Unknown";
                }
                
                //summer months April through September
                if (accidentTime.Month > 3 && accidentTime.Month < 10)
                {
                    if (accidentTime.Hour > 6 && accidentTime.Hour < 20)
                    {
                        DayNight =  "Day";
                    }
                    else 
                    {
                        DayNight = "Night";
                    }
                }
                //winter months October through March
                else if (accidentTime.Month >= 10 || accidentTime.Month <= 3)
                {
                    if (accidentTime.Hour > 7 && accidentTime.Hour < 18)
                    {
                        DayNight = "Day";
                    }
                    else {
                        DayNight = "Night";
                    }
                }
                return DayNight;  
            }

            private delegate bool DrugCalc(vw_PQT_Units unit);

            private bool GetDrugInvolvement(vw_PQT_Units unit)
            {
                decimal?[] drugTestArray = new [] {unit.DRUGTESTRESULT1id, unit.DRUGTESTRESULT2id, unit.DRUGTESTRESULT3id, unit.DRUGTESTRESULT4id};
                return (drugTestArray.Contains(7m) || drugTestArray.Contains(15));
            }
            public string GetImpairment()
            {
                var impairment = "None";
                /*
                bool alcoholInvolved = this.Units.Any(unit => (unit.ALCOHOLTESTid >= 0.01m && unit.ALCOHOLTESTid <= .998m) || unit.APPARENTOPERATORCOND1id == 7 || unit.APPARENTOPERATORCOND2id == 7);
                bool drugsInvolved = this.Units.AsEnumerable().Any(unit => GetDrugInvolvement(unit));
                if (drugsInvolved) impairment = "Drugs";
                else if (alcoholInvolved) impairment = "Alcohol";
                */
                return impairment;
                
            }

            delegate decimal? Determine(decimal? prev, decimal? cur);

            private static decimal? DetermineInvolving(decimal? prev, decimal? cur)
            {
                int previous = Convert.ToInt32(prev);
                int current = Convert.ToInt32(cur);
                decimal? result = -1;
                int compare = Math.Min(previous, current);
                switch (compare) { 
                    case 17:
                        result = 17m;
                        break;
                    case 19:
                        result = 19m;
                        break;
                    case 24:
                        result = 24m;
                        break;
                    default:
                        result = prev;
                        break;
                }
                return result;
            }

            public string GetInvolving()
            {
               Determine determineInvolving = DetermineInvolving;
               string involved = "None";
               if (Units.Count() > 0)
               {
                   int unitType = Convert.ToInt32(this.Units.Select(x => x.UNITTYPEid).AsEnumerable().Aggregate((prev, cur) => determineInvolving(prev, cur)));

                   switch (unitType)
                   {
                       case 17:
                           involved = "Bicycle";
                           break;
                       case 19:
                           involved = "Pedestrian";
                           break;
                       case 24:
                           involved = "Motorcycle";
                           break;
                   }
               }  
                return involved;
            }

            private static decimal? DetermineAnimal(decimal? prev, decimal? cur)
            {
                int previous = Convert.ToInt32(prev);
                int current = Convert.ToInt32(cur);
                decimal? result = -1;
                int compare = Math.Min(previous, current);
                switch (compare)
                {
                    case 6:
                        result = 6m;
                        break;
                    case 7:
                        result = 7m;
                        break;
                    case 8:
                        result = 8m;
                        break;
                    case 9:
                        result = 9m;
                        break;
                    default:
                        result = prev;
                        break;
                }
                return result;
            }
            public string GetAnimal()
            {
               string animal = "None";
               Determine determineAnimal = DetermineAnimal;
               if (Units.Count() > 0)
               {
                   int animalType = Convert.ToInt32(this.Units.Select(x => x.VEHCOLLIDEDWITH).AsEnumerable().Aggregate((prev, cur) => determineAnimal(prev, cur)));
                   switch (animalType)
                   {
                       case 6:
                           animal = "Deer";
                           break;
                       case 7:
                           animal = "Moose";
                           break;
                       case 8:
                           animal = "Wild Animal";
                           break;
                       case 9:
                           animal = "Domestic";
                           break;
                       default:
                           animal = "Other";
                           break;
                   }
               }
               return animal;           
            }
        }

    }
}