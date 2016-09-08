//
// BusinessTier:  business logic, acting as interface between UI and data store.
//
//Based off skeleton code by Joe Hummel

using System;
using System.Collections.Generic;
using System.Data;


namespace BusinessTier
{
  ///
  /// <summary>
  /// Ways to sort the Areas in Chicago.
  /// </summary>
  /// 
  public enum OrderAreas
  {
    ByNumber,
    ByName
  };


  //
  // Business:
  //
  public class Business
  {
    //
    // Fields:
    //
    private string _DBFile;
    private DataAccessTier.Data dataTier;


    ///
    /// <summary>
    /// Constructs a new instance of the business tier.  The format
    /// of the filename should be either |DataDirectory|\filename.mdf,
    /// or a complete Windows pathname.
    /// </summary>
    /// <param name="DatabaseFilename">Name of database file</param>
    /// 
    public Business(string DatabaseFilename)
    {
      _DBFile = DatabaseFilename;

      dataTier = new DataAccessTier.Data(DatabaseFilename);
    }


    ///
    /// <summary>
    ///  Opens and closes a connection to the database, e.g. to
    ///  startup the server and make sure all is well.
    /// </summary>
    /// <returns>true if successful, false if not</returns>
    /// 
    public bool OpenCloseConnection()
    {
      return dataTier.OpenCloseConnection();
    }


    ///
    /// <summary>
    /// Returns overall stats about crimes in Chicago.
    /// </summary>
    /// <returns>CrimeStats object</returns>
    ///
    public CrimeStats GetOverallCrimeStats()
    {
      CrimeStats cs;

      int minYear = (int)dataTier.ExecuteScalarQuery("SELECT MIN(Year) from Crimes;");
      int maxYear = (int)dataTier.ExecuteScalarQuery("SELECT MAX(Year) from Crimes;");
      int num = (int)dataTier.ExecuteScalarQuery("SELECT Count(*) from Crimes;");
      cs = new CrimeStats(num, minYear, maxYear);

      return cs;
    }


    ///
    /// <summary>
    /// Returns all the areas in Chicago, ordered by area # or name.
    /// </summary>
    /// <param name="ordering"></param>
    /// <returns>List of Area objects</returns>
    /// 
    public List<Area> GetChicagoAreas(OrderAreas ordering)
    {
      List<Area> areas = new List<Area>();

      var dat = dataTier.ExecuteNonScalarQuery("SELECT Area, AreaName FROM Areas ORDER BY AreaName ASC;");
      foreach(DataRow row in dat.Tables["TABLE"].Rows)
      {
       areas.Add(new Area(Convert.ToInt32(row["Area"]), row["AreaName"].ToString()));
      }
      return areas;
    }


    ///
    /// <summary>
    /// Returns all the crime codes and their descriptions.
    /// </summary>
    /// <returns>List of CrimeCode objects</returns>
    ///
    public List<CrimeCode> GetCrimeCodes()
    {
      List<CrimeCode> codes = new List<CrimeCode>();

      var dat = dataTier.ExecuteNonScalarQuery("SELECT IUCR, PrimaryDesc, SecondaryDesc FROM codes ORDER BY IUCR ASC;");
      foreach (DataRow row in dat.Tables["TABLE"].Rows)
      {
        codes.Add(new CrimeCode(row["IUCR"].ToString(), row["PrimaryDesc"].ToString(), row["SecondaryDesc"].ToString()));
      }

      return codes;
    }


    ///
    /// <summary>
    /// Returns a hash table of years, and total crimes each year.
    /// </summary>
    /// <returns>Dictionary where year is the key, and total crimes is the value</returns>
    ///
    public Dictionary<int, long> GetTotalsByYear()
    {
      Dictionary<int, long> totalsByYear = new Dictionary<int, long>();

      var dat = dataTier.ExecuteNonScalarQuery("SELECT Count(*) AS NumCrimes, year, COUNT(NULLIF(arrested,0)) AS arrested FROM crimes GROUP BY year ORDER BY year ASC;");
      foreach(DataRow row in dat.Tables["TABLE"].Rows)
      {
        totalsByYear.Add(Convert.ToInt32(row["Year"]), Convert.ToInt64(row["NumCrimes"]));
      }
      return totalsByYear;
    }


