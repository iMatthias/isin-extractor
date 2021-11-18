using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ISINExtractor
{
	/*
	  Exammple ISINs

	  FR0014006BL6
	  SE0017083074
	  US052477MN38
	  XS2288677649
	  NLBNPIT15WF4
	  USU5739DAE59

	  {
		  "documentId" : 343434,
		  "isin": "NLBNPIT15WF4",
		  "companyName": "ABC",
		  "figiId": "BBG00X3FHYG0",
		  "ticker": "IBM"
		  "foundText": "Convenience Translation – 7.3 Further declarations by KDG Shareholders accepting the Offer The following declarations are partly explained in more detail in Sections 7.4 and 7.5 of this Offer Document. By accepting the Offer pursuant to Section 7.2 of this Offer Document: (i)   the accepting KDG Shareholders instruct and authorise their respective Custodian Bank and any intermediate custodian of the relevant Tendered KDG Shares: to leave the Tendered KDG Shares in the securities account of the accepting KDG Shareholder for the time being, but to cause them to be re-booked un- der ISIN DE000A3H23P9 (Tendered KDG Shares) at Clearstream; to instruct and authorise Clearstream to make the Tendered KDG Shares (ISIN DE000A3H23P9) available to the Central Settlement Agent on its se- curities account held with Clearstream for transfer of ownership to the Bidder following expiry of the Acceptance Period (however not before fulfilment of the Completion Condition set out in Section 9.1 of this Offer Document, if the Bidder has not validly waived it);  to instruct and authorise Clearstream to transfer ownership of the Tendered KDG Shares (ISIN DE000A3H23P9) in each case including all rights attach- ing thereto at the time this Offer is settled following expiry of the Acceptance Period (however not before fulfilment of the Completion Condition set out in Section 9.1 of this Offer Document, if the Bidder has not validly waived it) to the Bidder simultaneously with (Zug um Zug gegen) payment of the Offer Consideration for the relevant Tendered KDG Shares to the account of the relevant Custodian Bank with Clearstream in accordance with the provisions of the Offer;  to itself instruct and authorise Clearstream, to notify the Central Central Set- tlement Agent during the (possibly extended) Acceptance Period and during the respective post-booking periods of the relevant number of Tendered KDG Shares (ISIN DE000A3H23P9) booked to its account maintained with Clear- stream. With the re-booking into ISIN DE000A3H23P9, the relevant Custo- dian Bank simultaneously agrees to disclose this holding to the Central Set- tlement Agent; and  (ii) to forward the Declaration of Acceptance. the accepting KDG Shareholders instruct and authorise their respective Custodian Bank and the Central Settlement Agent, in each case with an exemption from the prohibition of contracting with oneself pursuant to section 181 of the German Civil Code (Bürgerliches Gesetzbuch), to take all steps and to make and receive all dec- larations necessary or expedient for the settlement of this Offer in accordance with this Offer Document, and in particular to procure the transfer of ownership of the Tendered KDG Shares to the Bidder following expiry of the Acceptance Period (how- ever not before fulfilment of the Completion Condition set out in Section 9.1 of this Offer Document, if the Bidder has not validly waived it); (iii) the accepting KDG Shareholders declare that: 10 "
	  }

	  - Find ISINs in given set of documents
	  - For each found ISIN, extract paragraph that the ISIN features in
	  - Send ISINs to Open FIGI API  (https://www.openfigi.com/api) and get back figi, ticker and company name
	  - Construct correct JSON and send to SearchIndexer.IndexDocument()
	  - Log returned strings to console
	  */

	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");

			DoSomething();
		}

		private static void DoSomething()
		{
			throw new NotImplementedException();
		}
	}

	public class ISINProcessor
	{
		public void Main()
		{
			string[] filepaths = new string[] { };

			foreach (string filepath in filepaths)
			{
				ProcessSingleFile(filepath);
			}
		}

		private void ProcessSingleFile(string filepath)
		{
			IEnumerable<string> paragraphs = ReadSingleFile(filepath);

			foreach (string paragraph in paragraphs)
			{
				HashSet<string> ISINs = ExtractUniqueISINsFromSingleParagraph(paragraph);

				foreach (string ISIN in ISINs)
				{
					FigiData response = SendFigiRequest(ISIN); // TODO: Change to async
					IndexData indexData = new IndexData(); // new IndexData();
				}
			}
		}

		private FigiData SendFigiRequest(string iSIN)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Returns paragraphs in a single file
		/// </summary>
		/// <param name="filepath"></param>
		/// <returns></returns>
		public IEnumerable<string> ReadSingleFile(string filepath)
		{
			string fileContent = File.ReadAllText(filepath); // TODO: change to async

			IEnumerable<string> paragraphs = ExtractParagraphs(fileContent);
			return paragraphs;
		}

		public IEnumerable<string> ExtractParagraphs(string fileContent)
		{
			string[] tokens = fileContent.Split("|$!$|");
			IEnumerable<string> paragraphs = tokens.Where(token => string.IsNullOrWhiteSpace(token) == false);
			return paragraphs;
		}

		private HashSet<string> ExtractUniqueISINsFromSingleParagraph(string paragraph)
		{
			HashSet<string> hashSet = new HashSet<string>();

			return hashSet;
		}
	}

	public class FigiData
	{
		public string FigiId;
		public string CompanyName;
		public string Ticker;
		public string MarketSector;
	}

	public class IndexData
	{
		public string DocumentId;
		public string ISIN;
		public string CompanyName;
		public string FigiId;
		public string Ticker;
		public string FoundText;

		public IndexData()
		{

		}

		public IndexData(string documentId, string isin, string foundText, FigiData figiData)
		{
			this.DocumentId = documentId;
			this.ISIN = isin;
			// ....
		}
	}

	//   {
	//   "documentId" : 343434,
	//   "isin": "NLBNPIT15WF4",
	//   "companyName": "ABC",
	//   "figiId": "BBG00X3FHYG0",
	//   "ticker": "IBM"
	//   "foundText": 
	// 	}

	// For each
	// ISIN
	// To get
	// - FigiId
	// - name
	// - ticker
	// - marketSector
}