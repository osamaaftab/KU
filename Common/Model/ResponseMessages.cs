using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model {
    public  class ResponseMessages {
        public static string ValidModel = "Valid Model.";
        public static string SearchResultNotFound = "Search Result Not Found.";
        public static string UnExpectedErrorOccured = "An error has occured, Please correct following validations errors if any. if you contact support provide this error code {0} with details"; // for all catch blocks
        public static string ActionCompleted = "Action Successfull."; //this message will be shown when someone activate or deactivate record and send any GET request.
        public static string PleaseProvideValidParamter = "Invalid Request. Please Provide Valid Request Parameter.";
        public static string BusinessCatagoryIsRequired = "Business Catagory ID is required and should be a valid Guid.";
        public static string BusinessCatagoryNotFound = "Business Catagory not found, Please provide valid Guid.";
        public static string InvalidRequest = "Invalid Request, All Feilds are null.";
        public static string IndustryTypeIdIsRequired = "Industry Type ID is required and shoud be a valid Guid.";
        public static string IndustryTypeNotFound = "Industry Type not found, Please provide valid Guid.";
        public static string CityIdIsRequired = "City ID is required and should be a valid Guid.";
        public static string CityNotFound = "City not found, Please provide valid Guid.";
        public static string CountryIdIsRequired = "Country ID is required and should be a valid Guid.";
        public static string CountryNotFound = "Country not found, Please provide valid Guid.";
        public static string StateIdIsRequired = "State ID is required and should be a valid Guid.";
        public static string StateNotFound = "State not found, Please provide valid Guid";
        public static string StateCitiesNotFound = "State cities not found";
        public static string InValidPostalCode = "Please provide valid Postal Code";
        public static string LeadSourceIdIsRequired = "Lead Source Id is required and should be a valid Guid.";
        public static string LeadSourceNotFound = "Lead Source not found, Please provide valid Guid";
        public static string ShippingMethodNotFound = "Shipping Methods not found.";
        public static string DiscountTypeNotFound = "Discount Types not found.";
        public static string EmailAddressIsRequired = "Email Address is required and format should be correct.";
        public static string InvalidEmailAddress = "Invalid Email Adress format";
        public static string InvalidAddress = "Invalid Adress format";
        public static string InvalidActivityId = "Invalid Activity Id";
        public static string ActivityNotExist = "Activity Does Not Exist";
        public static string InValidImage = "Image cannot be null or format is not valid, please provide valid format";
        public static string RecordNotFound = "Record not found"; //this message will be shown when someone activate or deactivate record and send any GET request.
    }
}
