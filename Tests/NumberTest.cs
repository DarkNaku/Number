using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using DarkNaku.Number;

public class NumberTest
{
    [Test]
    public void _00_생성_테스트()
    {
        Assert.AreEqual("10", new Number(10, 0).ToString());
        Assert.AreEqual("1.00K", new Number(1000, 0).ToString());
        Assert.AreEqual("1.00M", new Number(1000000, 0).ToString());
        Assert.AreEqual("1.00B", new Number(1000000000, 0).ToString());
        Assert.AreEqual("1.00T", new Number(1000000000000, 0).ToString());
        Assert.AreEqual("-10", new Number(-10, 0).ToString());
        Assert.AreEqual("-1.00K", new Number(-1000, 0).ToString());
        Assert.AreEqual("-1.00M", new Number(-1000000, 0).ToString());
        Assert.AreEqual("-1.00B", new Number(-1000000000, 0).ToString());
        Assert.AreEqual("-1.00T", new Number(-1000000000000, 0).ToString());
        Assert.AreEqual("1", new Number(1, 0).ToString());
        Assert.AreEqual("1.00K", new Number(1, 1).ToString());
        Assert.AreEqual("1.00M", new Number(1, 2).ToString());
        Assert.AreEqual("1.00B", new Number(1, 3).ToString());
        Assert.AreEqual("1.00T", new Number(1, 4).ToString());
        Assert.AreEqual("1.00AA", new Number(1, 5).ToString());
        Assert.AreEqual("-1", new Number(-1, 0).ToString());
        Assert.AreEqual("-1.00K", new Number(-1, 1).ToString());
        Assert.AreEqual("-1.00M", new Number(-1, 2).ToString());
        Assert.AreEqual("-1.00B", new Number(-1, 3).ToString());
        Assert.AreEqual("-1.00T", new Number(-1, 4).ToString());
        Assert.AreEqual("-1.00AA", new Number(-1, 5).ToString());
        Assert.AreEqual("1.00AB", new Number(1, 6).ToString());
        Assert.AreEqual("1.00AC", new Number(1, 7).ToString());
        Assert.AreEqual("1.00AD", new Number(1, 8).ToString());
        Assert.AreEqual("1.00AE", new Number(1, 9).ToString());
        Assert.AreEqual("1.00AF", new Number(1, 10).ToString());
        Assert.AreEqual("1.00AG", new Number(1, 11).ToString());
        Assert.AreEqual("1.00AH", new Number(1, 12).ToString());
        Assert.AreEqual("1.00AI", new Number(1, 13).ToString());
        Assert.AreEqual("1.00AJ", new Number(1, 14).ToString());
        Assert.AreEqual("1.00AK", new Number(1, 15).ToString());
        Assert.AreEqual("1.00AL", new Number(1, 16).ToString());
        Assert.AreEqual("1.00AM", new Number(1, 17).ToString());
        Assert.AreEqual("1.00AN", new Number(1, 18).ToString());
        Assert.AreEqual("1.00AO", new Number(1, 19).ToString());
        Assert.AreEqual("1.00AP", new Number(1, 20).ToString());
        Assert.AreEqual("1.00AQ", new Number(1, 21).ToString());
        Assert.AreEqual("1.00AR", new Number(1, 22).ToString());
        Assert.AreEqual("1.00AS", new Number(1, 23).ToString());
        Assert.AreEqual("1.00AT", new Number(1, 24).ToString());
        Assert.AreEqual("1.00AU", new Number(1, 25).ToString());
        Assert.AreEqual("1.00AV", new Number(1, 26).ToString());
        Assert.AreEqual("1.00AW", new Number(1, 27).ToString());
        Assert.AreEqual("1.00AX", new Number(1, 28).ToString());
        Assert.AreEqual("1.00AY", new Number(1, 29).ToString());
        Assert.AreEqual("1.00AZ", new Number(1, 30).ToString());
        Assert.AreEqual("1.00BA", new Number(1, 31).ToString());
        Assert.AreEqual("1.00BB", new Number(1, 32).ToString());
        Assert.AreEqual("1.00M", new Number(1000, 1).ToString());
        Assert.AreEqual("1.00B", new Number(1000, 2).ToString());
        Assert.AreEqual("1.00T", new Number(1000, 3).ToString());
        Assert.AreEqual("1.00AA", new Number(1000, 4).ToString());
        Assert.AreEqual("1.23K", new Number(1234.5678d, 0).ToString());
        Assert.AreEqual("12.34M", new Number(12347898.7654d, 0).ToString());
        Assert.AreEqual("0.45", new Number(0.4599d, 0).ToString());
    }

