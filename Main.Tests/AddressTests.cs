using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Main.Tests {

	[TestFixture]
	public class AddressTests {

		[Test]
		public void ToFormattedAddress_AddressLine1IsProvided_ItAppearsInOutput() {
			var sampleValue = "Address Line 1";
			var a = new Address();

			a.AddressLine1 = sampleValue;
			var result = a.ToFormattedAddress();

			Assert.IsTrue(result.Contains(sampleValue));
		}
	}
}
