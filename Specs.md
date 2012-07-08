Specs
=======================

Terms:

- City Line - the line of the address block that contains the city (and possibly state/province/region and zip or postal code)
- Country Line - the line of the address block that contains the country

Requirements:

- 1 When an Address is created, the country selection defaults to US
- 2 When an Address Line 1 is provided, it is included in the formatted output
- 3 When a recipient is provided, it is the first entry in the formatted output
- 4 When an Address Line 1 is provided, it occurs after the recipient in the formatted output
- 5 When an Address Line 1 is provided with a later value, an end of line delimiter (carriage return) immediately follows
- 6 Formatted address output does not have a trailing end of line delimiter (carriage return)
- 7 When an Address Line 2 value is provided, it is in the formatted output
- 11 When an Address Line 2 value is provided, an end of line delimiter immediately follows
- 12 When an Address Line 1 is provided with a later value and Address Line 2 value is not provided, address line 1 will be followed by only one occurrence of end of line delimiter (carriage return)
- 8 When a City is provided, it is in the formatted output
- 9 When a State/Province is provided, it is in the formatted output
- 10 When a Postal Code is provided, it in the formatted output
- 13 When the source country and address country are both USA, the country is not in the formatted output (based on domestic mail rules of USA)
- 14 When the source country and address country are not both USA, the country is in the formatted output
- 15 (Per USPS recomendation) All letters in the address are formatted to uppercase in the formatted output
- 16 When the country is present in the formatted output, it is the only value on the last line

Most of the rest of the rules shold have tests for input visibility, label wording, and verification of the output. So in the the city line rules there should be tests for the visibility of each of the mentioned fields, validation that the relevant labels show the correct text, and tests against the formatted output.

- 17 When the address country is USA (US), the zip code is 5 digits (NNNNN) or 5-4 (NNNNN-NNNN)
- 18 When the address country is Canada (CA), the postal code is 6 characters with a space (A0A 0A0)
- 19 When the address country is China (CN) or India (IN), the City Line is formatted as: city, province postalcode
- 20 When the address country is USA (US) or Australia (AU), the City Line is formatted as: city state postalcode
- 21 When the address country is Canada (CA), the City Line is formatted as: city province postalcode
- 22 When the address country is Brazil (BR), the City Line is formatted as: postalcode town-state
- 23When the address country is Brazil (BR), the postal code is 5+3: NNNNN-NNN
- 24 When the address country is Mexico (MX), the City Line is formatted as: postalcode town, state
- 25 When the address country is Mexico (MX), the postal code is a 5 digit number: NNNNN
- 26 When the address country is Italy (IT), the City Line is formatted as: postalcode town (provincia)
- When the address country is Italy (IT), the postal code is five numbers prefixed with "IT-": IT-NNNNN
- When the address country is Italy (IT), the provincia is a 2 letter abbreviation
- When the address country is New Zealand (NZ), Thailand (TH) the City Line is formatted as: town postalcode
- When the address country is New Zealand (NZ), the postal code is a 4 digit number: NNNN
- When the address country is Thailand (TH), the postal code is a 5 digit number: NNNNN
- When the address country is Singapore (SG), the postal code is 6 numbers: NNNNNN
- When the address country is Singapore (SG), the city is "Singapore"
- When the address country is Ireland (IE) and the city is not Dublin, the City Line is formatted as: town, Co. county
- When the address country is Ireland (IE) and the city is not Dublin and the entered county begins with Co., the City line only contains one Co. before the county name
- When the address country is Ireland (IE) and the city is Dublin, the City Line is formatted as: town postalzone
- When the address country is Ireland (IE) and the city is Dublin, the postal zone is a number between 1 and 24 or 6W
- When the address country is Hungary (HU), the City Line is formatted as two lines: town \n postalcode
- When the address country is Hungary (HU), the postal code is a 4 digit number: NNNN
- When the address country is Ecuador (EC), the City Line is formatted as two lines: postalcode \n town
- When the address country is Ecuador (EC), the postal code is a letter, 4 numbers, and a letter: LNNNNL
- When the country is Hong Kong (HK) or Iraq (IQ) the City Line is formatted as: town
- When the country is not in the above list, a default City Line format is: postalcode town
- When the country is US, Canada, or Australia, the City Line has a minimum of two spaces between the state/province and postalcode

Extra Credit: Japan, UK, Former Soviet Union

The system should now not only support a lot of common countries but also be flexible enough that implementing additional specs should be a matter of just a few minutes.

Note: Obviously the next step would be to implement lookup tables for valid states/provinces/regions but most address inputs I have seen in the US rarely have more than US and Canada lookups.
