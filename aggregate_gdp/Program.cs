using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace aggregate_gdp
{
  
 
  public static class aggregateGDP
  {
    public static void MakeAggregateGdp()
    {
      Dictionary<string, string[]> continentsCollection = new Dictionary<string, string[]>
      {
        { "Asia",new string[]{"India", "Japan", "China", "Indonesia", "Russia", "Saudi Arabia", "Republic of Korea","Turkey" } },
        { "Africa",new string[]{"South Africa" } },
        { "North America",new string[]{"Mexico", "USA", "Canada" } },
        { "South America",new string[]{"Brazil", "Argentina" } },
        { "Europe",new string[]{"France", "Germany", "Italy",  "United Kingdom" } },
        { "Oceania", new string[]{"Australia"} }
      };
      string[] continents = continentsCollection.Keys.ToArray();

      Dictionary<string, double[]> continentsAggregate = new Dictionary<string, double[]>
      {
        {"Asia", new double[]{0,0} },
        {"Africa", new double[]{0,0} },
        {"North America", new double[]{0,0} },
        {"South America", new double[]{0,0} },
        {"Europe", new double[]{0,0} },
        {"Oceania", new double[]{0,0} }
      };

      string filePath = @"../../../../data/datafile.csv";
      string[] testDataLineByLine = File.ReadAllLines(filePath);


      for (int i = 1; i < testDataLineByLine.Length; i++)
      {
        string[] elementString = testDataLineByLine[i].Split(',');

        elementString[0] = elementString[0].Replace("\"", string.Empty);
        elementString[4] = elementString[4].Replace("\"", string.Empty);
        elementString[7] = elementString[7].Replace("\"", string.Empty);

        for (var j = 0; j < continents.Length; j++)
        {
          if (continentsCollection[continents[j]].Contains(elementString[0]))
          {
            continentsAggregate[continents[j]][0] = continentsAggregate[continents[j]][0] + Convert.ToDouble(elementString[4]);
            continentsAggregate[continents[j]][1] = continentsAggregate[continents[j]][1] + Convert.ToDouble(elementString[7]);
          }
        }


      }

      foreach (var key in continentsAggregate.Keys)
      {
        Console.WriteLine(key + " " + continentsAggregate[key][0] + " " + continentsAggregate[key][1]);
      }

      

      Dictionary<string, double> Dictionary1 = new Dictionary<string, double>();
      Dictionary<string, double> Dictionary2 = new Dictionary<string, double>();
      Dictionary<string, double> Dictionary3 = new Dictionary<string, double>();
      Dictionary<string, double> Dictionary4 = new Dictionary<string, double>();
      Dictionary<string, double> Dictionary5 = new Dictionary<string, double>();
      Dictionary<string, double> Dictionary6 = new Dictionary<string, double>();

      Dictionary1.Add("GDP_2012", continentsAggregate["Asia"][1]);
      Dictionary1.Add("POPULATION_2012", continentsAggregate["Asia"][0]);

      Dictionary2.Add("GDP_2012", continentsAggregate["Africa"][1]);
      Dictionary2.Add("POPULATION_2012", continentsAggregate["Africa"][0]);

      Dictionary3.Add("GDP_2012", continentsAggregate["North America"][1]);
      Dictionary3.Add("POPULATION_2012", continentsAggregate["North America"][0]);

      Dictionary4.Add("GDP_2012", continentsAggregate["South America"][1]);
      Dictionary4.Add("POPULATION_2012", continentsAggregate["South America"][0]);

      Dictionary5.Add("GDP_2012", continentsAggregate["Europe"][1]);
      Dictionary5.Add("POPULATION_2012", continentsAggregate["Europe"][0]);

      Dictionary6.Add("GDP_2012", continentsAggregate["Oceania"][1]);
      Dictionary6.Add("POPULATION_2012", continentsAggregate["Oceania"][0]);

      Dictionary<string, Dictionary<string, double>> finalValuePairs = new Dictionary<string, Dictionary<string, double>>();
      finalValuePairs.Add("Asia", Dictionary1);
      finalValuePairs.Add("Africa", Dictionary2);
      finalValuePairs.Add("North America", Dictionary3);
      finalValuePairs.Add("South America", Dictionary4);
      finalValuePairs.Add("Europe", Dictionary5);
      finalValuePairs.Add("Oceania", Dictionary6);

      string theFinalOne = JsonConvert.SerializeObject(finalValuePairs, Formatting.Indented);
      Console.WriteLine(theFinalOne);

      File.WriteAllText(@"../../../../aggregate-gdp-population.json", theFinalOne.ToString());
    }
  }
  class Program
  {
    static void Main(string[] args)
    {
      aggregateGDP.MakeAggregateGdp();
    }
  }
}
