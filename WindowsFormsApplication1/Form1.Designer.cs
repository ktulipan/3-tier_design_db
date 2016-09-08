namespace WindowsFormsApplication1
{
  partial class Form1
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.CrimesPerYear = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.genCrimeCodes = new System.Windows.Forms.Button();
            this.areas = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.plotCrimesYear = new System.Windows.Forms.Button();
            this.crimesPerArea = new System.Windows.Forms.Button();
            this.crimesPerMonth = new System.Windows.Forms.Button();
            this.crimesByCriteria = new System.Windows.Forms.Button();
            this.areaText = new System.Windows.Forms.TextBox();
            this.iucrTEXT = new System.Windows.Forms.TextBox();
            this.yearText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.valueOfN = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.topn = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.AreaName = new System.Windows.Forms.Label();
            this.crimesByAreaForYearRange = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.txtDBFile = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Console", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(79, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 32);
            this.label1.TabIndex = 0;
            // 
            // CrimesPerYear
            // 
            this.CrimesPerYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CrimesPerYear.Location = new System.Drawing.Point(12, 12);
            this.CrimesPerYear.Name = "CrimesPerYear";
            this.CrimesPerYear.Size = new System.Drawing.Size(92, 44);
            this.CrimesPerYear.TabIndex = 5;
            this.CrimesPerYear.Text = "Crimes Per Year";
            this.CrimesPerYear.UseVisualStyleBackColor = true;
            this.CrimesPerYear.Click += new System.EventHandler(this.CrimesPerYear_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(306, 9);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(317, 498);
            this.listBox1.TabIndex = 6;
            // 
            // genCrimeCodes
            // 
            this.genCrimeCodes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.genCrimeCodes.Location = new System.Drawing.Point(110, 12);
            this.genCrimeCodes.Name = "genCrimeCodes";
            this.genCrimeCodes.Size = new System.Drawing.Size(92, 44);
            this.genCrimeCodes.TabIndex = 7;
            this.genCrimeCodes.Text = "Crime Codes";
            this.genCrimeCodes.UseVisualStyleBackColor = true;
            this.genCrimeCodes.Click += new System.EventHandler(this.genCrimeCodes_Click);
            // 
            // areas
            // 
            this.areas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.areas.Location = new System.Drawing.Point(208, 12);
            this.areas.Name = "areas";
            this.areas.Size = new System.Drawing.Size(92, 44);
            this.areas.TabIndex = 8;
            this.areas.Text = "Areas";
            this.areas.UseVisualStyleBackColor = true;
            this.areas.Click += new System.EventHandler(this.areas_Click);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(12, 321);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(288, 182);
            this.chart1.TabIndex = 9;
            this.chart1.Text = "chart1";
            // 
            // plotCrimesYear
            // 
            this.plotCrimesYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.plotCrimesYear.Location = new System.Drawing.Point(12, 62);
            this.plotCrimesYear.Name = "plotCrimesYear";
            this.plotCrimesYear.Size = new System.Drawing.Size(92, 63);
            this.plotCrimesYear.TabIndex = 10;
            this.plotCrimesYear.Text = "Plot Crimes per Year";
            this.plotCrimesYear.UseVisualStyleBackColor = true;
            this.plotCrimesYear.Click += new System.EventHandler(this.plotCrimesYear_Click);
            // 
            // crimesPerArea
            // 
            this.crimesPerArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.crimesPerArea.Location = new System.Drawing.Point(110, 62);
            this.crimesPerArea.Name = "crimesPerArea";
            this.crimesPerArea.Size = new System.Drawing.Size(92, 63);
            this.crimesPerArea.TabIndex = 11;
            this.crimesPerArea.Text = "Plot Crimes per Area";
            this.crimesPerArea.UseVisualStyleBackColor = true;
            this.crimesPerArea.Click += new System.EventHandler(this.crimesPerArea_Click);
            // 
            // crimesPerMonth
            // 
            this.crimesPerMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.crimesPerMonth.Location = new System.Drawing.Point(208, 62);
            this.crimesPerMonth.Name = "crimesPerMonth";
            this.crimesPerMonth.Size = new System.Drawing.Size(92, 63);
            this.crimesPerMonth.TabIndex = 12;
            this.crimesPerMonth.Text = "Plot Crimes per Month";
            this.crimesPerMonth.UseVisualStyleBackColor = true;
            this.crimesPerMonth.Click += new System.EventHandler(this.crimesPerMonth_Click);
            // 
            // crimesByCriteria
            // 
            this.crimesByCriteria.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.crimesByCriteria.Location = new System.Drawing.Point(12, 199);
            this.crimesByCriteria.Name = "crimesByCriteria";
            this.crimesByCriteria.Size = new System.Drawing.Size(92, 87);
            this.crimesByCriteria.TabIndex = 13;
            this.crimesByCriteria.Text = "Crimes by Criteria";
            this.crimesByCriteria.UseVisualStyleBackColor = true;
            this.crimesByCriteria.Click += new System.EventHandler(this.crimesByCriteria_Click);
            // 
            // areaText
            // 
            this.areaText.Location = new System.Drawing.Point(244, 226);
            this.areaText.Name = "areaText";
            this.areaText.Size = new System.Drawing.Size(51, 20);
            this.areaText.TabIndex = 14;
            // 
            // iucrTEXT
            // 
            this.iucrTEXT.Location = new System.Drawing.Point(244, 248);
            this.iucrTEXT.Name = "iucrTEXT";
            this.iucrTEXT.Size = new System.Drawing.Size(51, 20);
            this.iucrTEXT.TabIndex = 15;
            // 
            // yearText
            // 
            this.yearText.Location = new System.Drawing.Point(244, 270);
            this.yearText.Name = "yearText";
            this.yearText.Size = new System.Drawing.Size(51, 20);
            this.yearText.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(208, 251);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "IUCR";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(200, 273);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Year 1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(209, 229);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Area";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(110, 132);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(92, 64);
            this.button2.TabIndex = 20;
            this.button2.Text = "Top N Crimes";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // valueOfN
            // 
            this.valueOfN.Location = new System.Drawing.Point(244, 202);
            this.valueOfN.Name = "valueOfN";
            this.valueOfN.Size = new System.Drawing.Size(51, 20);
            this.valueOfN.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(213, 205);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "n = ";
            // 
            // topn
            // 
            this.topn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.topn.Location = new System.Drawing.Point(12, 131);
            this.topn.Name = "topn";
            this.topn.Size = new System.Drawing.Size(92, 65);
            this.topn.TabIndex = 23;
            this.topn.Text = "Top N Areas";
            this.topn.UseVisualStyleBackColor = true;
            this.topn.Click += new System.EventHandler(this.topNAreas);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(208, 131);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(92, 65);
            this.button4.TabIndex = 24;
            this.button4.Text = "Top N Crimes by Area";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(75, 295);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(119, 20);
            this.textBox1.TabIndex = 25;
            // 
            // AreaName
            // 
            this.AreaName.AutoSize = true;
            this.AreaName.Location = new System.Drawing.Point(12, 298);
            this.AreaName.Name = "AreaName";
            this.AreaName.Size = new System.Drawing.Size(57, 13);
            this.AreaName.TabIndex = 26;
            this.AreaName.Text = "AreaName";
            // 
            // crimesByAreaForYearRange
            // 
            this.crimesByAreaForYearRange.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.crimesByAreaForYearRange.Location = new System.Drawing.Point(110, 199);
            this.crimesByAreaForYearRange.Name = "crimesByAreaForYearRange";
            this.crimesByAreaForYearRange.Size = new System.Drawing.Size(92, 87);
            this.crimesByAreaForYearRange.TabIndex = 27;
            this.crimesByAreaForYearRange.Text = "Crimes by Area Name for Year Range";
            this.crimesByAreaForYearRange.UseVisualStyleBackColor = true;
            this.crimesByAreaForYearRange.Click += new System.EventHandler(this.crimesByAreaForYearRange_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(200, 295);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "Year 2";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(244, 292);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(51, 20);
            this.textBox2.TabIndex = 28;
            // 
            // txtDBFile
            // 
            this.txtDBFile.Location = new System.Drawing.Point(12, 516);
            this.txtDBFile.Name = "txtDBFile";
            this.txtDBFile.Size = new System.Drawing.Size(611, 20);
            this.txtDBFile.TabIndex = 30;
            this.txtDBFile.Text = "|DataDirectory|\\CrimeDB.mdf";
            this.txtDBFile.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 548);
            this.Controls.Add(this.txtDBFile);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.crimesByAreaForYearRange);
            this.Controls.Add(this.AreaName);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.topn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.valueOfN);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.yearText);
            this.Controls.Add(this.iucrTEXT);
            this.Controls.Add(this.areaText);
            this.Controls.Add(this.crimesByCriteria);
            this.Controls.Add(this.crimesPerMonth);
            this.Controls.Add(this.crimesPerArea);
            this.Controls.Add(this.plotCrimesYear);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.areas);
            this.Controls.Add(this.genCrimeCodes);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.CrimesPerYear);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Chicago Crime Analysis";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button CrimesPerYear;
    private System.Windows.Forms.ListBox listBox1;
    private System.Windows.Forms.Button genCrimeCodes;
    private System.Windows.Forms.Button areas;
    private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    private System.Windows.Forms.Button plotCrimesYear;
    private System.Windows.Forms.Button crimesPerArea;
    private System.Windows.Forms.Button crimesPerMonth;
    private System.Windows.Forms.Button crimesByCriteria;
    private System.Windows.Forms.TextBox areaText;
    private System.Windows.Forms.TextBox iucrTEXT;
    private System.Windows.Forms.TextBox yearText;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.TextBox valueOfN;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Button topn;
    private System.Windows.Forms.Button button4;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.Label AreaName;
    private System.Windows.Forms.Button crimesByAreaForYearRange;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.TextBox textBox2;
    private System.Windows.Forms.TextBox txtDBFile;
  }
}

