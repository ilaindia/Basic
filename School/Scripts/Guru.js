

function Server_Script_Registration() {
    inputSelect();
    tableResponsive();
    timepicker();
    datepicker();
    //bootstrapDatepicker();
    //multiDatesPicker();
    NumericValidation();
    handleiCheck();
    TabGuru.activate($('#FormBody')).setFocus();
    initializeAspNetValidationControls();
    popover();
}
/****  Show Popover  ****/
function popover() {
    if ($('.GuruPopOver').length && $.fn.popover) {
        $('.GuruPopOver').popover({
            trigger: "hover"
        });
    }
    if ($('.GuruPopOver_dark').length && $.fn.popover) {
        $('.GuruPopOver_dark').popover({
            template: '<div class="popover popover-dark" style="max-width: 500px !important;"><div class="arrow"></div><h3 class="popover-title popover-title"></h3><div class="popover-content popover-content" style="max-width: 500px !important;"></div></div>',
            trigger: "hover",
            html: true,
            content: function () { return '<a href="#" class="pull-left"><img src="' + $(this).data('img') + '" class="round-img" alt="' + $(this).data('title') + '"></a><div class="media-body">' + $(this).data('zcontent') + '</p></div>' }
        });
        //'<div class="media"><a href="#" class="pull-left"><img src="../App_Upload/Company_Img/Zerobugz_Logo.png" class="round-img" alt="Sample Image"></a><div class="media-body"><h4 class="media-heading">Zerobugz Software</h4><p>Zerobugz Software is a leading amateur IT company providing Software Development, Bulk SMS, Web Design services in Tamilnadu</p></div></div>'
    }
}

//Select Plugin 
function inputSelect() {
    if ($.fn.select2) {
        setTimeout(function () {
            $('select').each(function () {
                function format(state) {
                    var state_id = state.id;
                    if (!state_id) return state.text; // optgroup
                    var res = state_id.split("-");
                    if (res[0] == 'image') {
                        if (res[2]) return "<img class='flag' src='assets/images/flags/" + res[1].toLowerCase() + "-" + res[2].toLowerCase() + ".png' style='width:27px;padding-right:10px;margin-top: -3px;'/>" + state.text;
                        else return "<img class='flag' src='assets/images/flags/" + res[1].toLowerCase() + ".png' style='width:27px;padding-right:10px;margin-top: -3px;'/>" + state.text;
                    }
                    else {
                        return state.text;
                    }
                }
                $(this).select2({
                    formatResult: format,
                    formatSelection: format,
                    placeholder: $(this).data('placeholder') ? $(this).data('placeholder') : '',
                    allowClear: $(this).data('allowclear') ? $(this).data('allowclear') : true,
                    minimumInputLength: $(this).data('minimumInputLength') ? $(this).data('minimumInputLength') : -1,
                    minimumResultsForSearch: $(this).data('search') ? 1 : -1,
                    dropdownCssClass: $(this).data('style') ? 'form-white' : ''
                });
            });
        }, 200);
    }
}
//Tables Responsive 
function tableResponsive() {
    setTimeout(function () {
        $('.table').each(function () {
            window_width = $(window).width();
            table_width = $(this).width();
            content_width = $(this).parent().width();
            if (table_width > content_width) {
                $(this).parent().addClass('force-table-responsive');
            }
            else {
                $(this).parent().removeClass('force-table-responsive');
            }
        });
    }, 200);
}
//Time picker
function timepicker() {
    $('.timepicker').each(function () {
        $(this).timepicker({
            isRTL: $('body').hasClass('rtl') ? true : false,
            timeFormat: $(this).attr('data-format', 'am-pm') ? 'hh:mm tt' : 'HH:mm'
        });
    });
}
//Date Picker
function datepicker() {
    $('.date-picker').each(function () {
        $(this).datepicker({
            numberOfMonths: 1,
            isRTL: false,
            prevText: '<i class="fa fa-angle-left"></i>',
            nextText: '<i class="fa fa-angle-right"></i>',
            showButtonPanel: false,
            changeMonth: true,
            changeYear: true,
            gotoCurrent: true,
            dateFormat: 'dd-mm-yy'
        });
    });
}
//Bootstrap Date Picker
function bootstrapDatepicker() {
    $('.b_datepicker').each(function () {
        $(this).bootstrapDatepicker({
            startView: $(this).data('view') ? $(this).data('view') : 0, // 0: month view , 1: year view, 2: multiple year view
            language: $(this).data('lang') ? $(this).data('lang') : "en",
            forceParse: $(this).data('parse') ? $(this).data('parse') : false,
            daysOfWeekDisabled: $(this).data('day-disabled') ? $(this).data('day-disabled') : "", // Disable 1 or various day. For monday and thursday: 1,3
            calendarWeeks: $(this).data('calendar-week') ? $(this).data('calendar-week') : false, // Display week number 
            autoclose: $(this).data('autoclose') ? $(this).data('autoclose') : false,
            todayHighlight: $(this).data('today-highlight') ? $(this).data('today-highlight') : true, // Highlight today date
            toggleActive: $(this).data('toggle-active') ? $(this).data('toggle-active') : true, // Close other when open
            multidate: $(this).data('multidate') ? $(this).data('multidate') : false, // Allow to select various days
        });
    });
}
//Multiple Date Picker
function multiDatesPicker() {
    $('.multidatepicker').each(function () {

        $(this).multiDatesPicker({
            dateFormat: 'yy-mm-dd',
            minDate: new Date(),
            maxDate: '+1y',
            firstDay: 1,
            showOtherMonths: true
        });
    });
}
// Display Error Message
function Error_Msg(_Msg) {
    swal({
        title: '',
        text: _Msg,
        type: "error",
        showCancelButton: false,
        confirmButtonColor: '#3CA2BB',
        confirmButtonText: 'OK',
        closeOnConfirm: true
    });
}
// Display Warning Message
function Warning_Msg(_Msg) {
    swal({
        title: '',
        text: _Msg,
        type: "warning",
        showCancelButton: false,
        confirmButtonColor: '#3CA2BB',
        confirmButtonText: 'OK',
        closeOnConfirm: true
    })
}
// Display Success Message
function Success_Msg(_Msg) {
    swal({
        title: '',
        text: _Msg,
        type: "success",
        showCancelButton: false,
        confirmButtonColor: '#A5DC86',
        confirmButtonText: 'OK',
        closeOnConfirm: true
    });
}

