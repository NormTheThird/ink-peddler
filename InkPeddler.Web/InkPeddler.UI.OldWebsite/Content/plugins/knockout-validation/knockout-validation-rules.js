/*************************************************************************************
* Global Knockout-validation Rules
* https://github.com/Knockout-Contrib/Knockout-Validation - v2.0.3
*
* This enables global reusable Knockout Validation rules.
*************************************************************************************/

//ko.validation.init({
//    registerExtenders: true,
//    messagesOnModified: true,
//    insertMessages: true,
//    parseInputAttributes: true,
//    messageTemplate: null
//}, true);


/****************************************************************************
* DateGreater - used to validate one date is greater than another.
* This validates that the param value (otherVal) is less than the 
* observable value (val).  This is generally used on the EndDate observable 
* where the StartDate is the param.
* -- for usage see - ContractDataModel.js in the ContractEditViewModel.js - self.EndDate
* Example: self.EndDate = ko.observable().extend({ dateGreater: self.StartDate });
****************************************************************************/
ko.validation.rules['dateGreater'] = {
    validator: function (val, otherVal) {
        //console.log("val: " + val + " - other: " + otherVal);
        var d1 = new Date(val),
            d2 = new Date(otherVal);
        return d1 > d2;
    },
    message: 'The start date must be before the end date'
};






/** Place all rules before this method. **/
ko.validation.registerExtenders();