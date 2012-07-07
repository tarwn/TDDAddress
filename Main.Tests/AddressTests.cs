﻿using System;
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

			Assert.IsFalse(result.EndsWith(Countries.US));
		}

		[Test]
		public void ToFormattedAddress_SourceAndTargetAreNotBothUS_CountryIsInOutput() {
			var a = new Address();

			a.Country = Countries.CANADA;
			var result = a.ToFormattedAddress();

			Assert.IsTrue(result.EndsWith(Countries.CANADA));
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

			Assert.IsFalse(Regex.IsMatch(result,"[a-z]"));
		}

	}
}