function Success_Notification(_Msg) {
    notifContent = '<div class="alert alert-dark media fade in bd-0" id="message-alert" style="background-color: #00B16A !important;">' +
                        '<div class="media-left">' +
                            '<span class="fa-stack-md fa-lg" style="color: #FFFFFF !important;">' +
                                '<i class="fa fa-circle fa-stack-4x"></i>' +
                                '<i class="fa fa-check-circle  faa-pulse animated fa-stack-1x fa-inverse" style="font-size: 30px;color: #00B16A !important;"></i>' +
                            '</span>' +
                        '</div>' +
                        '<div class="media-body width-100p">' +
                            '<h4 class="alert-title f-14">Message</h4>' +
                            '<p class="f-12 alert-message pull-left">' + _Msg + '</p>' +
                        '</div>' +
                    '</div>'
    var position = 'bottomRight';
    if ($('body').hasClass('rtl')) position = 'bottomRight';
    var openAnimation = 'animated bounceInLeft';
    var closeAnimation = 'animated fadeOut';
    var n = noty({
        text: notifContent,
        type: 'success',
        dismissQueue: true,
        layout: position,
        closeWith: ['click'],
        theme: 'made',
        animation: {
            open: 'animated bounceInRight', // Animate.css class names
            close: 'animated bounceOutLeft', // Animate.css class names
            easing: 'swing', // unavailable - no need
            speed: 500 // unavailable - no need
        },
        timeout: false
    });
}
function Error_Notification(_Msg) {
    notifContent = '<div class="alert alert-dark media fade in bd-0" id="message-alert" style="background-color: #c75757 !important;">' +
                        '<div class="media-left">' +
                            '<span class="fa-stack-md fa-lg" style="color: #FFFFFF !important;">' +
                                '<i class="fa fa-circle fa-stack-4x"></i>' +
                                '<i class="fa fa-times-circle  faa-pulse animated fa-stack-1x fa-inverse" style="font-size: 30px;color: #c75757 !important;"></i>' +
                            '</span>' +
                        '</div>' +
                        '<div class="media-body width-100p">' +
                            '<h4 class="alert-title f-14">Error Message</h4>' +
                            '<p class="f-12 alert-message pull-left">' + _Msg + '</p>' +
                        '</div>' +
                    '</div>'
    var position = 'bottomRight';
    if ($('body').hasClass('rtl')) position = 'bottomRight';
    var openAnimation = 'animated bounceInLeft';
    var closeAnimation = 'animated fadeOut';
    var n = noty({
        text: notifContent,
        type: 'success',
        dismissQueue: true,
        layout: position,
        closeWith: ['click'],
        theme: 'made',
        animation: {
            open: 'animated bounceInRight', // Animate.css class names
            close: 'animated bounceOutLeft', // Animate.css class names
            easing: 'swing', // unavailable - no need
            speed: 500 // unavailable - no need
        },
        timeout: false
    });
}
// Display Confirmation Message
function Confirm_Msg(btn, _Msg, validationgroupname) {
    var validated = false;
    if (validationgroupname !== '' && typeof (validationgroupname) != "undefined" && typeof (validationgroupname) != "NaN" && typeof (validationgroupname) != "null") {
        validated = Page_ClientValidate(validationgroupname);
    }
    else {
        validated = true;
    }
    if (validated) {
        swal({
            title: '',
            text: _Msg,
            type: "warning",
            showCancelButton: true,
            confirmButtonColor: '#3CA2BB',
            confirmButtonText: 'Yes',
            cancelButtonText: "No",
            closeOnConfirm: true,
            closeOnCancel: true
        },
        function (isConfirm) {
            if (isConfirm) {
                if ($(btn).prop('tagName') === 'INPUT' || $(btn).prop('tagName') === 'SELECT') {
                    __doPostBack($(btn).attr("name"), '');
                } else if ($(btn).prop('tagName') === 'A') {
                    var i = $(btn).attr("href");
                    i = i.slice(25, i.length);
                    i = i.substring(0, i.length - 5);
                    __doPostBack(i, '');
                }
            } else {
                return false;
            }
        });
    }
    else {
        Error_Notification("Please check.. Some inputs are missing !");
    }
    return false;
}
// Perform Numeric Validation Like Decimal, Integer
function NumericValidation() {
    // GOTO textbox at pager control without decimal precision
    $('.goto-text').autoNumeric("init", { mDec: 0, aSep: "" });
    // By default decimal with 4 digits pecision 
    $('.decimal4').autoNumeric("init", { mDec: 4, aSep: "" });
    // decimal with 6 digits pecision 
    $('.decimal6').autoNumeric("init", { mDec: 6, aSep: "" });
    $('.decimal6').attr('style', 'text-align:right;');
    // decimal with 4 digits pecision 
    $('.decimal').autoNumeric("init", { mDec: 4, aSep: "" });
    $('.decimal').attr('style', 'text-align:right;');
    // decimal with 2 digits pecision 
    $('.decimal2').autoNumeric("init", { mDec: 2, aSep: "", vMin: "-9999999.99" });
    $('.decimal2').attr('style', 'text-align: right;');
    $('.Sdecimal2').autoNumeric("init", { mDec: 2, aSep: "", vMin: "-9999999.99" });
    $('.Sdecimal2').attr('style', 'text-align: right;');

    //    // decimal with 2 digits pecision with 6 maximum length
    //    $('.decimal26').autoNumeric("init", { mDec: 2, aSep: "", vMax: "999999.00" });
    //    // decimal with 2 digits pecision with 5 maximum length
    //    $('.decimal25').autoNumeric("init", { mDec: 2, aSep: "", vMax: "99999.00" });
    //    // decimal with 2 digits pecision with 4 maximum length
    //    $('.decimal24').autoNumeric("init", { mDec: 2, aSep: "", vMax: "9999.00" });
    //    // decimal with 2 digits pecision with 3 maximum length
    //    $('.decimal23').autoNumeric("init", { mDec: 2, aSep: "", vMax: "999.00" });
    //    // decimal with 2 digits pecision with 2 maximum length
    //    $('.decimal22').autoNumeric("init", { mDec: 2, aSep: "", vMax: "99.00" });

    $('.integer').autoNumeric("init", { mDec: 0, aSep: "", vMin: "-9999999.99" });
    //    $('.integer6').autoNumeric("init", { mDec: 0, aSep: "", vMax: "999999.00" });
    //    $('.integer5').autoNumeric("init", { mDec: 0, aSep: "", vMax: "99999.00" });
    //    $('.integer4').autoNumeric("init", { mDec: 0, aSep: "", vMax: "9999.00" });
    //    $('.integer3').autoNumeric("init", { mDec: 0, aSep: "", vMax: "999.00" });
    //    $('.integer2').autoNumeric("init", { mDec: 0, aSep: "", vMax: "99.00" });
}

