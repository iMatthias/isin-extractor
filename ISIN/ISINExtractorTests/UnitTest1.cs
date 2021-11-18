using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ISINExtractorTests
{
	[TestClass]
	public class UnitTest1
	{
		public const string fileContent = @"|$!$| EXECUTION VERSION PROHIBITION OF SALES TO EEA AND UK RETAIL INVESTORS – The Notes are not intended to be offered, sold or otherwise made available to and should not be offered, sold or otherwise made available to any retail investor in the European Economic Area ("EEA") or the United Kingdom (the "UK"). For these purposes, a retail investor means a person who is one (or more) of: (i) a retail client as defined in point (11) of Article 4(1) of Directive 2014/65/EU (as amended "MiFID II"); (ii) a customer within the meaning of Directive (EU) 2016/97 (the "Insurance Distribution Directive"), where that customer would not qualify as a professional client as defined in point (10) of Article 4(1) of MiFID II; or (iii) not a qualified investor as defined in Regulation (EU) 2017/1129 (the "Prospectus Regulation"). Consequently, no key information document required by Regulation (EU) No 1286/2014 (the "PRIIPs Regulation") for offering or selling the Notes or otherwise making them available to retail investors in the EEA or in the UK has been prepared and therefore offering or selling the Notes or otherwise making them available to any retail investor in the EEA or in the UK may be unlawful under the PRIIPs Regulation. An investment in the Notes does not have the status of a bank deposit and is not within the scope of the deposit protection scheme operated by the Central Bank of Ireland. The Issuer is not and will not be regulated by the Central Bank of Ireland as a result of issuing the Notes. MIFID II PRODUCT GOVERNANCE / PROFESSIONAL INVESTORS AND ECPS ONLY TARGET MARKET - Solely for the purposes of each manufacturer's product approval process, the target market assessment in respect of the Notes has led to the conclusion that: (i) the target market for the Notes is eligible counterparties and professional clients only, each as defined in MiFID II; and (ii) all channels for distribution of the Notes to eligible counterparties and professional clients are appropriate. Any person subsequently offering, selling or recommending the Notes (a "distributor") should take into consideration the manufacturers' target market assessment; however, a distributor subject to MiFID II is responsible for undertaking its own target market assessment in respect of the Notes (by either adopting or refining the manufacturers' target market assessment) and determining appropriate distribution channels. Final Terms dated 8 September 2020 GLENCORE CAPITAL FINANCE DAC Legal entity identifier (LEI): 213800HCUCI1HC7X6Q34 Issue of EUR 850,000,000 1.125 per cent. Guaranteed Notes due 2028 Guaranteed by GLENCORE PLC and GLENCORE INTERNATIONAL AG and GLENCORE (SCHWEIZ) AG |$!$| under the U.S.$20,000,000,000 Euro Medium Term Note Programme PART A Contractual Terms Terms used herein shall be deemed to be defined as such for the purposes of the conditions (the "Conditions") set forth in the base prospectus dated 24 August 2020 (the "Base Prospectus") which constitutes a base prospectus for the purposes of Regulation (EU) 2017/1129 (the "Prospectus Regulation"). This document constitutes the Final Terms of the Notes described herein for the purposes of Article 8 of the Prospectus Regulation and must be read in conjunction with such Base Prospectus in order to obtain all the relevant information. The Base Prospectus has been published on the website of the Luxembourg Stock Exchange (www.bourse.lu). 1 (i) Series Number: (ii) Tranche Number: (iii) Date on which the Notes will be consolidated and form a single Series: 2 Specified Currency or Currencies: 3 Aggregate Nominal Amount of Notes admitted to trading: 4 5 Issue Price: (i) Specified Denominations: 32 1 Not Applicable Euros ("EUR") EUR 850,000,000 99.916 per cent. of the Aggregate Nominal Amount EUR 100,000 and integral multiples of EUR 1,000 in excess thereof up to and including EUR 199,000. No Notes in definitive form will be issued with a denomination above EUR 199,000. 6 (ii) Calculation Amount: EUR 1,000 (i) Issue Date: (ii) Interest Commencement Date: 7 Maturity Date: 8 Interest Basis: 10 September 2020 Issue Date 10 March 2028 1.125 per cent. Fixed Rate (further particulars specified in 13 below) - 2 - |$!$| 9 Redemption Basis: Subject to any purchase and cancellation or early redemption, the Notes will be redeemed at 100 per cent. of their Aggregate Nominal Amount 10 Change of Interest Basis: Not Applicable 11 Put/Call Options: 12 Date Board approval for issuance of Notes and Guarantees obtained: Issuer Call (further particulars specified in 16 below) 7 August 2020 and 28 August 2020, in the case of the Issuer; 13 February 2020 and 3 March 2020, in the case of Glencore plc; and 10 August 2020, in the case of Glencore International AG and Glencore (Schweiz) AG PROVISIONS RELATING TO INTEREST (IF ANY) PAYABLE 13 Fixed Rate Note Provisions Applicable (i) Rate of Interest: (ii) Step Up Event/Step Down Event: (iii) Step Up Margin: (iv) Interest Payment Date(s): (v) Fixed Coupon Amount: No Not Applicable 10 March in each year, commencing on 10 March 2021 EUR 11.25 per Calculation Amount (vi) Broken Amount(s): EUR 5.58 per Calculation Amount, payable on the Interest Payment Date falling on 10 March 2021 14 15 (vii) Day Count Fraction: Actual/Actual (ICMA) Not Applicable Floating Rate Note Provisions Zero Coupon Note Provisions Call Option Not Applicable PROVISIONS RELATING TO REDEMPTION 16 1.125 per cent. per annum payable in arrear on each Interest Payment Date Applicable - 3 - |$!$|";

		[TestMethod]
		public void TestMethod1()
		{
			Assert.IsFalse(true);

			ISINProcessor processor = new ISINProcessor();

			IEnumerable<string> actual = processor.ExtractParagraphs(fileContent);
			List<string> expected = new List<string> { "FR0014006BL6" };

			Assert.AreEqual(expected: 3, actual: actual.Count());
			Assert.AreEqual(expected: expected, actual: actual);
		}
	}

	public class ISINProcessor
	{
		public IEnumerable<string> ExtractParagraphs(string fileContent)
		{
			string[] tokens = fileContent.Split("|$!$|");
			IEnumerable<string> paragraphs = tokens.Where(token => string.IsNullOrWhiteSpace(token) == false); // TODO: Trim each content
			return paragraphs;
		}
	}
}