Specs
=======================

Terms:

- City Line - the line of the address block that contains the city (and possibly state/province/region and zip or postal code)
- Country Line - the line of the address block that contains the country

Requirements:

- When an Address is created, the country selection defaults to US
- When an Address Line 1 is provided, it is included in the formatted output
- When a recipient is provided, it is the first entry in the formatted output
- When an Address Line 1 is provided, it occurs after the recipient in the formatted output
- When an Address Line 1 is provided with a later value, an end of line delimiter (carriage return) immediately follows
- Formatted address output does not have a trailing end of line delimiter (carriage return)
- When an Address Line 2 value is provided, it is in the formatted output
- When an Address Line 2 value is provided, an end of line delimiter immediately follows
- When an Address Line 1 is provided with a later value and Address Line 2 value is not provided, address line 1 will be followed by only one occurrence of end of line delimiter (carriage return)
- When a City is provided, it is in the formatted output
- When a State/Province is provided, it is in the formatted output
- When a Postal Code is provided, it in the formatted output
- When the source country and address country are both USA, the country is not in the formatted output (based on domestic mail rules of USA)
- When the source country and address country are not both USA, the country is in the formatted output
- (Per USPS recomendation) All letters in the address are formatted to uppercase in the formatted output
- When the country is present in the formatted output, it is the only value on the last line

Most of the rest of the rules shold have tests for input visibility, label wording, and verification of the output. So in the the city line rules there should be tests for the visibility of each of the mentioned fields, validation that the relevant labels show the correct text, and tests against the formatted output.

- When the address country is USA, the zip code is 5 digits (NNNNN) or 5-4 (NNNNN-NNNN)
- When the address country is Canada, the postal code is 6 characters with a space (A0A 0A0)
- When the address country is China or India, the City Line is formatted as: city, province postalcode
- When the address country is USA, Canada, or Australia, the City Line is formatted as: city state/province postalcode
- When the address country is Brazil, the City Line is formatted as: postalcode town-province
- When the address country is Mexico, the City Line is formatted as: postalcode town, province
- When the address country is Italy, the City Line is formatted as: postalcode town (provincia)
- When the address country is New Zealand, Thailand, Japan, Singapore, the City Line is formatted as: town postalcode
- When the address country is Ireland and the city is not Dublin, the City Line is formatted as: town, Co. county
- When the address country is Ireland and the city is not Dublin and the county begins with Co., the City line only contains one Co. before the county name
- When the address country is Ireland and the city is Dublin, the City Line is formatted as: town postalzone
- When the address country is UK, Russia, Ukraine, Kazakhstan, Hungary, the City Line is formatted as two lines: town \n postalcode
- When the address country is Ecuador, the City Line is formatted as two lines: postalcode \n town
- When the country is Hong Kong, Syria, Iraq, the City Line is formatted as: town
- When the country is not in the above list, the City Line is formatted as: postalcode town
- When the country is US, Canada, or Australia, the City Line has a minimum of two spaces bwteen the state/province and postalcode