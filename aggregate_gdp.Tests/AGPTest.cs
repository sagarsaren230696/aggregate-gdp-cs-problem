
using System;
using Xunit;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using aggregate_gdp;
namespace XUnitTestGDP
{
  public class AGPTest
  {
    [Fact]
    public static void Test1()
    {
      if (File.Exists("../../../../expected-output.json"))
      {
        JObject xpctJSON = JObject.Parse(File.ReadAllText(@"../../../../expected-output.json"));
        JObject actJSON = JObject.Parse(File.ReadAllText(@"../../../../aggregate-gdp-population.json"));
        Assert.True(JToken.DeepEquals(xpctJSON, actJSON));
      }

    }
    [Fact]
    public void Test2()
    {
      if (!File.Exists("../../../../aggregate-gdp-population.json"))
      {
        Assert.Throws<FileNotFoundException>(() => Test1());
      }
      if (!File.Exists("../../../../expected-output.json"))
      {
        Assert.Throws<FileNotFoundException>(() => Test1());
      }
      if (!File.Exists("../../../../data/datafile.csv"))
      {
        Assert.Throws<FileNotFoundException>(() => Test1());
      }

      Assert.True(true);
    }
    [Fact]
    public void Test3()
    {
      bool flag = true;
      if (new FileInfo("../../../../aggregate-gdp-population.json").Length == 0)
      {
        flag = false;
      }
      Assert.True(flag);
    }
  }
}

