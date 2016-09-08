using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using CHART = System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApplication1
{
  public partial class Form1 : Form
  {
    SqlConnection db;
    String fname, ver, connInfo;

    private void genCrimeCodes_Click(object sender, EventArgs e)
    {
      listBox1.Items.Clear();
      string fname = this.txtDBFile.Text;

      BusinessTier.Business biztier;

      biztier = new BusinessTier.Business(fname);

      if (biztier.OpenCloseConnection() == false)
      {
        MessageBox.Show("Error, unable to connect to database!");
        return;
      }

      var codes = biztier.GetCrimeCodes();
      foreach(var code in codes)
      {
        String txt = String.Format("{0}: {1}, {2}", code.IUCR, code.PrimaryDescription, code.SecondaryDescription);
        this.listBox1.Items.Add(txt);
      }

      /*ver = "MSSQLLocalDB";
      fname = "CrimeDB.mdf";
      connInfo = String.Format(@"Data Source=(LocalDB)\{0};
                               AttachDbFilename=|DataDirectory|\{1};
                               Integrated Security = True;",
                               ver, fname);
      db = new SqlConnection(connInfo);
      db.Open();
      SqlCommand cmd = new SqlCommand();
      cmd.Connection = db;
      cmd.CommandText = String.Format(@"SELECT IUCR, PrimaryDesc, SecondaryDesc
                                      FROM codes
                                      ORDER BY IUCR ASC
                                      ");
      SqlDataAdapter adapter = new SqlDataAdapter(cmd);
      DataSet ds = new DataSet();
      adapter.Fill(ds);
      listBox1.Items.Clear();
      foreach (DataRow row in ds.Tables["TABLE"].Rows)
      {
        String msg = string.Format("{0} | {1}: {2}", row["IUCR"], row["PrimaryDesc"], row["SecondaryDesc"]);
        this.listBox1.Items.Add(msg);
      }
      db.Close();*/
    }

    private void areas_Click(object sender, EventArgs e)
    {
      listBox1.Items.Clear();
      string fname = this.txtDBFile.Text;

      BusinessTier.Business biztier;

      biztier = new BusinessTier.Business(fname);

      if (biztier.OpenCloseConnection() == false)
      {
        MessageBox.Show("Error, unable to connect to database!");
        return;
      }

      var areas = biztier.GetChicagoAreas(BusinessTier.OrderAreas.ByName);
      foreach (var area in areas)
      {
        String txt = String.Format("{0}: {1}", area.AreaNumber, area.AreaName);
        this.listBox1.Items.Add(txt);
      }
      /*ver = "MSSQLLocalDB";
      fname = "CrimeDB.mdf";
      connInfo = String.Format(@"Data Source=(LocalDB)\{0};
                               AttachDbFilename=|DataDirectory|\{1};
                               Integrated Security = True;",
                               ver, fname);
      db = new SqlConnection(connInfo);
      db.Open();
      SqlCommand cmd = new SqlCommand();
      cmd.Connection = db;
      cmd.CommandText = String.Format(@"SELECT Area, AreaName
                                      FROM Areas
                                      ORDER BY AreaName ASC
                                      ");
      SqlDataAdapter adapter = new SqlDataAdapter(cmd);
      DataSet ds = new DataSet();
      adapter.Fill(ds);
      listBox1.Items.Clear();
      foreach (DataRow row in ds.Tables["TABLE"].Rows)
      {
        String msg = string.Format("{0}: {1}", row["Area"], row["AreaName"]);
        this.listBox1.Items.Add(msg);
      }
      db.Close();*/
    }

    private void plotCrimesYear_Click(object sender, EventArgs e)
    {
      this.chart1.Series.Clear();
      this.listBox1.Items.Clear();
      var series1 = new CHART.Series
      {
        Name = "Series1",
        Color = System.Drawing.Color.Green,
        IsVisibleInLegend = false,
        IsXValueIndexed = true,
        ChartType = CHART.SeriesChartType.Line
      };
      this.chart1.Series.Add(series1);
      string fname = this.txtDBFile.Text;

      BusinessTier.Business biztier;

      biztier = new BusinessTier.Business(fname);

      if (biztier.OpenCloseConnection() == false)
      {
        MessageBox.Show("Error, unable to connect to database!");
        return;
      }

      Dictionary<int, long> stats = biztier.GetTotalsByYear();
      foreach (var elem in stats)
      {
        String txt = String.Format("{0}: {1} crimes", elem.Key, elem.Value);
        this.listBox1.Items.Add(txt);
        series1.Points.AddXY(Convert.ToInt32(elem.Key), Convert.ToInt32(elem.Value));
      }

      /*this.chart1.Series.Clear();
      var series1 = new CHART.Series
      {
        Name = "Series1",
        Color = System.Drawing.Color.Green,
        IsVisibleInLegend = false,
        IsXValueIndexed = true,
        ChartType = CHART.SeriesChartType.Line
      };
      this.chart1.Series.Add(series1);
      listBox1.Items.Clear();
      ver = "MSSQLLocalDB";
      fname = "CrimeDB.mdf";
      connInfo = String.Format(@"Data Source=(LocalDB)\{0};
                               AttachDbFilename=|DataDirectory|\{1};
                               Integrated Security = True;",
                               ver, fname);
      db = new SqlConnection(connInfo);
      db.Open();
      SqlCommand cmd = new SqlCommand();
      cmd.Connection = db;
      cmd.CommandText = String.Format(@"SELECT Count(*) AS NumCrimes, Year
                                      FROM crimes
                                      GROUP BY Year
                                      ORDER BY Year ASC
                                      ");
      SqlDataAdapter adapter = new SqlDataAdapter(cmd);
      DataSet ds = new DataSet();
      adapter.Fill(ds);
      listBox1.Items.Clear();
      foreach (DataRow row in ds.Tables["TABLE"].Rows)
      {
        String msg = string.Format("{0}: {1}", row["Year"], row["NumCrimes"]);
        this.listBox1.Items.Add(msg);
        series1.Points.AddXY(Convert.ToInt32(row["Year"]), Convert.ToInt32(row["NumCrimes"]));
      }
      db.Close();*/
    }

    private void crimesPerArea_Click(object sender, EventArgs e)
    {
      this.chart1.Series.Clear();
      this.listBox1.Items.Clear();
      var series1 = new CHART.Series
      {
        Name = "Series1",
        Color = System.Drawing.Color.Green,
        IsVisibleInLegend = false,
        IsXValueIndexed = true,
        ChartType = CHART.SeriesChartType.Line
      };
      this.chart1.Series.Add(series1);
      string fname = this.txtDBFile.Text;

      BusinessTier.Business biztier;

      biztier = new BusinessTier.Business(fname);

      if (biztier.OpenCloseConnection() == false)
      {
        MessageBox.Show("Error, unable to connect to database!");
        return;
      }

      Dictionary<int, long> stats = biztier.GetTotalsByArea();
      foreach (var elem in stats)
      {
        String txt = String.Format("{0}: {1} crimes", elem.Key, elem.Value);
        this.listBox1.Items.Add(txt);
        series1.Points.AddXY(Convert.ToInt32(elem.Key), Convert.ToInt32(elem.Value));
      }

      /*this.chart1.Series.Clear();
      var series1 = new CHART.Series
      {
        Name = "Series1",
        Color = System.Drawing.Color.Green,
        IsVisibleInLegend = false,
        IsXValueIndexed = true,
        ChartType = CHART.SeriesChartType.Line
      };
      this.chart1.Series.Add(series1);
      listBox1.Items.Clear();
      ver = "MSSQLLocalDB";
      fname = "CrimeDB.mdf";
      connInfo = String.Format(@"Data Source=(LocalDB)\{0};
                               AttachDbFilename=|DataDirectory|\{1};
                               Integrated Security = True;",
                               ver, fname);
      db = new SqlConnection(connInfo);
      db.Open();
      SqlCommand cmd = new SqlCommand();
      cmd.Connection = db;
      cmd.CommandText = String.Format(@"SELECT Count(*) AS NumCrimes, Area
                                      FROM crimes
                                      GROUP BY Area
                                      ORDER BY Area ASC
                                      ");
      SqlDataAdapter adapter = new SqlDataAdapter(cmd);
      DataSet ds = new DataSet();
      adapter.Fill(ds);
      listBox1.Items.Clear();
      foreach (DataRow row in ds.Tables["TABLE"].Rows)
      {
        if (Convert.ToInt32(row["Area"]) != 0) {
        String msg = string.Format("{0}: {1}", row["Area"], row["NumCrimes"]);
        this.listBox1.Items.Add(msg);
        series1.Points.AddXY(Convert.ToInt32(row["Area"]), Convert.ToInt32(row["NumCrimes"]));
        }
      }
      db.Close();*/
    }

    private void crimesPerMonth_Click(object sender, EventArgs e)
    {
      this.chart1.Series.Clear();
      this.listBox1.Items.Clear();
      var series1 = new CHART.Series
      {
        Name = "Series1",
        Color = System.Drawing.Color.Green,
        IsVisibleInLegend = false,
        IsXValueIndexed = true,
        ChartType = CHART.SeriesChartType.Line
      };
      this.chart1.Series.Add(series1);
      string fname = this.txtDBFile.Text;

      BusinessTier.Business biztier;

      biztier = new BusinessTier.Business(fname);

      if (biztier.OpenCloseConnection() == false)
      {
        MessageBox.Show("Error, unable to connect to database!");
        return;
      }

      var stats = biztier.GetTotalsByMonth();
      foreach (var elem in stats)
      {
        String txt = String.Format("{0}: {1} crimes", elem.Key, elem.Value);
        this.listBox1.Items.Add(txt);
        series1.Points.AddXY(Convert.ToInt32(elem.Key), Convert.ToInt32(elem.Value));
      }

      /*this.chart1.Series.Clear();
      var series1 = new CHART.Series
      {
        Name = "Series1",
        Color = System.Drawing.Color.Green,
        IsVisibleInLegend = false,
        IsXValueIndexed = true,
        ChartType = CHART.SeriesChartType.Line
      };
      this.chart1.Series.Add(series1);
      listBox1.Items.Clear();
      ver = "MSSQLLocalDB";
      fname = "CrimeDB.mdf";
      connInfo = String.Format(@"Data Source=(LocalDB)\{0};
                               AttachDbFilename=|DataDirectory|\{1};
                               Integrated Security = True;",
                               ver, fname);
      db = new SqlConnection(connInfo);
      db.Open();
      SqlCommand cmd = new SqlCommand();
      cmd.Connection = db;
      cmd.CommandText = String.Format(@"SELECT RIGHT (LEFT (CrimeDate, 7), 2), Count(*) as NumCrimes
                                      FROM Crimes
                                      Group By RIGHT (LEFT (CrimeDate, 7), 2)
                                      ORDER BY RIGHT (LEFT (CrimeDate, 7), 2) ASC;
                                      ");
                                      
      SqlDataAdapter adapter = new SqlDataAdapter(cmd);
      DataSet ds = new DataSet();
      adapter.Fill(ds);
      listBox1.Items.Clear();
      foreach (DataRow row in ds.Tables["TABLE"].Rows)
      {
          String msg = string.Format("{0}: {1}", row[0], row["NumCrimes"]);
          this.listBox1.Items.Add(msg);
          series1.Points.AddXY(row[0], Convert.ToInt32(row["NumCrimes"]));
      }
      db.Close();*/
    }

    private void topNAreas(object sender, EventArgs e)
    {
      listBox1.Items.Clear();
      BusinessTier.Business biztier;

      string fname = this.txtDBFile.Text;

      biztier = new BusinessTier.Business(fname);

      if (biztier.OpenCloseConnection() == false)
      {
        MessageBox.Show("Error, unable to connect to database!");
        return;
      }
      int n;
      try
      {
        n = Convert.ToInt32(valueOfN.Text);
      }
      #pragma warning disable
      catch (Exception exept)
      {
        System.Windows.Forms.MessageBox.Show(String.Format("{0} is not a number!", valueOfN.Text));
        return;
      }
      //var q = biztier.GetTopNCrimes(1);
      var items = biztier.GetTopNTotalsByArea(n);
      foreach (var thing in items)
      {
        String msg = string.Format("{0}: {1}", thing.Key, thing.Value);
        this.listBox1.Items.Add(msg);
      }






      /*int n;
      try
      {
        n = Convert.ToInt32(valueOfN.Text);
      }
      catch (Exception exept)
      {
        System.Windows.Forms.MessageBox.Show(String.Format("{0} is not a number!", valueOfN.Text));
        return;
      }
      ver = "MSSQLLocalDB";
      fname = "CrimeDB.mdf";
      connInfo = String.Format(@"Data Source=(LocalDB)\{0};
                               AttachDbFilename=|DataDirectory|\{1};
                               Integrated Security = True;",
                          ver, fname);
      db = new SqlConnection(connInfo);
      db.Open();
      SqlCommand cmd = new SqlCommand();
      cmd.Connection = db;
      cmd.CommandText = String.Format(@"SELECT T.AreaName, Count(*) as NumCrimes
                                        From Crimes
                                        INNER JOIN 
                                        ( Select Area, AreaName From Areas) As T
                                        ON (Crimes.Area = T.Area AND T.Area <> 0)
                                        GROUP BY T.AreaName
                                        ORDER BY NumCrimes DESC;");
      cmd.Connection = db;
      //cmd.CommandText = String.Format(@"SELECT Count(*) AS NumCrimes, area
      //                   ");
      SqlDataAdapter adapter = new SqlDataAdapter(cmd);
      DataSet ds = new DataSet();
      adapter.Fill(ds);
      listBox1.Items.Clear();
      int i = 0;
      foreach (DataRow row in ds.Tables["TABLE"].Rows)
      {
        if (n == 0) break;
        i++;
        String msg = string.Format("{0}: {1}", row["AreaName"], row["NumCrimes"]);
        this.listBox1.Items.Add(msg);
        if (i == n) break;
      }
      db.Close();
      */
    }

    private void crimesByCriteria_Click(object sender, EventArgs e)
    {
      listBox1.Items.Clear();
      BusinessTier.Business biztier;

      string fname = this.txtDBFile.Text;

      biztier = new BusinessTier.Business(fname);

      if (biztier.OpenCloseConnection() == false)
      {
        MessageBox.Show("Error, unable to connect to database!");
        return;
      }

      var item = biztier.byCriteria(areaText.Text, yearText.Text, iucrTEXT.Text);

      this.listBox1.Items.Add(String.Format("Number of crimes: {0}", item));

      /*int area = -1, year = -1;
      String iucr = "";
      bool isArea = false, isyear = false, isiucr = false, where = false, first = true;
      listBox1.Items.Clear();
      try
      {
        if (!String.IsNullOrWhiteSpace(areaText.Text)) {
          isArea = true;
          area = Convert.ToInt32(areaText.Text);
        }
        if (!String.IsNullOrWhiteSpace(yearText.Text))
        {
          isyear = true;
          year = Convert.ToInt32(yearText.Text);
        }
        if (!String.IsNullOrWhiteSpace(iucrTEXT.Text))
        {
          isiucr = true;
          iucr = iucrTEXT.Text.Replace("'", "''");
        }
      }
      catch (Exception exept)
      {
        System.Windows.Forms.MessageBox.Show(String.Format("One of the numeric arguments is not a number!"));
        return;
      }
      ver = "MSSQLLocalDB";
      fname = "CrimeDB.mdf";
      connInfo = String.Format(@"Data Source=(LocalDB)\{0};
                               AttachDbFilename=|DataDirectory|\{1};
                               Integrated Security = True;",
                               ver, fname);
      db = new SqlConnection(connInfo);
      db.Open();
      SqlCommand cmd = new SqlCommand();
      cmd.Connection = db;
      String query = "SELECT COUNT(*) as NumCrimes FROM CRIMES";
      if (isArea) {
        if (!where) {
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
      cmd.CommandText = query;
      SqlDataAdapter adapter = new SqlDataAdapter(cmd);
      DataSet ds = new DataSet();
      adapter.Fill(ds);
      listBox1.Items.Clear();
      foreach (DataRow row in ds.Tables["TABLE"].Rows)
      {
        String msg = String.Format("Number of crimes: {0}", row["NumCrimes"]);
        this.listBox1.Items.Add(msg);
      }
      db.Close();
      */
    }

    private void crimesByAreaForYearRange_Click(object sender, EventArgs e)
    {

      listBox1.Items.Clear();
      int beginYear, endYear;
      try
      {
        beginYear = Convert.ToInt32(yearText.Text);
        endYear = Convert.ToInt32(textBox2.Text);
      }
      catch (Exception exept)
      {
        System.Windows.Forms.MessageBox.Show(String.Format("One of the numeric arguments is not a number!", valueOfN.Text));
        return;
      }
      String aName = textBox1.Text;
      aName = aName.Replace("'", "''");

      BusinessTier.Business biztier;

      string fname = this.txtDBFile.Text;

      biztier = new BusinessTier.Business(fname);

      if (biztier.OpenCloseConnection() == false)
      {
        MessageBox.Show("Error, unable to connect to database!");
        return;
      }

      var dat = biztier.getCrimesByAreaNameYearRange(aName, beginYear, endYear);
      foreach (var thing in dat)
      {
        String msg = string.Format("{0} - {1}: {2}", thing.Key.PrimaryDescription, thing.Key.SecondaryDescription, thing.Value);
        this.listBox1.Items.Add(msg);
      }

      /*
      ver = "MSSQLLocalDB";
      fname = "CrimeDB.mdf";
      connInfo = String.Format(@"Data Source=(LocalDB)\{0};
                               AttachDbFilename=|DataDirectory|\{1};
                               Integrated Security = True;",
                          ver, fname);
      db = new SqlConnection(connInfo);
      db.Open();
      SqlCommand cmd = new SqlCommand();
      cmd.Connection = db;
      cmd.CommandText = String.Format(@"SELECT T.PrimaryDesc, T.SecondaryDesc, Count(*) AS NumCrimes
                                       FROM Crimes
                                         INNER JOIN (SELECT Codes.PrimaryDesc, Codes.SecondaryDesc, Codes.IUCR FROM Codes) as T
                                         ON T.IUCR = Crimes.IUCR
                                         WHERE Crimes.Area = (SELECT Areas.Area FROM Areas WHERE AreaName = '" + aName + @"')
                                             AND Crimes.Year >= " + beginYear + @" AND Crimes.Year <= " + endYear + @"
                                         GROUP BY T.PrimaryDesc, T.SecondaryDesc
                                         ORDER BY NumCrimes DESC;");
      cmd.Connection = db;
      //cmd.CommandText = String.Format(@"SELECT Count(*) AS NumCrimes, area
      //                   ");
      SqlDataAdapter adapter = new SqlDataAdapter(cmd);
      DataSet ds = new DataSet();
      adapter.Fill(ds);
      listBox1.Items.Clear();
      int i = 0;
      foreach (DataRow row in ds.Tables["TABLE"].Rows)
      {
        if (n == 0) break;
        if (i == 0) this.listBox1.Items.Add(String.Format("For Area {0} and years {1} through {2}", aName, beginYear, endYear));
        i++;
        String msg = string.Format("{0} - {1}: {2}", row["PrimaryDesc"], row["SecondaryDesc"], row["NumCrimes"]);
        this.listBox1.Items.Add(msg);
        if (n == i) break;
      }
      if (ds.Tables["TABLE"] == null)
      {
        this.listBox1.Items.Add("No data for selected parameters.");
      }
      db.Close();
      */

    }

    private void button2_Click(object sender, EventArgs e)
    {
      listBox1.Items.Clear();
      BusinessTier.Business biztier;

      string fname = this.txtDBFile.Text;

      biztier = new BusinessTier.Business(fname);

      if (biztier.OpenCloseConnection() == false)
      {
        MessageBox.Show("Error, unable to connect to database!");
        return;
      }
      int n;
      try
      {
        n = Convert.ToInt32(valueOfN.Text);
      }
      #pragma warning disable
      catch (Exception exept)
      {
        System.Windows.Forms.MessageBox.Show(String.Format("{0} is not a number!", valueOfN.Text));
        return;
      }
      //var q = biztier.GetTopNCrimes(1);
      var items = biztier.GetTopNCrimes(n);
      foreach (var thing in items)
      {
        String msg = string.Format("{0}, {1}: {2}", thing.Key.PrimaryDescription, thing.Key.SecondaryDescription, thing.Value);
        this.listBox1.Items.Add(msg);
      }

      /*int n;
      try
      {
        n = Convert.ToInt32(valueOfN.Text);
      }
      catch (Exception exept)
      {
        System.Windows.Forms.MessageBox.Show(String.Format("{0} is not a number!", valueOfN.Text));
        return;
      }
      ver = "MSSQLLocalDB";
      fname = "CrimeDB.mdf";
      connInfo = String.Format(@"Data Source=(LocalDB)\{0};
                               AttachDbFilename=|DataDirectory|\{1};
                               Integrated Security = True;",
                          ver, fname);
      db = new SqlConnection(connInfo);
      db.Open();
      SqlCommand cmd = new SqlCommand();
      cmd.Connection = db;
      cmd.CommandText = String.Format(@"SELECT T.PrimaryDesc, T.SecondaryDesc, Count(*) as NumCrimes
                                        From Crimes
                                        INNER JOIN 
                                        ( Select PrimaryDesc, SecondaryDesc, IUCR From Codes) As T
                                        ON Crimes.IUCR = T.IUCR
                                        GROUP BY T.PrimaryDesc, T.SecondaryDesc
                                        ORDER BY NumCrimes DESC;");
      cmd.Connection = db;
      //cmd.CommandText = String.Format(@"SELECT Count(*) AS NumCrimes, area
      //                   ");
      SqlDataAdapter adapter = new SqlDataAdapter(cmd);
      DataSet ds = new DataSet();
      adapter.Fill(ds);
      listBox1.Items.Clear();
      int i = 0;
      foreach (DataRow row in ds.Tables["TABLE"].Rows)
      {
        if (n == 0) break;
        i++;
        String msg = string.Format("{0} - {1}: {2}", row["PrimaryDesc"], row["SecondaryDesc"], row["NumCrimes"]);
        this.listBox1.Items.Add(msg);
        if (i == n) break;
      }
      db.Close();
      */
    }

    private void button4_Click(object sender, EventArgs e)
    {
      int areaNum, n;
      listBox1.Items.Clear();
      try
      {
        areaNum = Convert.ToInt32(areaText.Text);
        n = Convert.ToInt32(valueOfN.Text);
      }
      catch (Exception exept)
      {
        System.Windows.Forms.MessageBox.Show(String.Format("Please input a valid number!"));
        return;
      }

      BusinessTier.Business biztier;

      string fname = this.txtDBFile.Text;

      biztier = new BusinessTier.Business(fname);

      if (biztier.OpenCloseConnection() == false)
      {
        MessageBox.Show("Error, unable to connect to database!");
        return;
      }
      //var q = biztier.GetTopNCrimes(1);
      var items = biztier.getTopNByIUCR(n, areaNum);
      foreach (var thing in items)
      {
        String msg = string.Format("{0}, {1}: {2}", thing.Key.PrimaryDescription, thing.Key.SecondaryDescription, thing.Value);
        this.listBox1.Items.Add(msg);
      }

      /*int areaNum, n;
      try
      {
        areaNum = Convert.ToInt32(areaText.Text);
        n = Convert.ToInt32(valueOfN.Text);
      }
      catch (Exception exept)
      {
        System.Windows.Forms.MessageBox.Show(String.Format("Please input a valid number!"));
        return;
      }
      ver = "MSSQLLocalDB";
      fname = "CrimeDB.mdf";
      connInfo = String.Format(@"Data Source=(LocalDB)\{0};
                               AttachDbFilename=|DataDirectory|\{1};
                               Integrated Security = True;",
                          ver, fname);
      db = new SqlConnection(connInfo);
      db.Open();
      SqlCommand cmd = new SqlCommand();
      cmd.Connection = db;
      String sql = @"SELECT T.PrimaryDesc, T.SecondaryDesc, Crimes.Area, U.AreaName, Count(*) AS NumCrimes
                     FROM Crimes
                       INNER JOIN 
                         (SELECT Codes.PrimaryDesc, Codes.SecondaryDesc, Codes.IUCR from Codes) AS T
                         ON T.IUCR = Crimes.IUCR AND Crimes.Area = " + areaNum + @"
                       INNER JOIN
                         (SELECT Areas.AreaName, Areas.Area from Areas) As U
                          ON U.Area = " + areaNum + @"
                       GROUP BY T.PrimaryDesc, T.SecondaryDesc, Crimes.Area, U.AreaName
                       ORDER BY NumCrimes DESC;";
      cmd.CommandText = String.Format(sql);
      cmd.Connection = db;
      //cmd.CommandText = String.Format(@"SELECT Count(*) AS NumCrimes, area
      //                   ");
      SqlDataAdapter adapter = new SqlDataAdapter(cmd);
      DataSet ds = new DataSet();
      adapter.Fill(ds);
      listBox1.Items.Clear();
      int i = 0;

      foreach (DataRow row in ds.Tables["TABLE"].Rows)
      {
        if (i == 0) this.listBox1.Items.Add(String.Format("Area: {0}", row["AreaName"]));
        if (n <= 0) break;
        i++;
        String msg = string.Format("{0} - {1}: {2}", row["PrimaryDesc"], row["SecondaryDesc"], row["NumCrimes"]);
        this.listBox1.Items.Add(msg);
        if (i == n) break;
      }
      db.Close();
      */
    }

    private void textBox3_TextChanged(object sender, EventArgs e)
    {
      ;
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      string fname = this.txtDBFile.Text;

      BusinessTier.Business biztier;

      biztier = new BusinessTier.Business(fname);

      if (biztier.OpenCloseConnection() == false)
      {
        MessageBox.Show("Error, unable to connect to database!");
        return;
      }

      BusinessTier.CrimeStats stats;

      stats = biztier.GetOverallCrimeStats();

      int minYear = stats.MinYear;
      int maxYear = stats.MaxYear;
      long total = stats.TotalCrimes;

      string title =
        string.Format(@"Chicago Crime Analysis from {0} - {1}, total of {2:#,##0} crimes",
                                   minYear, maxYear, total);
      this.Text = title;
      /*this.chart1.Series.Clear();
      ver = "MSSQLLocalDB";
      fname = "CrimeDB.mdf";
      //MessageBox.Show("Connecting...");
      connInfo = String.Format(@"Data Source=(LocalDB)\{0};
                               AttachDbFilename=|DataDirectory|\{1};
                               Integrated Security = True;",
                               ver, fname);
      db = new SqlConnection(connInfo);
      db.Open();
      //MessageBox.Show("Connected!");
      SqlCommand cmd = new SqlCommand();
      cmd.Connection = db;
      cmd.CommandText = @"SELECT Count(*)
                        FROM crimes";
      object result = cmd.ExecuteScalar();
      if (result == null)
        return;
      else if (result == DBNull.Value)
        return;
      else
        this.Text += (": " + Convert.ToString(result) + " Total crimes from years");

      cmd.CommandText = @"SELECT MIN(year)
                         FROM crimes";
      result = cmd.ExecuteScalar();
      this.Text += " " + Convert.ToString(result);
      cmd.CommandText = @"SELECT MAX(year)
                         FROM crimes";
      result = cmd.ExecuteScalar();
      this.Text += " through " + Convert.ToString(result);
      db.Close();*/
    }

    private void CrimesPerYear_Click(object sender, EventArgs e)
    {
      listBox1.Items.Clear();
      string fname = this.txtDBFile.Text;

      BusinessTier.Business biztier;

      biztier = new BusinessTier.Business(fname);

      if (biztier.OpenCloseConnection() == false)
      {
        MessageBox.Show("Error, unable to connect to database!");
        return;
      }

      Dictionary<int, long> stats = biztier.GetTotalsByYear();
      var bonk = biztier.GetArrestPercentagesByYear();
      foreach(var elem in stats){
        String txt = String.Format("{0}: {1} crimes", elem.Key, elem.Value);
        String txt2 = String.Format("{0}; {1}% arrested", txt, bonk[elem.Key]);
        this.listBox1.Items.Add(txt2);
      }

      
      /*
      listBox1.Items.Clear();
      ver = "MSSQLLocalDB";
      fname = "CrimeDB.mdf";
      connInfo = String.Format(@"Data Source=(LocalDB)\{0};
                               AttachDbFilename=|DataDirectory|\{1};
                               Integrated Security = True;",
                               ver, fname);
      db = new SqlConnection(connInfo);
      db.Open();
      SqlCommand cmd = new SqlCommand();
      cmd.Connection = db;
      cmd.CommandText = String.Format(@"SELECT Count(*) AS NumCrimes, year, COUNT(NULLIF(arrested,0)) AS arrested
                          FROM crimes
                          GROUP BY year
                          ORDER BY year ASC
                         ");
      SqlDataAdapter adapter = new SqlDataAdapter(cmd);
      DataSet ds = new DataSet();
      adapter.Fill(ds);
      listBox1.Items.Clear();
      foreach (DataRow row in ds.Tables["TABLE"].Rows)
      {
        String msg = string.Format("{0}: {1}; {2}% Arrested", Convert.ToInt32(row["year"]),Convert.ToInt32(row["NumCrimes"]), (float)(Convert.ToInt32(row["arrested"])*100/(float)Convert.ToInt32(row["NumCrimes"])));
        this.listBox1.Items.Add(msg);
      }
      db.Close();*/
    }

    public Form1()
    {
      InitializeComponent();

    }
  }
}
