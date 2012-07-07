using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Main {
	public static class Countries {
		public static Country US =		new Country("US", zipCodePattern: @"\d{5}(-?\d{4})?");
		public static Country CANADA =	new Country("CA");
	}

	public class Country {
		public string CountryCode { get; private set; }
		public bool HasZipCode { get { return !String.IsNullOrWhiteSpace(ZipCodePattern); } }
		public string ZipCodePattern { get; private set; }

		public Country(string code, string zipCodePattern = "") {
			CountryCode = code;
			ZipCodePattern = zipCodePattern;
		}
	}
}
