using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Main {
	public static class Countries {
		public static Country US =		new Country("US", zipCodePattern: @"\d{5}(-?\d{4})?", cityLine: "c s p", zipCodeName: "ZipCode");

		public static Country AUSTRALIA = new Country("AU", zipCodePattern: @".+", cityLine: "c s p", zipCodeName: "Postal Code", fullName: "AUSTRALIA" );
		public static Country BRAZIL = new Country("BR", zipCodePattern: @"\d{5}-\d{3}", cityLine: "p c-s", zipCodeName: "Postal Code", cityName: "Town", fullName: "BRAZIL");
		public static Country CANADA = new Country("CA", zipCodePattern: @"[A-Z]\d[A-Z] ?\d[A-Z]\d", cityLine: "c s p", zipCodeName: "Postal Code", stateName: "Province", fullName: "CANADA");
		public static Country CHINA = new Country("CN", zipCodePattern: @".+", zipCodeName: "Postal Code", stateName: "Province", fullName: "CHINA");
		public static Country INDIA = new Country("IN", zipCodePattern: @".+", zipCodeName: "Postal Code", stateName: "Province", fullName: "INDIA");
		public static Country ITALY = new Country("IT", zipCodePattern: @"IT-\d{5}", cityLine: "p c (s)", zipCodeName: "Postal Code", stateName: "Provincia", cityName: "Town", fullName: "ITALY");
		public static Country MEXICO = new Country("MX", zipCodePattern: @"\d{5}", cityLine: "p c, s", zipCodeName: "Postal Code", fullName: "MEXICO");
		public static Country NEWZEALAND = new Country("NZ", zipCodePattern: @".+", cityLine: "c p", zipCodeName: "Postal Code", cityName: "Town", fullName: "NEW ZEALAND");
		public static Country THAILAND = new Country("TH", zipCodePattern: @".+", cityLine: "c p", zipCodeName: "Postal Code", cityName: "Town", fullName: "THAILAND");

		public static List<Country> _countries = new List<Country>() { 
			US,
			AUSTRALIA,
			BRAZIL,
			CANADA,
			CHINA,
			INDIA,
			ITALY,
			MEXICO,
			NEWZEALAND,
			THAILAND,
		};

		public static Country SettingsFor(string countryName)
		{
			var country = _countries.Where(c => c.CountryCode == countryName || c.FullName == countryName).FirstOrDefault();
			if (country == null)
				throw new ArgumentException("Specific country is not a valid option");

			return country;
		}
	}

	public class Country {
		public string CountryCode { get; private set; }
		public string CityLineTemplate { get; private set; }

		public string CityName { get; private set; }
		public bool HasCity { get { return CityLineTemplate.Contains("c"); } }

		public string StateName { get; private set; }
		public bool HasState { get { return CityLineTemplate.Contains("s"); } }

		public bool HasZipCode { get { return CityLineTemplate.Contains("p"); } }
		public string ZipCodePattern { get; private set; }
		public string ZipCodeName { get; private set; }

		public string FullName { get; private set; }

		public Country(string code, string cityLine = "c, s p", string cityName = "City", string stateName = "State",
						string zipCodePattern = "", string zipCodeName = "", string fullName = "") {
			CountryCode = code;
			CityName = cityName;
			ZipCodePattern = zipCodePattern;
			ZipCodeName = zipCodeName;
			CityLineTemplate = cityLine;
			StateName = stateName;

			FullName = fullName;
		}
	}
}