    [Test]
    public void _01_비교_테스트()
    {
        Assert.True(new Number(1, 0) == new Number(1, 0));
        Assert.True(new Number(1, 1) == new Number(1, 1));
        Assert.True(new Number(1, 1) == new Number(1000, 0));
        Assert.True(new Number(1, 2) == new Number(1000, 1));
        Assert.True(new Number(1, 0) != new Number(2, 0));
        Assert.True(new Number(1, 0) != new Number(1, 1));
        Assert.True(new Number(1, 1) > new Number(1, 0));
        Assert.True(new Number(1000, 0) > new Number(1, 0));
        Assert.True(new Number(1, 0) < new Number(1, 1));
        Assert.True(new Number(1, 0) < new Number(1000, 0));
        Assert.True(new Number(1, 1) >= new Number(1, 1));
        Assert.True(new Number(1, 1) <= new Number(1, 1));
        Assert.True(new Number(1, 0) > new Number(-1, 0));
        Assert.True(new Number(-1, 0) < new Number(1, 0));
        Assert.True(new Number(1, 0) > new Number(-1, 1));
        Assert.True(new Number(-1, 1) < new Number(1, 0));
        Assert.True(new Number(1, 0) >= new Number(-1, 0));
        Assert.True(new Number(-1, 0) <= new Number(1, 0));
        Assert.True(new Number(1, 0) >= new Number(-1, 1));
        Assert.True(new Number(-1, 1) <= new Number(1, 0));
        Assert.True(new Number(-1, 0) >= new Number(-1, 0));
        Assert.True(new Number(-1, 0) <= new Number(-1, 0));
        Assert.AreEqual(0, new Number(1, 1).CompareTo(new Number(1000)));
        Assert.AreEqual(-1, new Number(999).CompareTo(new Number(1, 1)));
        Assert.AreEqual(-1, new Number(999).CompareTo(new Number(1000)));
        Assert.AreEqual(1, new Number(999, 1).CompareTo(new Number(1, 1)));
        Assert.AreEqual(1, new Number(999, 2).CompareTo(new Number(1000, 1)));
        Assert.AreEqual(-1, new Number(-1, 1).CompareTo(new Number(1, 0)));
        Assert.AreEqual(-1, new Number(-1, 0).CompareTo(new Number(1, 0)));
    }

    [Test]
    public void _02_연산_테스트()
    {
        Assert.True(new Number(-1, 0) == -new Number(1, 0));
        Assert.True(new Number(2, 0) == (new Number(1, 0) + new Number(1, 0)));
        Assert.True(new Number(1, 0) == (new Number(2, 0) - new Number(1, 0)));
        Assert.True(new Number(1, 1) == (new Number(1, 0) * new Number(1, 1)));
        Assert.True(new Number(1, 2) == (new Number(1, 1) * new Number(1, 1)));
        Assert.True(new Number(1, 1) == (new Number(1, 2) / new Number(1, 1)));
        Assert.True(new Number(1, 2) == (new Number(1000, 0) * new Number(1, 1)));
        Assert.True(new Number(1, 1) == (new Number(1000000, 0) / new Number(1, 1)));
        Assert.True(new Number(1, 2) == (new Number(1, 1) * new Number(1000, 0)));
        Assert.True(new Number(1, 1) == (new Number(1, 2) / new Number(1000, 0)));
        
        var number = new Number(1, 0);
        
        number++;
        
        Assert.True(new Number(2, 0) == number);
        
        number--;
        
        Assert.True(new Number(1, 0) == number);
    }

    [Test]
    public void _03_형변환_테스트()
    {
        Assert.True(1.Equals(Number.One));
        Assert.True(1L.Equals(Number.One));
        Assert.True(1f.Equals(Number.One));
        Assert.True(1d.Equals(Number.One));
        Assert.AreEqual(1000, (int)new Number(1, 1));
        Assert.AreEqual(1000L, (long)new Number(1, 1));
        Assert.AreEqual(1000f, (float)new Number(1, 1));
        Assert.AreEqual(1000d, (double)new Number(1, 1));

        var number = new Number(2);

        number *= 10;
        
        Assert.True(number == new Number(20));
        
        number /= 10;
        
        Assert.True(number == new Number(2));
    }

