using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Main {
	public static class Countries {
		public static Country US =		new Country("US", zipCodePattern: @"\d{5}(-?\d{4})?", cityLine: "c s p", zipCodeName: "ZipCode");

		public static Country AUSTRALIA = new Country("AU", zipCodePattern: @".+", cityLine: "c s p", zipCodeName: "Postal Code", searchTerms: new string[] { "AUSTRALIA" });
		public static Country BRAZIL = new Country("BR", zipCodePattern: @".+", cityLine: "p c-s", zipCodeName: "Postal Code", cityName: "Town", searchTerms: new string[] { "BRAZIL" });
		public static Country CANADA = new Country("CA", zipCodePattern: @"[A-Z]\d[A-Z] ?\d[A-Z]\d", cityLine: "c s p", zipCodeName: "Postal Code", stateName: "Province", searchTerms: new string[] { "CANADA" });
		public static Country CHINA =	new Country("CN", zipCodePattern: @".+", zipCodeName: "Postal Code", stateName: "Province", searchTerms: new string[] { "CHINA" });
		public static Country INDIA =	new Country("IN", zipCodePattern: @".+", zipCodeName: "Postal Code", stateName: "Province", searchTerms: new string[] { "INDIA" });

		public static List<Country> _countries = new List<Country>() { 
			US,
			AUSTRALIA,
			BRAZIL,
			CANADA,
			CHINA,
			INDIA,
		};

		public static Country SettingsFor(string countryName)
		{
			var country = _countries.Where(c => c.CountryCode == countryName || c.SearchTerms.Contains(countryName)).FirstOrDefault();
			if (country == null)
				throw new ArgumentException("Specific country is not a valid option");

			return country;
		}
	}

	public class Country {
		public string CountryCode { get; private set; }
		public string CityLineTemplate { get; private set; }

		public string CityName { get; private set; }
		public bool HasCity { get { return !string.IsNullOrWhiteSpace(CityName); } }

		public string StateName { get; private set; }
		public bool HasState { get { return !string.IsNullOrWhiteSpace(StateName); } }

		public bool HasZipCode { get { return !String.IsNullOrWhiteSpace(ZipCodePattern); } }
		public string ZipCodePattern { get; private set; }
		public string ZipCodeName { get; private set; }

		public List<string> SearchTerms { get; private set; }

		public Country(string code, string cityLine = "c, s p", string cityName = "City", string stateName = "State", 
						string zipCodePattern = "", string zipCodeName = "", string [] searchTerms = null) {
			CountryCode = code;
			CityName = cityName;
			ZipCodePattern = zipCodePattern;
			ZipCodeName = zipCodeName;
			CityLineTemplate = cityLine;
			StateName = stateName;

			SearchTerms = new List<string>();
			if (searchTerms != null)
				SearchTerms.AddRange(searchTerms);
		}
	}
}

