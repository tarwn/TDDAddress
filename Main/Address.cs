using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Main {
	public class Address {
		public string LineDelimiter { get; set; }

		public string Recipient { get; set; }
		public string AddressLine1 { get; set; }
		public string AddressLine2 { get; set; }
		public Input City { get; private set; }
		public Input State { get; private set; }
		public ValidatedInput Code { get; private set; }
		public Country Country { get; set; }

		public Country SourceCountry { get { return Countries.US; } }

		public Address() {
			LineDelimiter = "\n";
			City = new Input() { Label = "City or Town" };
			State = new Input() { Label = "State/Region/Province" };
			Code = new ValidatedInput() {
				Label = "Zip/Postal Code",
				Validate = (s) => ValidateCodeForCountry(s)
			};
			Country = Countries.US;
			Evaluate();
		}

		/// <summary>
		/// Evaluate is intended to be called by the "interface" once it
		/// has finished entering updated values (and because I was too
		/// lazy to build it into the individual setters)
		/// </summary>
		public void Evaluate() {
			Code.SetVisibility(Country.HasZipCode);
			Code.Label = Country.ZipCodeName;
		}

		public string ToFormattedAddress() {
			var result = new StringBuilder();
			result.Append(Recipient);

			if (!String.IsNullOrWhiteSpace(Recipient))
				result.Append(LineDelimiter);

			result.Append(AddressLine1);
			
			if(!String.IsNullOrWhiteSpace(AddressLine2))
				result.Append(LineDelimiter + AddressLine2);

			result.Append(GenerateCityLine());

			if (Country != SourceCountry)
				result.Append(LineDelimiter + Country.CountryCode);

			return result.ToString().ToUpper();
		}

		private string GenerateCityLine() {
			string pattern = "{0} {1} {2}";

			return LineDelimiter + String.Format(pattern, City.Value, State.Value, Code.Value);
		}

		private bool ValidateCodeForCountry(string code) {
			return !Country.HasZipCode
				|| Regex.IsMatch(code, Country.ZipCodePattern);
		}

	}

	public class Input {
		public string Value { get; private set; }
		public string Label { get; set; }
		public bool IsVisible { get; private set; }
		public bool IsValid { get; protected set; }

		public void SetValue(string value) {
			Value = value;
			UpdateValidity();
		}

		public void SetVisibility(bool isVisible) {
			IsVisible = isVisible;
			UpdateValidity();
		}

		protected virtual void UpdateValidity() {
			IsValid = true;
		}

		public Input() {
			Value = "";
			IsVisible = true;
			UpdateValidity();
		}
	}

	public class ValidatedInput : Input {

		/// <summary>
		/// Method used to determine if value for input is valid or not
		/// </summary>
		public Func<string, bool> Validate { get; set; }

		protected override void UpdateValidity() {
			IsValid = !IsVisible || (Validate != null && Validate(Value));
		}

	}
}
