/*
 * Created by SharpDevelop.
 * User: Emil
 * Date: 15/05/2015
 * Time: 11:58
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using NUnit.Framework;

namespace TDD
{
	/// <summary>
	/// Description of Test.
	/// </summary>
	///
	[TestFixture ()]
	public class Test
	{
		[Test]
		public void ShouldReturnIWhen1()
		{
			var calculator = new RomanToNumericCalculator();
			var actual = calculator.ToRoman(1);
			var expected = "I";
			
			Assert.AreEqual(expected, actual);
			
		}
		
		[Test]
		public void ShouldReturnIIWhen2()
		{
			var calculator = new RomanToNumericCalculator();
			var actual = calculator.ToRoman(2);
			var expected = "II";
			
			Assert.AreEqual(expected, actual);
		}
		
		[Test]
		public void ShouldReturnIIIWhen3()
		{
			var calculator = new RomanToNumericCalculator();
			var actual = calculator.ToRoman(3);
			var expected = "III";
			
			Assert.AreEqual(expected, actual);
		}
		
		[Test]
		public void ShouldReturnVWhen5()
		{
			var calculator = new RomanToNumericCalculator();
			var actual = calculator.ToRoman(5);
			var expected = "V";
			
			Assert.AreEqual(expected, actual);
		}
		
		[Test]
		public void ShouldReturnXWhen10()
		{
			var calculator = new RomanToNumericCalculator();
			var actual = calculator.ToRoman(10);
			var expected = "X";
			
			Assert.AreEqual(expected, actual);
		}
		
		[Test]
		public void ShouldReturnXXWhen20()
		{
			var calculator = new RomanToNumericCalculator();
			var actual = calculator.ToRoman(20);
			var expected = "XX";
			
			Assert.AreEqual(expected, actual);
		}
		
		[Test]
		public void ShouldReturnXXXWhen30()
		{
			var calculator = new RomanToNumericCalculator();
			var actual = calculator.ToRoman(30);
			var expected = "XXX";
			
			Assert.AreEqual(expected, actual);
		}
		
		[Test]
		public void ShouldReturnLWhen50()
		{
			var calculator = new RomanToNumericCalculator();
			var actual = calculator.ToRoman(50);
			var expected = "L";
			
			Assert.AreEqual(expected, actual);
		}
		
		[Test]
		public void ShouldReturnCWhen100()
		{
			var calculator = new RomanToNumericCalculator();
			var actual = calculator.ToRoman(100);
			var expected = "C";
			
			Assert.AreEqual(expected, actual);
		}
		
		[Test]
		public void ShouldReturnCCWhen200()
		{
			var calculator = new RomanToNumericCalculator();
			var actual = calculator.ToRoman(200);
			var expected = "CC";
			
			Assert.AreEqual(expected, actual);
		}
		
		[Test]
		public void ShouldReturnCCCWhen300()
		{
			var calculator = new RomanToNumericCalculator();
			var actual = calculator.ToRoman(300);
			var expected = "CCC";
			
			Assert.AreEqual(expected, actual);
		}
		
			
		[Test]
		public void ShouldReturnCCCCWhen400()
		{
			var calculator = new RomanToNumericCalculator();
			var actual = calculator.ToRoman(400);
			var expected = "CCCC";
			
			Assert.AreEqual(expected, actual);
		}
	}
	
	public class RomanToNumericCalculator
	{
		public string ToRoman(int value)
		{
			string result = "";
			if(value==5)
				return "V";
			
			if(value==50)
				return "L";
			
			if(value<=300)
			{
				for (int i=100; i<=value; i=i+100)
				{
					result += "C";
				}
				
				if(value<=30)
				{
					for(int i=10; i<=value; i=i+10)
					{
						result += "X";
					}
					
					if(value<=3)
					{
						for(int i=0; i<value;i++)
						{
							result += "I";
						}
					}
				}
			}
			return result;
		}
	}
}
