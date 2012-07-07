using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Text.RegularExpressions;

namespace Main.Tests {

	[TestFixture]
	public class AddressTests {

		[Test]
		public void Initialization_CountryIsUS() {
			var a = new Address();

			Assert.AreEqual(Countries.US, a.Country);
		}

		[Test]
		public void ToFormattedAddress_AddressLine1IsProvided_ItAppearsInOutput() {
			var sampleValue = "Address Line 1";
			var a = new Address();

			a.AddressLine1 = sampleValue;
			var result = a.ToFormattedAddress();

			Assert.IsTrue(result.Contains(sampleValue.ToUpper()));
		}

		[Test]
		public void ToFormattedAddress_RecipientIsProvided_ItAppearsFirstinOutput() {
			var sampleRecipient = "Joe Schmoe";
			var a = new Address();

			a.Recipient = sampleRecipient;
			var result = a.ToFormattedAddress();

			Assert.IsTrue(result.StartsWith(sampleRecipient.ToUpper()));
		}

		[Test]
		public void ToFormattedAddress_RecipientAndAddressLine1IsProvided_ReceipientIsBeforeAddressLine1() {
			var sampleRecipient = "Joe Schmoe";
			var sampleAddressLine = "Address Line 1";
			var a = new Address();

			a.Recipient = sampleRecipient;
			a.AddressLine1 = sampleAddressLine;
			var result = a.ToFormattedAddress();

			Assert.Less(result.IndexOf(sampleRecipient.ToUpper()), result.IndexOf(sampleAddressLine.ToUpper()));
		}

		[Test]
		public void ToFormattedAddress_RecipientAndAddressLine1IsProvided_EntriesAreOnSeperateLines() {
			var sampleRecipient = "Joe Schmoe";
			var sampleAddressLine = "Address Line 1";
			var a = new Address();

			a.Recipient = sampleRecipient;
			a.AddressLine1 = sampleAddressLine;
			var result = a.ToFormattedAddress();

			Assert.IsTrue(result.StartsWith(sampleRecipient.ToUpper() + a.LineDelimiter + sampleAddressLine.ToUpper()));
		}

		[Test]
		public void ToFormattedAddress_AddressLine1AndLaterValueIsProvided_AddressLine1FollowedByLineDelimiter() {
			var sampleAddressLine = "Address Line 1";
			var sampleAddressLine2 = "Address Line 2";
			var a = new Address();

			a.AddressLine1 = sampleAddressLine;
			a.AddressLine2 = sampleAddressLine2;
			var result = a.ToFormattedAddress();

			Assert.IsTrue(result.Contains(a.AddressLine1.ToUpper() + a.LineDelimiter));
		}

		[Test]
		public void ToFormattedAddress_AnyValuesProvided_DoesntEndInLineDelimiter() {
			var sampleAddressLine = "Address Line 1";
			var a = new Address();

			a.AddressLine1 = sampleAddressLine;
			var result = a.ToFormattedAddress();

			Assert.IsFalse(result.EndsWith(a.LineDelimiter));
		}

		[Test]
		public void ToFormattedAddress_AddressLine2Provided_DoesntEndInLineDelimiter() {
			var sampleAddressLine = "Address Line 1";
			var a = new Address();

			a.AddressLine1 = sampleAddressLine;
			a.AddressLine2 = sampleAddressLine;
			var result = a.ToFormattedAddress();

			Assert.IsFalse(result.EndsWith(a.LineDelimiter));
		}

		[Test]
		public void ToFormattedAddress_AddressLine2Provided_ItisFollowedImmediatelyByLineDelimiter() {
			var sampleValue = "Address Line 1";
			var sampleValue2 = "Address Line 2";
			var sampleCity = "My City";
			var a = new Address();

			a.AddressLine1 = sampleValue;
			a.AddressLine2 = sampleValue2;
			a.City.SetValue(sampleCity);
			var result = a.ToFormattedAddress();

			Assert.IsTrue(result.Contains(sampleValue2.ToUpper() + a.LineDelimiter));
		}

		[Test]
		public void ToFormattedAddress_AddressLine1WithotuAddressLIne2_HasOnlyOneFollowingLineDelimiter() {
			var sampleValue = "Address Line 1";
			var sampleCity = "My City";
			var a = new Address();

			a.AddressLine1 = sampleValue;
			a.City.SetValue(sampleCity);
			var result = a.ToFormattedAddress();

			Assert.IsFalse(result.Contains(sampleValue + a.LineDelimiter + a.LineDelimiter));
		}

		[Test]
		public void ToFormattedAddress_AddressLine2IsProvided_ItAppearsInOutput() {
			var sampleValue = "Address Line 1";
			var sampleValue2 = "Address Line 2";
			var a = new Address();

			a.AddressLine1 = sampleValue;
			a.AddressLine2 = sampleValue2;
			var result = a.ToFormattedAddress();

			Assert.IsTrue(result.Contains(sampleValue2.ToUpper()));
		}

