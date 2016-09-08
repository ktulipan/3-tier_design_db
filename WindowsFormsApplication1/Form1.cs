/* Kyle Tulipano
 * 3-tiered program to access data
 * stored in database
 * this is application tier -- UI elements
 * and obtaining data from Business (middleman) tier
 * only here.
 */


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
      var items = biztier.GetTopNTotalsByArea(n);
      foreach (var thing in items)
      {
        String msg = string.Format("{0}: {1}", thing.Key, thing.Value);
        this.listBox1.Items.Add(msg);
      }
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
      
    }

    public Form1()
    {
      InitializeComponent();

    }
  }
}