// Handles custom checkboxes & radios using jQuery iCheck plugin
function handleiCheck() {

    if (!$().iCheck) return;
    $(':checkbox:not(.js-switch, .switch-input, .switch-iphone, .onoffswitch-checkbox, .ios-checkbox), :radio').each(function () {

        var checkboxClass = $(this).attr('data-checkbox') ? $(this).attr('data-checkbox') : 'icheckbox_square-blue';
        var radioClass = $(this).attr('data-radio') ? $(this).attr('data-radio') : 'iradio_square-blue';

        if (checkboxClass.indexOf('_line') > -1 || radioClass.indexOf('_line') > -1) {
            $(this).iCheck({
                checkboxClass: checkboxClass,
                radioClass: radioClass,
                increaseArea: '20%',
                insert: '<div class="icheck_line-icon"></div>' + $(this).attr("data-label")
            });
        } else {
            $(this).iCheck({
                checkboxClass: checkboxClass,
                increaseArea: '20%',
                radioClass: radioClass
            });
        }
    });
}
var TabGuru = {};

TabGuru.activate = function (el) {
    TabGuru.deactivate();

    TabGuru._el = el;
    $(window).on('keydown', TabGuru._handleTab);

    return TabGuru;
};

TabGuru.deactivate = function () {
    TabGuru._el = null;

    // detach old focus events
    TabGuru._detachFocusHandlers();

    TabGuru._els = null;
    TabGuru._currEl = null;

    $(window).off('keydown', TabGuru._handleTab);

    return TabGuru;
};