		[Test]
		public void ToFormattedAddress_CityIsProvided_ItAppearsInOutput() {
			var sampleValue = "AwesomeCityName";
			var a = new Address();

			a.City.SetValue(sampleValue);
			var result = a.ToFormattedAddress();

			Assert.IsTrue(result.Contains(sampleValue.ToUpper()));
		}

		[Test]
		public void ToFormattedAddress_StateIsProvided_ItAppearsInOutput() {
			var sampleValue = "SuperState";
			var a = new Address();

			a.State.SetValue(sampleValue);
			var result = a.ToFormattedAddress();

			Assert.IsTrue(result.Contains(sampleValue.ToUpper()));
		}

		[Test]
		public void ToFormattedAddress_CodeIsProvided_ItAppearsInOutput() {
			var sampleValue = "12345-6789";
			var a = new Address();

			a.Code.SetValue(sampleValue);
			var result = a.ToFormattedAddress();

			Assert.IsTrue(result.Contains(sampleValue));
		}

		[Test]
		public void ToFormattedAddress_SourceAndTargetAreBothUS_CountryIsNotInOutput() {
			var a = new Address();

			a.Country = Countries.US;
			var result = a.ToFormattedAddress();

			Assert.IsFalse(result.EndsWith(Countries.US.CountryCode));
		}

		[Test]
		public void ToFormattedAddress_SourceAndTargetAreNotBothUS_CountryIsInOutput() {
			var a = new Address();

			a.Country = Countries.CANADA;
			var result = a.ToFormattedAddress();

			Assert.IsTrue(result.EndsWith(Countries.CANADA.CountryCode));
		}

		[Test]
		public void ToFormattedAddress_AnyValues_AllOutputIsUpperCase() {
			var mixedCases = "abc123ABC";
			var a = new Address();

			a.AddressLine1 = mixedCases;
			a.AddressLine2 = mixedCases;
			a.City.SetValue(mixedCases);
			a.Country = Countries.CANADA;
			var result = a.ToFormattedAddress();

			Assert.IsFalse(Regex.IsMatch(result, "[a-z]"));
		}

		[Test]
		public void ToFormattedAddress_SourceAndTargetAreNotBothUS_CountryIsOnlyValueOnLastLine() {
			var mixedCases = "abc123ABC";
			var a = new Address();

			a.AddressLine1 = mixedCases;
			a.AddressLine2 = mixedCases;
			a.City.SetValue(mixedCases);
			a.Country = Countries.CANADA;
			var result = a.ToFormattedAddress();

			Assert.IsTrue(result.EndsWith(a.LineDelimiter + Countries.CANADA.CountryCode));
		}

		[Test]
		public void ToFormattedAddress_CountryIsUSAndFiveDigitNumericCode_IsValid() {
			var a = new Address();

			a.Country = Countries.US;
			a.Code.SetValue("12345");
			a.Evaluate();

			Assert.IsTrue(a.Code.IsValid);
		}

		[Test]
		public void ToFormattedAddress_CountryIsUSAndFivePlusFourDigitNumericCode_IsValid() {
			var a = new Address();

			a.Country = Countries.US;
			a.Code.SetValue("12345-6789");
			a.Evaluate();

			Assert.IsTrue(a.Code.IsValid);
		}

		[Test]
		public void ToFormattedAddress_CountryIsUSAndNotValidCodeOption_IsNotValid() {
			var a = new Address();

			a.Country = Countries.US;
			a.Code.SetValue("123a5");
			a.Evaluate();

			Assert.IsFalse(a.Code.IsValid);
		}

		[Test]
		public void CodeIsVisible_CountryIsUS_ItIsVisible() {
			var a = new Address();

			a.Country = Countries.US;
			a.Evaluate();

			Assert.IsTrue(a.Code.IsVisible);
		}

		[Test]
		public void CodeLabel_CountryIsUS_ItIsNamedZipCode() {
			var a = new Address();

			a.Country = Countries.US;
			a.Evaluate();

			Assert.AreEqual("ZipCode", a.Code.Label);
		}

		[Test]
		public void ToFormattedAddress_CanadaAnd6DigitCodeWithSpace_IsValid() {
			var a = new Address();

			a.Country = Countries.CANADA;
			a.Code.SetValue("A1A 1A1");
			a.Evaluate();

			Assert.IsTrue(a.Code.IsValid);
		}

		[Test]
		public void ToFormattedAddress_CanadaAnd6DigitCodeWithoutSpace_IsValid() {
			var a = new Address();

			a.Country = Countries.CANADA;
			a.Code.SetValue("A1A1A1");
			a.Evaluate();

			Assert.IsTrue(a.Code.IsValid);
		}

		[Test]
		public void ToFormattedAddress_CountryIsCanadaAndNotValidCodeOption_IsNotValid() {
			var a = new Address();

			a.Country = Countries.CANADA;
			a.Code.SetValue("123456");
			a.Evaluate();

			Assert.IsFalse(a.Code.IsValid);
		}


		#region City Line Logic