    [Test]
    public void _04_문자열로_생성_테스트()
    {
        Assert.True(new Number("10") == new Number(10, 0));
        Assert.True(new Number("-10") == new Number(-10, 0));
        Assert.True(new Number("1K") == new Number(1000, 0));
        Assert.True(new Number("1M") == new Number(1000000, 0));
        Assert.True(new Number("1B") == new Number(1000000000, 0));
        Assert.True(new Number("1T") == new Number(1000000000000, 0));
        Assert.True(new Number("-10") == new Number(-10, 0));
        Assert.True(new Number("-1K") == new Number(-1000, 0));
        Assert.True(new Number("-1M") == new Number(-1000000, 0));
        Assert.True(new Number("-1B") == new Number(-1000000000, 0));
        Assert.True(new Number("-1T") == new Number(-1000000000000, 0));
        Assert.True(new Number("1") == new Number(1, 0));
        Assert.True(new Number("1K") == new Number(1, 1));
        Assert.True(new Number("1M") == new Number(1, 2));
        Assert.True(new Number("1B") == new Number(1, 3));
        Assert.True(new Number("1T") == new Number(1, 4));
        Assert.True(new Number("1AA") == new Number(1, 5));
        Assert.True(new Number("-1") == new Number(-1, 0));
        Assert.True(new Number("-1K") == new Number(-1, 1));
        Assert.True(new Number("-1M") == new Number(-1, 2));
        Assert.True(new Number("-1B") == new Number(-1, 3));
        Assert.True(new Number("-1T") == new Number(-1, 4));
        Assert.True(new Number("-1AA") == new Number(-1, 5));
        Assert.True(new Number("1AB") == new Number(1, 6));
        Assert.True(new Number("1AC") == new Number(1, 7));
        Assert.True(new Number("1AD") == new Number(1, 8));
        Assert.True(new Number("1AE") == new Number(1, 9));
        Assert.True(new Number("1AF") == new Number(1, 10));
        Assert.True(new Number("1AG") == new Number(1, 11));
        Assert.True(new Number("1AH") == new Number(1, 12));
        Assert.True(new Number("1AI") == new Number(1, 13));
        Assert.True(new Number("1AJ") == new Number(1, 14));
        Assert.True(new Number("1AK") == new Number(1, 15));
        Assert.True(new Number("1AL") == new Number(1, 16));
        Assert.True(new Number("1AM") == new Number(1, 17));
        Assert.True(new Number("1AN") == new Number(1, 18));
        Assert.True(new Number("1AO") == new Number(1, 19));
        Assert.True(new Number("1AP") == new Number(1, 20));
        Assert.True(new Number("1AQ") == new Number(1, 21));
        Assert.True(new Number("1AR") == new Number(1, 22));
        Assert.True(new Number("1AS") == new Number(1, 23));
        Assert.True(new Number("1AT") == new Number(1, 24));
        Assert.True(new Number("1AU") == new Number(1, 25));
        Assert.True(new Number("1AV") == new Number(1, 26));
        Assert.True(new Number("1AW") == new Number(1, 27));
        Assert.True(new Number("1AX") == new Number(1, 28));
        Assert.True(new Number("1AY") == new Number(1, 29));
        Assert.True(new Number("1AZ") == new Number(1, 30));
        Assert.True(new Number("1BA") == new Number(1, 31));
        Assert.True(new Number("1BB") == new Number(1, 32));
        Assert.True(new Number("1M") == new Number(1000, 1));
        Assert.True(new Number("1B") == new Number(1000, 2));
        Assert.True(new Number("1T") == new Number(1000, 3));
        Assert.True(new Number("1AA") == new Number(1000, 4));
        Assert.True(new Number("1.23K") == new Number(1230d, 0));
        Assert.True(new Number("12.34M") == new Number(12340000d, 0));
        Assert.True(new Number("0.45") == new Number(0.45d, 0));
    }

    [Test]
    public void _05_경계_테스트()
    {
        Assert.True(new Number("999.99ZZ") == new Number(999.99, 680));
        Assert.True(new Number("-999.99ZZ") == new Number(-999.99, 680));
        Assert.True(new Number("999.99ZZ") == new Number(999.99, 680) + 1);
        Assert.True(new Number("-999.99ZZ") == new Number(-999.99, 680) - 1);
    }
}