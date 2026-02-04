using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PeshawarDHASW.Models
{
    public class tbl_NDC
    {
    public int NDCNo  { get; set; }
	public DateTime DateIssue  { get; set; }
	public DateTime Purcsr_Payment_Date  { get; set; }
	public string DHAP_Challan_No  { get; set; }
	public int FileKey  { get; set; }
	public int userID  { get; set; }
	public string Remarks { get; set; }
	public decimal Seller_Amount  { get; set; }
	public string Seller_Account_No  { get; set; }
	public decimal Purchaser_Amount { get; set; }
	public string Purchase_Account_No { get; set; }
	public string DDNoPOReceipt { get; set; }
	public string Bank { get; set; }
	public string FilePlotNo { get; set; }
	public string Street_LaneNo { get; set; }
	public string Sector { get; set; }
	public string Phase  { get; set; }
	public string WHTax_us_236_K_Amount  { get; set; }
	public string WHTax_us_236_C_Amount  { get; set; }
	public string StampDuty  { get; set; }
	public string StatusofNDC  { get; set; }
	public string NDCExpireDate  { get; set; }
	public int StampDutyID  { get; set; }
	public string GoBack_Remarks { get; set; }
	public DateTime NDCVerificationDate  { get; set; }
	public int PreparedBy  { get; set; }
	public DateTime PreparedByDate  { get; set; }
	public int ReviewedBy  { get; set; }
	public DateTime ReviewedBydate  { get; set; }
	public int VerifiedBy  { get; set; }
	public int ApprovedBy  { get; set; }
	public DateTime ApprovedByDate  { get; set; }
	public string AppCanRemarks  { get; set; }
	public string NDCType  { get; set; }
	public string NDCTypeNormalUrgent  { get; set; }
	public string RequestedBy { get; set; }
	public string TFRType  { get; set; }
	public string OutStationCharges  { get; set; }
    }
}
