﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Main {
	public class Address {

		public string Recipient { get; set; }
		public string AddressLine1 { get; set; }
		public string AddressLine2 { get; set; }
		public Input City { get; private set; }
		public Input State { get; private set; }
		public ValidatedInput Code { get; private set; }
		public string Country { get; set; }

		public string SourceCountry { get { return "US"; } }

		public Address() {
			City = new Input() { Label = "City or Town" };
			State = new Input() { Label = "State/Region/Province" };
			Code = new ValidatedInput() {
				Label = "Zip/Postal Code",
				Validate = (s) => s.Length > 0
			};
		}

		/// <summary>
		/// Evaluate is intended to be called by the "interface" once it
		/// has finished entering updated values (and because I was too
		/// lazy to build it into the individual setters)
		/// </summary>
		public void Evaluate() {

		}

		public string ToFormattedAddress() {
			return "";
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

		public void SetVisiblity(bool isVisible) {
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
