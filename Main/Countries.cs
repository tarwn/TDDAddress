using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Main {
	public static class Countries {
		public static Country US =		new Country("US", zipCodePattern: @"\d{5}(-?\d{4})?", zipCodeName: "ZipCode");
		public static Country CANADA =	new Country("CA", zipCodePattern: @"[A-Z]\d[A-Z] ?\d[A-Z]\d", zipCodeName: "Postal Code");
		public static Country CHINA =	new Country("CHINA", zipCodePattern: @".+", zipCodeName: "Postal Code", stateName: "Province");

		public static List<Country> _countries = new List<Country>() { 
			US,
			CANADA,
			CHINA
		};

		public static Country SettingsFor(string countryName)
		{
			var country = _countries.Where(c => c.CountryCode == countryName).FirstOrDefault();
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

		public Country(string code, string cityLine = "c, s p", string cityName = "City", string stateName = "State", string zipCodePattern = "", string zipCodeName = "") {
			CountryCode = code;
			CityName = cityName;
			ZipCodePattern = zipCodePattern;
			ZipCodeName = zipCodeName;
			CityLineTemplate = cityLine;
			StateName = stateName;
		}
	}
}