TabGuru.setFocus = function (prev) {
    // detach old focus events
    TabGuru._detachFocusHandlers();

    // scan for new tabbable elements
    var tabbables = TabGuru._el.find(':tabbable');
    TabGuru._els = [];

    // wrap elements in jquery
    for (var i = 0; i < tabbables.length; i++) {
        var el = $(tabbables[i]);
        // set focus listener on each element
        el.on('focusin', TabGuru._focusHandler);
        TabGuru._els.push(el);
    }

    // determine the index of focused element so we will know who is
    // next/previous to be focused
    var currIdx = 0;
    for (var i = 0; i < TabGuru._els.length; i++) {
        var el = TabGuru._els[i];

        // if focus is set already on some element
        if (TabGuru._currEl) {
            if (TabGuru._currEl === el[0]) {
                currIdx = i;

                prev ? currIdx-- : currIdx++;
                break;
            }

        } else {
            // focus is not set yet.
            // let's set it by attribute "autofocus".
            if (el.attr('autofocus') !== undefined) {
                currIdx = i;
                break;
            }
        }
    }

    if (currIdx < 0) {
        currIdx += TabGuru._els.length;
    }
    if (TabGuru._els.length) {
        TabGuru._els[Math.abs(currIdx % TabGuru._els.length)].focus();
    }

    return TabGuru;
};

TabGuru._handleTab = function (e) {
    if (e.which === 9) {
        e.preventDefault();

        TabGuru.setFocus(e.shiftKey);
    }
};

TabGuru._focusHandler = function (e) {
    TabGuru._currEl = e.currentTarget;
};

TabGuru._detachFocusHandlers = function () {
    if (TabGuru._els) {
        for (var i = 0; i < TabGuru._els.length; i++) {
            TabGuru._els[i].off('focusin', TabGuru._focusHandler);
        }
    }
};


$.Convert = {
    AsInt: function (Str) {
        var tmpValue = ((isNaN(Str)) ? '0' : Str);
        try {
            return parseInt(tmpValue, 10);
        } catch (e) {
            console.log(e.message);
        }
    },
    AsFloat: function (Str) {
        var tmpValue = ((isNaN(Str)) ? '0.00' : Str);
        try {
            return parseFloat(tmpValue).toFixed(2);
        } catch (e) {
            console.log(e.message);
        }
    },
    AsString: function (Str) {
        return (!Str || 0 === Str.length) ? '' : Str;
    },
    isEnable: function () {
        return (DisableCtrl)
    },
    Has_Str: function (str) {
        return (!str || 0 === str.length || str === null);
    }
}


function AddToASPNETValidators(ctrl, vgroup, defaultval) {
    var eValidator = document.createElement('span');
    eValidator.id = $(ctrl).attr("id") + "Validator";
    eValidator.controltovalidate = $(ctrl).attr("id");
    eValidator.errormessage = "Required !";
    eValidator.validationGroup = vgroup;
    eValidator.initialvalue = defaultval;
    eValidator.evaluationfunction = RequiredFieldValidatorEvaluateIsValid;

    $(ctrl).change(function () {
        ValidatorOnChange();
    });
    Page_Validators.push(eValidator);
}