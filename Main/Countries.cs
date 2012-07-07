using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Main {
	public static class Countries {
		public static Country US =		new Country("US", zipCodePattern: @"\d{5}(-?\d{4})?", zipCodeName: "ZipCode");
		public static Country CANADA = new Country("CA", zipCodePattern: @"[A-Z]\d[A-Z] ?\d[A-Z]\d", zipCodeName: "Postal Code");
	}

	public class Country {
		public string CountryCode { get; private set; }
		public bool HasZipCode { get { return !String.IsNullOrWhiteSpace(ZipCodePattern); } }
		public string ZipCodePattern { get; private set; }
		public string ZipCodeName { get; private set; }

		public Country(string code, string zipCodePattern = "", string zipCodeName = "") {
			CountryCode = code;
			ZipCodePattern = zipCodePattern;
			ZipCodeName = zipCodeName;
		}
	}
}