		[TestCase("US", "City")]
		[TestCase("AUSTRALIA", "City")]
		[TestCase("CANADA", "City")]
		[TestCase("CHINA", "City")]
		[TestCase("INDIA", "City")]
		public void CityLabel_PerCountry_HasCorrectName(string country, string expectedLabel) {
			var a = new Address();

			a.Country = Countries.SettingsFor(country);
			a.Evaluate();

			Assert.AreEqual(expectedLabel, a.City.Label);
		}

		[TestCase("US", true)]
		[TestCase("AUSTRALIA", true)]
		[TestCase("CANADA", true)]
		[TestCase("CHINA", true)]
		[TestCase("INDIA", true)]
		public void CityLabel_PerCountry_HasCorrectVisibility(string country, bool expectedVisible) {
			var a = new Address();

			a.Country = Countries.SettingsFor(country);
			a.Evaluate();

			Assert.AreEqual(expectedVisible, a.City.IsVisible);
		}

		[TestCase("US", "State")]
		[TestCase("AUSTRALIA", "State")]
		[TestCase("CANADA", "Province")]
		[TestCase("CHINA", "Province")]
		[TestCase("INDIA", "Province")]
		public void StateLabel_PerCountry_HasCorrectName(string country, string expectedLabel) {
			var a = new Address();

			a.Country = Countries.SettingsFor(country);
			a.Evaluate();

			Assert.AreEqual(expectedLabel, a.State.Label);
		}

		[TestCase("US", true)]
		[TestCase("AUSTRALIA", true)]
		[TestCase("CANADA", true)]
		[TestCase("CHINA", true)]
		[TestCase("INDIA", true)]
		public void StateLabel_PerCountry_HasCorrectVisibility(string country, bool expectedVisible) {
			var a = new Address();

			a.Country = Countries.SettingsFor(country);
			a.Evaluate();

			Assert.AreEqual(expectedVisible, a.State.IsVisible);
		}

		[TestCase("US", "ZipCode")]
		[TestCase("AUSTRALIA", "Postal Code")]
		[TestCase("CANADA", "Postal Code")]
		[TestCase("CHINA", "Postal Code")]
		[TestCase("INDIA", "Postal Code")]
		public void CodeLabel_PerCountry_ItIsNamedZipCode(string country, string expectedLabel) {
			var a = new Address();

			a.Country = Countries.SettingsFor(country);
			a.Evaluate();

			Assert.AreEqual(expectedLabel, a.Code.Label);
		}

		[TestCase("US", true)]
		[TestCase("AUSTRALIA", true)]
		[TestCase("CANADA", true)]
		[TestCase("CHINA", true)]
		[TestCase("INDIA", true)]
		public void CodeIsVisible_PerCountry_ItIsVisible(string country, bool expectedVisible) {
			var a = new Address();

			a.Country = Countries.SettingsFor(country);
			a.Evaluate();

			Assert.AreEqual(expectedVisible, a.Code.IsVisible);
		}

		[TestCase("CHINA")]
		[TestCase("INDIA")]
		public void ToFormattedAddress_ChinaOrIndia_CityLineInOutputMatchesSpec19(string country) {
			var a = new Address();
			var sampleCity = "City";
			var sampleState = "State";
			var sampleCode = "12345";
			var expectation = String.Format("{0}, {1} {2}", sampleCity, sampleState, sampleCode);

			a.Country = Countries.SettingsFor(country);
			a.City.SetValue(sampleCity);
			a.State.SetValue(sampleState);
			a.Code.SetValue(sampleCode);
			a.Evaluate();
			var result = a.ToFormattedAddress();

			Assert.IsTrue(result.Contains(expectation.ToUpper()));
		}

		[TestCase("US")]
		[TestCase("AUSTRALIA")]
		public void ToFormattedAddress_USorAustralia_CityLineInOutputMatchesSpec20(string country) {
			var a = new Address();
			var sampleCity = "City";
			var sampleState = "State";
			var sampleCode = "12345";
			var expectation = String.Format("{0} {1} +{2}", sampleCity, sampleState, sampleCode);

			a.Country = Countries.SettingsFor(country);
			a.City.SetValue(sampleCity);
			a.State.SetValue(sampleState);
			a.Code.SetValue(sampleCode);
			a.Evaluate();
			var result = a.ToFormattedAddress();

			Assert.IsTrue(Regex.IsMatch(result,expectation, RegexOptions.IgnoreCase));
		}

		[Test]
		public void ToFormattedAddress_Canada_CityLineInOutputMatchesSpec21() {
			var a = new Address();
			var sampleCity = "City";
			var sampleState = "State";
			var sampleCode = "12345";
			var expectation = String.Format("{0} {1} +{2}", sampleCity, sampleState, sampleCode);

			a.Country = Countries.CANADA;
			a.City.SetValue(sampleCity);
			a.State.SetValue(sampleState);
			a.Code.SetValue(sampleCode);
			a.Evaluate();
			var result = a.ToFormattedAddress();

			Assert.IsTrue(Regex.IsMatch(result, expectation, RegexOptions.IgnoreCase));
		}

		#endregion
	}
}