    ///
    /// <summary>
    /// Returns a hash table of months, and total crimes each month.
    /// </summary>
    /// <returns>Dictionary where month is the key, and total crimes is the value</returns>
    /// 
    public Dictionary<int, long> GetTotalsByMonth()
    {
      Dictionary<int, long> totalsByMonth = new Dictionary<int, long>();

      var dat = dataTier.ExecuteNonScalarQuery("SELECT RIGHT (LEFT (CrimeDate, 7), 2) AS Month, Count(*) as NumCrimes FROM Crimes Group By RIGHT(LEFT(CrimeDate, 7), 2) ORDER BY RIGHT(LEFT(CrimeDate, 7), 2) ASC;");
      foreach (DataRow row in dat.Tables["TABLE"].Rows)
      {
        totalsByMonth.Add(Convert.ToInt32(row["Month"]), Convert.ToInt64(row["NumCrimes"]));
      }

      return totalsByMonth;
    }


    ///
    /// <summary>
    /// Returns a hash table of areas, and total crimes each area.
    /// </summary>
    /// <returns>Dictionary where area # is the key, and total crimes is the value</returns>
    ///
    public Dictionary<int, long> GetTotalsByArea()
    {
      Dictionary<int, long> totalsByArea = new Dictionary<int, long>();

      var dat = dataTier.ExecuteNonScalarQuery(@"SELECT Count(*) AS NumCrimes, Area
                                      FROM crimes
                                      GROUP BY Area
                                      ORDER BY Area ASC;");

      foreach (DataRow row in dat.Tables["TABLE"].Rows)
      {
        if (Convert.ToInt32(row["Area"]) == 0) continue;
        totalsByArea.Add(Convert.ToInt32(row["Area"]), Convert.ToInt64(row["NumCrimes"]));
      }

      return totalsByArea;
    }


    ///
    /// <summary>
    /// Returns a hash table of years, and arrest percentages each year.
    /// </summary>
    /// <returns>Dictionary where the year is the key, and the arrest percentage is the value</returns>
    /// 
    public Dictionary<int, double> GetArrestPercentagesByYear()
    {
      Dictionary<int, double> percentagesByYear = new Dictionary<int, double>();

      var dat = dataTier.ExecuteNonScalarQuery("SELECT Count(*) AS NumCrimes, year, COUNT(NULLIF(arrested,0)) AS arrested FROM crimes GROUP BY year ORDER BY year ASC;");
      foreach (DataRow row in dat.Tables["TABLE"].Rows)
      {
        percentagesByYear.Add(Convert.ToInt32(row["Year"]), Convert.ToDouble(row["arrested"])/Convert.ToDouble(row["NumCrimes"])*100);
      }

      return percentagesByYear;
    }


    public Dictionary<String, long> GetTopNTotalsByArea(int n)
    {
      Dictionary<String, long> topNbyArea = new Dictionary<String, long>();
      
      var dat = dataTier.ExecuteNonScalarQuery(@"SELECT TOP "+n.ToString()+@" T.AreaName, Count(*) AS NumCrimes FROM crimes 
                                                          INNER JOIN (Select Area, AreaName From Areas) As T
                                                          ON(Crimes.Area = T.Area AND T.Area <> 0)
                                                          GROUP BY T.AreaName
                                                          ORDER BY NumCrimes DESC;");
      foreach (DataRow row in dat.Tables["TABLE"].Rows)
      {
        topNbyArea.Add(row["AreaName"].ToString(), Convert.ToInt64(row["NumCrimes"]));
      }
      return topNbyArea;
    }

    public Dictionary<CrimeCode, long> GetTopNCrimes(int n)
    {
      Dictionary<CrimeCode, long> topNCrimes = new Dictionary<CrimeCode, long>();
      var dat = dataTier.ExecuteNonScalarQuery((@"SELECT TOP " + n.ToString() + @" T.PrimaryDesc, T.SecondaryDesc, Count(*) as NumCrimes
                                                From Crimes
                                                INNER JOIN 
                                                ( Select PrimaryDesc, SecondaryDesc, IUCR From Codes) As T
                                                ON Crimes.IUCR = T.IUCR
                                                GROUP BY T.PrimaryDesc, T.SecondaryDesc
                                                ORDER BY NumCrimes DESC;"));
      foreach (DataRow row in dat.Tables["TABLE"].Rows)
      {
        topNCrimes.Add(new CrimeCode(null, row["PrimaryDesc"].ToString(), row["SecondaryDesc"].ToString()), Convert.ToInt64(row["NumCrimes"]));
      }

      return topNCrimes;
    }

    public Dictionary<CrimeCode, long> getTopNByIUCR(int n, int areaNum)
    {
      Dictionary<CrimeCode, long> topNCrimesByIUCR = new Dictionary<CrimeCode, long>();
      var dat = dataTier.ExecuteNonScalarQuery((@"SELECT TOP " + n.ToString() + @" T.PrimaryDesc, T.SecondaryDesc, Crimes.Area, U.AreaName, Count(*) AS NumCrimes
                                                  FROM Crimes
                                                  INNER JOIN (SELECT Codes.PrimaryDesc, Codes.SecondaryDesc, Codes.IUCR from Codes) AS T
                                                  ON T.IUCR = Crimes.IUCR AND Crimes.Area = " + areaNum + @"
                                                  INNER JOIN (SELECT Areas.AreaName, Areas.Area from Areas) As U
                                                  ON U.Area = " + areaNum + @"
                                                  GROUP BY T.PrimaryDesc, T.SecondaryDesc, Crimes.Area, U.AreaName
                                                  ORDER BY NumCrimes DESC;"));
      foreach (DataRow row in dat.Tables["TABLE"].Rows)
      {
        topNCrimesByIUCR.Add(new CrimeCode(null, row["PrimaryDesc"].ToString(), row["SecondaryDesc"].ToString()), Convert.ToInt64(row["NumCrimes"]));
      }
      return topNCrimesByIUCR;
    }

    public Dictionary<CrimeCode, long> getCrimesByAreaNameYearRange(String aName, int beginYear, int endYear)
    {
      Dictionary<CrimeCode, long> generic = new Dictionary<CrimeCode, long>();
      var dat = dataTier.ExecuteNonScalarQuery(@"SELECT T.PrimaryDesc, T.SecondaryDesc, Count(*) AS NumCrimes
                                                FROM Crimes
                                                INNER JOIN (SELECT Codes.PrimaryDesc, Codes.SecondaryDesc, Codes.IUCR FROM Codes) as T
                                                ON T.IUCR = Crimes.IUCR
                                                WHERE Crimes.Area = (SELECT Areas.Area FROM Areas WHERE AreaName = '" + aName + @"')
                                                AND Crimes.Year >= " + beginYear + @" AND Crimes.Year <= " + endYear + @"
                                                GROUP BY T.PrimaryDesc, T.SecondaryDesc
                                                ORDER BY NumCrimes DESC;");

      foreach (DataRow row in dat.Tables["TABLE"].Rows)
      {
        generic.Add(new CrimeCode(null, row["PrimaryDesc"].ToString(), row["SecondaryDesc"].ToString()), Convert.ToInt64(row["NumCrimes"]));
      }

      return generic;
    }

    public long byCriteria(String Sarea, String Syear, String Siucr)
    {
      int area = -1, year = -1;
      String iucr = "";
      bool isArea = false, isyear = false, isiucr = false, where = false, first = true;
      try
      {
        if (!String.IsNullOrWhiteSpace(Sarea))
        {
          isArea = true;
          area = Convert.ToInt32(Sarea);
        }
        if (!String.IsNullOrWhiteSpace(Syear))
        {
          isyear = true;
          year = Convert.ToInt32(Syear);
        }
        if (!String.IsNullOrWhiteSpace(Siucr))
        {
          isiucr = true;
          iucr = Siucr.Replace("'", "''");
        }
      }
      #pragma warning disable
      catch (Exception exept)
      {
        System.Windows.Forms.MessageBox.Show(String.Format("One of the numeric arguments is not a number!"));
        return 0;
      }
      String query = "SELECT COUNT(*) as NumCrimes FROM CRIMES";
      if (isArea)
      {
        if (!where)
        {
          query += " WHERE";
          where = true;
        }
        query += String.Format(" AREA = {0}", area);
        first = false;
      }
      if (isyear)
      {
        if (!where)
        {
          query += " WHERE";
          where = true;
        }
        if (!first)
          query += " AND";
        query += String.Format(" YEAR = {0}", year);
        first = false;
      }
      if (isiucr)
      {
        if (!where)
        {
          query += " WHERE";
          where = true;
        }
        if (!first)
          query += " AND";
        query += String.Format(" IUCR = '{0}'", iucr);
        first = false;
      }

      return Convert.ToInt64(dataTier.ExecuteScalarQuery(query));
    }

  }//class
}//namespace
