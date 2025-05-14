/** KW - 7/28/2015 **/
/** For mask options - see: http://digitalbush.com/projects/masked-input-plugin/ **/
/** Usage Example: <input data-bind="masked:PhoneNumber, mask: '(999) 999-9999'" />  **/

/** Optional 'bindingName' values for global use. **/
/** Usage Example: <input data-bind="masked: PhoneNumber, bindingName: 'usphone', value:PhoneNumber"> **/
/**   -- usphone --> (999) 999-9999
      -- ssn     --> 999-99-9999
      -- mdydate --> 99/99/9999 - Month Day Year format
**/
ko.bindingHandlers.masked = {
    init: function (element, valueAccessor, allBindingsAccessor) {
        var mask = allBindingsAccessor().mask || "";
        var bindingName;

        if (mask === "") {
            bindingName = allBindingsAccessor().bindingName || "";

            if (bindingName !== "") {
                switch (bindingName.toLowerCase()) {
                    case 'usphone':
                        mask = '(999) 999-9999';
                        break;
                    case 'ssn':
                        mask = '999-99-9999';
                        break;
                    case 'currency':
                        //alert("");

                        mask = null;

                        var args = {};
                        var p = allBindingsAccessor();

                        //the prefix to be displayed before(aha!) the value entered by the user(example: "US$ 1234.23"). default: ''
                        args["prefix"] = p.prefix ? p.prefix() : '$';
                        //the prefix to be displayed after the value entered by the user(example: "1234.23 €"). default: ''
                        args["suffix"] = p.suffix ? p.suffix() : '';
                        //set if the prefix and suffix will stay in the field's value after the user exits the field. default: true
                        args["affixesStay"] = p.affixesStay ? p.affixesStay() : true;
                        //the thousands separator. default: ','
                        args["thousands"] = p.thousands ? p.thousands() : ',';
                        //the decimal separator. default: '.'
                        args["decimal"] = p.decimal ? p.decimal() : '.';
                        //how many decimal places are allowed. default: 2
                        args["precision"] = p.precision ? p.precision() : 2;
                        //use this setting to prevent users from inputing zero. default: false
                        args["allowZero"] = p.allowZero != null ? p.allowZero() : true;
                        //use this setting to prevent users from inputing negative values. default: false
                        args["allowNegative"] = p.allowNegative ? p.allowNegative() : false;

                        $(element).maskMoney(args);

                        break;
                    default:
                }
            }
        }

        if (mask) { $(element).mask(mask); }

        ko.utils.registerEventHandler(element, 'focusout', function () {
            var observable = valueAccessor();

            var el = $(element);
            var data = el.data();

            if (data.bind && (data.bind.indexOf("currency") > -1)) {
                observable(el.maskMoney('unmasked')[0]);
            } else {
                observable(el.val());
            }
        });
    },
    update: function (element, valueAccessor) {
        var value = ko.utils.unwrapObservable(valueAccessor());

        var el = $(element);
        var data = el.data();

        if (data.bind && (data.bind.indexOf("currency") > -1)) {
            if (value || (value == 0)) {
                el.val('$' + cloudParkApp.FormattedMoneyString(value));
            }
        }
        else {
            el.val(value);
        }
    }
};





//**07/31/2015 JSE
//binding handler that uses the bootstrap calendar, it's JavaScript and CSS must be loaded
//ko.expressionRewriting._twoWayBindings['datepicker'] = true;
//ko.bindingHandlers.datepicker = {
//    init: function (element, valueAccessor, allBindings, viewModel, bindingContext) {
//        dateFormat = 'mm/dd/yyyy';
//        var options = {
//            showOtherMonths: true,
//            selectOtherMonths: true,
//            dateFormat: dateFormat,
//            showOn: "both",
//        };

//        if (typeof valueAccessor() === 'object') {
//            $.extend(options, valueAccessor());
//        }

//        $(element).datepicker(options);

//        //allows users to clear a date by hitting delete or backspace
//        //$(element).keyup(function (e) {
//        //    if(e.keyCode == 8 || e.keyCode == 46) {
//        //        $(element).datepicker('setDate', null);
//        //    }
//        //});

//        ko.utils.registerEventHandler(element, "change", function () {
//            var modelValue = valueAccessor();
//            debugger;
//            var dateValue = cloudParkApp
//                .FormattedDateString($(element).datepicker("getDate"), true);

//            //if the date was cleared, this is what gets returned from .FormattedDateString()
//            //if (dateValue != "aN/aN/NaN") {
//                if (ko.isWriteableObservable(modelValue)) {
//                    modelValue(dateValue);
//                }
//                else {
//                    allBindingsAccessor.get('_ko_property_writers').datepicker(dateValue);
//                }
//            //}
//        });

//        ko.utils.domNodeDisposal.addDisposeCallback(element, function () {
//            $(element).datepicker("destroy");
//        });
//    },

//    update: function (element, valueAccessor, allBindings, viewModel, bindingContext) {
//        var value = ko.utils.unwrapObservable(valueAccessor());
//        debugger;
//        if (value && value.getUTCMonth) {
//            value = cloudParkApp.FormattedDateString(value, true);
//        }

//        $(element).datepicker('setDate', value);
//    }
//};

//**07/31/2015 JSE
//binding handler that uses the bootstrap calendar, it's JavaScript and CSS must be loaded
ko.bindingHandlers.datepicker = {
    init: function (element, valueAccessor, allBindings, viewModel, bindingContext) {
        dateFormat = 'mm/dd/yyyy';
        var options = {
            showOtherMonths: true,
            selectOtherMonths: true,
            format: dateFormat,
            showOn: "both"
        };

        if (typeof valueAccessor() === 'object') {
            $.extend(options, valueAccessor());
        }

        $(element).datepicker(options);
    },

    update: function (element, valueAccessor, allBindings, viewModel, bindingContext) {
        var value = ko.utils.unwrapObservable(valueAccessor());
        $(element).datepicker('setDate', value);
    }
};

// Here's a custom Knockout binding that makes elements shown/hidden via jQuery's fadeIn()/fadeOut() methods
// Could be stored in a separate utility library
ko.bindingHandlers.fadeVisible = {
    init: function (element, valueAccessor) {
        // Initially set the element to be instantly visible/hidden depending on the value
        var value = valueAccessor();
        $(element).hide();
        $(element).toggle(ko.unwrap(value)); // Use "unwrapObservable" so we can handle values that may or may not be observable
    },
    update: function (element, valueAccessor) {
        // Whenever the value subsequently changes, slowly fade the element in or out
        var value = valueAccessor();
        $(element).hide();
        ko.unwrap(value) ? $(element).fadeIn() : $(element).fadeOut();
    }
};
